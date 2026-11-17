using DiGi.Harness.Classes;
using DiGi.Harness.Enums;
using DiGi.Harness.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.Harness
{
    public static partial class Modify
    {
        /// <summary>
        /// Runs one turn of the agent loop on a conversation whose last message is the user's: requests the model, runs the tools it calls, returns their results, and repeats until the model answers without calling a tool.
        /// <para>Events are handed to <paramref name="func"/> one at a time, never concurrently. Every step emits <see cref="StepStartedEvent"/> and <see cref="UsageEvent"/>; every tool call emits <see cref="ToolCallStartedEvent"/> and <see cref="ToolCallCompletedEvent"/>; the turn always ends with <see cref="TurnCompletedEvent"/>, preceded by <see cref="ErrorEvent"/> when it failed.</para>
        /// <para>The conversation never ends with an unanswered tool call: tool calls the loop does not run (output cut off, a refusal, the iteration limit, a cancellation) get error results. Tool calls of one step run in parallel and their results go back in one message. A tool input that is not a JSON object, or lacks a property the schema requires, is answered with an error result without running the tool. Results longer than <see cref="RunOptions.MaxToolResultCharacters"/> are truncated with a note. Only a requested cancellation is rethrown.</para>
        /// </summary>
        /// <param name="conversation">The conversation; the turn's messages are appended to it.</param>
        /// <param name="httpClient">The HTTP client used for the model requests.</param>
        /// <param name="providerConfiguration">The provider; it must be the one the conversation is locked to.</param>
        /// <param name="tools">The tools offered to the model, or null for none.</param>
        /// <param name="runOptions">The system prompt and limits, or null for the defaults.</param>
        /// <param name="func">The handler receiving the turn's events, or null.</param>
        /// <param name="cancellationToken">The token that cancels the turn.</param>
        /// <returns>The outcome of the turn.</returns>
        public static async Task<TurnResult> RunTurnAsync(this Conversation? conversation, HttpClient? httpClient, ProviderConfiguration? providerConfiguration, IEnumerable<ITool>? tools, RunOptions? runOptions, Func<HarnessEvent, CancellationToken, Task>? func, CancellationToken cancellationToken = default)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            using SemaphoreSlim semaphoreSlim = new(1, 1);

            RunOptions runOptions_Temp = runOptions ?? new RunOptions();
            int maxToolIterations = runOptions_Temp.MaxToolIterations > 0 ? runOptions_Temp.MaxToolIterations : Constants.Default.MaxToolIterations;
            int maxToolResultCharacters = runOptions_Temp.MaxToolResultCharacters > 0 ? runOptions_Temp.MaxToolResultCharacters : Constants.Default.MaxToolResultCharacters;

            Dictionary<string, ITool> tools_ByName = new(StringComparer.Ordinal);
            if (tools is not null)
            {
                foreach (ITool tool in tools)
                {
                    if (tool?.ToolDefinition?.Name is string name && !tools_ByName.ContainsKey(name))
                    {
                        tools_ByName[name] = tool;
                    }
                }
            }

            List<ToolDefinition> toolDefinitions = [.. tools_ByName.Values.Select(x => x.ToolDefinition)];

            int steps = 0;
            int toolCalls = 0;
            int inputTokens = 0;
            int outputTokens = 0;
            int cacheReadInputTokens = 0;
            int cacheCreationInputTokens = 0;
            StopReason stopReason = StopReason.Undefined;
            ErrorCategory errorCategory = ErrorCategory.Undefined;
            string? errorMessage = null;

            if (conversation is null || httpClient is null || providerConfiguration is null || !Query.IsUsable(providerConfiguration))
            {
                errorCategory = ErrorCategory.InvalidConfiguration;
                errorMessage = "The conversation, HTTP client or provider is missing, or the provider is not usable.";
            }
            else
            {
                while (true)
                {
                    if (steps >= maxToolIterations)
                    {
                        errorCategory = ErrorCategory.MaxToolIterations;
                        errorMessage = string.Concat("The model kept calling tools after ", maxToolIterations.ToString(CultureInfo.InvariantCulture), " steps; the turn was stopped.");
                        break;
                    }

                    steps++;
                    await EmitAsync(new StepStartedEvent(steps, Milliseconds())).ConfigureAwait(false);

                    JsonObject? body = providerConfiguration.Protocol == Protocol.Anthropic
                        ? conversation.ToAnthropic_JsonObject(providerConfiguration, toolDefinitions, runOptions_Temp.SystemPrompt)
                        : conversation.ToOpenAI_JsonObject(providerConfiguration, toolDefinitions, runOptions_Temp.SystemPrompt);

                    CompletionResult completionResult = await httpClient.CompleteAsync(providerConfiguration, body, (harnessEvent, cancellationToken_Event) => EmitAsync(harnessEvent), stopwatch, cancellationToken).ConfigureAwait(false);

                    stopReason = completionResult.StopReason;
                    if (completionResult.Usage is Usage usage)
                    {
                        inputTokens += usage.InputTokens;
                        outputTokens += usage.OutputTokens;
                        cacheReadInputTokens += usage.CacheReadInputTokens;
                        cacheCreationInputTokens += usage.CacheCreationInputTokens;
                        await EmitAsync(new UsageEvent(usage, Milliseconds())).ConfigureAwait(false);
                    }

                    if (completionResult.ErrorCategory != ErrorCategory.Undefined || completionResult.Message is null)
                    {
                        errorCategory = completionResult.ErrorCategory == ErrorCategory.Undefined ? ErrorCategory.UpstreamFault : completionResult.ErrorCategory;
                        errorMessage = completionResult.ErrorMessage ?? "The model provider returned no message.";
                        break;
                    }

                    Message message = completionResult.Message;
                    List<ToolUseContent> toolUseContents = message.Contents?.OfType<ToolUseContent>().ToList() ?? [];

                    if (message.Contents is not null && message.Contents.Count != 0)
                    {
                        conversation.Add(message);
                    }

                    if (stopReason == StopReason.Refusal)
                    {
                        errorCategory = ErrorCategory.Refusal;
                        errorMessage = string.IsNullOrWhiteSpace(completionResult.ErrorMessage) ? "The model provider declined the request." : string.Concat("The model provider declined the request: ", completionResult.ErrorMessage);
                    }
                    else if (stopReason == StopReason.MaxTokens)
                    {
                        errorCategory = ErrorCategory.MaxTokens;
                        errorMessage = "The answer reached the maximum number of output tokens and was cut off.";
                    }

                    if (toolUseContents.Count == 0)
                    {
                        break;
                    }

                    if (errorCategory != ErrorCategory.Undefined)
                    {
                        conversation.Add(new Message(Role.User, toolUseContents.ConvertAll<IContent>(x => new ToolResultContent(x.Id, string.Concat("Not run: ", errorMessage), true))));
                        break;
                    }

                    ToolResultContent[] toolResultContents;
                    try
                    {
                        toolResultContents = await Task.WhenAll(toolUseContents.ConvertAll(InvokeAsync)).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                    {
                        conversation.Add(new Message(Role.User, toolUseContents.ConvertAll<IContent>(x => new ToolResultContent(x.Id, "Not run: the user cancelled the turn.", true))));
                        throw;
                    }

                    toolCalls += toolResultContents.Length;
                    conversation.Add(new Message(Role.User, toolResultContents));
                }
            }

            TurnResult turnResult = new(stopReason, errorCategory, errorMessage, steps, toolCalls, new Usage(inputTokens, outputTokens, cacheReadInputTokens, cacheCreationInputTokens), Milliseconds());

            Serilog.Modify.Log(
                "Harness: turn finished (Provider={Provider}, Model={Model}, Steps={Steps}, ToolCalls={ToolCalls}, InputTokens={InputTokens}, CacheReadInputTokens={CacheReadInputTokens}, OutputTokens={OutputTokens}, Milliseconds={Milliseconds}, Error={ErrorCategory}).",
                providerConfiguration?.Name ?? string.Empty,
                providerConfiguration?.Model ?? string.Empty,
                steps,
                toolCalls,
                inputTokens,
                cacheReadInputTokens,
                outputTokens,
                Math.Round(turnResult.TotalMilliseconds),
                errorCategory);

            if (errorCategory != ErrorCategory.Undefined)
            {
                await EmitAsync(new ErrorEvent(errorCategory, errorMessage, Milliseconds())).ConfigureAwait(false);
            }

            await EmitAsync(new TurnCompletedEvent(turnResult, Milliseconds())).ConfigureAwait(false);

            return turnResult;

            double Milliseconds()
            {
                return stopwatch.Elapsed.TotalMilliseconds;
            }

            async Task EmitAsync(HarnessEvent harnessEvent)
            {
                if (func is null)
                {
                    return;
                }

                await semaphoreSlim.WaitAsync(cancellationToken).ConfigureAwait(false);
                try
                {
                    await func(harnessEvent, cancellationToken).ConfigureAwait(false);
                }
                finally
                {
                    semaphoreSlim.Release();
                }
            }

            async Task<ToolResultContent> InvokeAsync(ToolUseContent toolUseContent)
            {
                double milliseconds_Start = Milliseconds();
                await EmitAsync(new ToolCallStartedEvent(toolUseContent.Id, toolUseContent.Name, toolUseContent.InputJson, milliseconds_Start)).ConfigureAwait(false);

                ToolResultContent toolResultContent;
                JsonObject? input = Query.Input(toolUseContent);
                if (toolUseContent.Name is null || !tools_ByName.TryGetValue(toolUseContent.Name, out ITool? tool))
                {
                    toolResultContent = new ToolResultContent(toolUseContent.Id, string.Concat("Unknown tool '", toolUseContent.Name, "'. Available tools: ", string.Join(", ", tools_ByName.Keys), "."), true);
                }
                else if (input is null)
                {
                    toolResultContent = new ToolResultContent(toolUseContent.Id, "The tool input is not a valid JSON object. Call the tool again with a complete JSON object.", true);
                }
                else if (MissingProperties(tool.ToolDefinition, input) is string missing)
                {
                    toolResultContent = new ToolResultContent(toolUseContent.Id, string.Concat("The tool input lacks required properties: ", missing, "."), true);
                }
                else
                {
                    try
                    {
                        toolResultContent = await tool.InvokeAsync(toolUseContent, cancellationToken).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                    {
                        throw;
                    }
                    catch (Exception exception)
                    {
                        Serilog.Modify.Log(exception, "Harness: tool {ToolName} failed.", toolUseContent.Name);
                        toolResultContent = new ToolResultContent(toolUseContent.Id, string.Concat("The tool failed: ", exception.GetType().Name, "."), true);
                    }
                }

                string text = toolResultContent.Text ?? string.Empty;
                int characters = text.Length;
                bool truncated = characters > maxToolResultCharacters;
                if (truncated)
                {
                    text = string.Concat(text[..maxToolResultCharacters], "\n[Truncated: ", maxToolResultCharacters.ToString(CultureInfo.InvariantCulture), " of ", characters.ToString(CultureInfo.InvariantCulture), " characters shown. Narrow the request to see the rest.]");
                }

                ToolResultContent result = new(toolUseContent.Id, text, toolResultContent.IsError);

                double milliseconds_End = Milliseconds();
                await EmitAsync(new ToolCallCompletedEvent(toolUseContent.Id, toolUseContent.Name, result.IsError, milliseconds_End - milliseconds_Start, characters, truncated, milliseconds_End)).ConfigureAwait(false);

                return result;
            }

            static string? MissingProperties(ToolDefinition toolDefinition, JsonObject input)
            {
                if (Query.InputSchema(toolDefinition)?["required"] is not JsonArray jsonArray_Required)
                {
                    return null;
                }

                List<string> missing = [];
                foreach (JsonNode? jsonNode in jsonArray_Required)
                {
                    if (jsonNode is JsonValue jsonValue && jsonValue.TryGetValue(out string? name) && name is not null && (!input.TryGetPropertyValue(name, out JsonNode? jsonNode_Value) || jsonNode_Value is null))
                    {
                        missing.Add(name);
                    }
                }

                return missing.Count == 0 ? null : string.Join(", ", missing);
            }
        }
    }
}
