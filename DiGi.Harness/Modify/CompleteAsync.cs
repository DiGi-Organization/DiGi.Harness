using DiGi.Harness.Classes;
using DiGi.Harness.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.Harness
{
    public static partial class Modify
    {
        /// <summary>
        /// Sends one streamed model request and reads the response to its end, emitting text and thinking events as they arrive.
        /// <para>Failures are returned, not thrown: no answer (connection failure, timeout, a dropped stream) is <see cref="ErrorCategory.Unavailable"/>; a failure status or an error event inside the stream is <see cref="ErrorCategory.UpstreamFault"/>. Error messages quote at most a short part of the upstream body and never the key. Only a requested cancellation is rethrown.</para>
        /// </summary>
        /// <param name="httpClient">The HTTP client; its timeout bounds the whole request.</param>
        /// <param name="providerConfiguration">The provider.</param>
        /// <param name="body">The request body for the provider's protocol.</param>
        /// <param name="func">The handler receiving text and thinking events, or null.</param>
        /// <param name="stopwatch">The stopwatch of the turn, used to stamp events; null stamps zero.</param>
        /// <param name="cancellationToken">The token that cancels the request.</param>
        /// <returns>The completion result.</returns>
        public static async Task<CompletionResult> CompleteAsync(this HttpClient? httpClient, ProviderConfiguration? providerConfiguration, JsonObject? body, Func<HarnessEvent, CancellationToken, Task>? func, Stopwatch? stopwatch, CancellationToken cancellationToken = default)
        {
            if (httpClient is null || providerConfiguration is null)
            {
                return new CompletionResult(null, StopReason.Undefined, null, ErrorCategory.InvalidConfiguration, "No HTTP client or provider.");
            }

            using HttpRequestMessage? httpRequestMessage = Create.HttpRequestMessage(providerConfiguration, body);
            if (httpRequestMessage is null)
            {
                return new CompletionResult(null, StopReason.Undefined, null, ErrorCategory.InvalidConfiguration, string.Concat("Provider '", providerConfiguration.Name, "' is not usable (protocol, base URI or model missing, or disabled)."));
            }

            HttpResponseMessage httpResponseMessage;
            try
            {
                httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                throw;
            }
            catch (Exception exception) when (exception is HttpRequestException or TaskCanceledException or IOException)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Harness: provider {Provider} gave no answer ({Error}).", providerConfiguration.Name ?? string.Empty, exception.GetType().Name);
                return new CompletionResult(null, StopReason.Undefined, null, ErrorCategory.Unavailable, string.Concat("The model provider did not answer (", exception is TaskCanceledException ? "timeout" : exception.GetType().Name, ")."));
            }

            using (httpResponseMessage)
            {
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    string text = string.Empty;
                    try
                    {
                        text = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                    {
                        throw;
                    }
                    catch (Exception exception) when (exception is HttpRequestException or IOException or TaskCanceledException)
                    {
                    }

                    string? message = null;
                    try
                    {
                        JsonNode? jsonNode = JsonNode.Parse(text);
                        message = (jsonNode?["error"]?["message"] ?? jsonNode?["message"] ?? jsonNode?["error"]) is JsonValue jsonValue && jsonValue.TryGetValue(out string? message_Temp) ? message_Temp : null;
                    }
                    catch (JsonException)
                    {
                    }

                    message ??= text;
                    if (message.Length > Constants.Default.MaxErrorCharacters)
                    {
                        message = string.Concat(message[..Constants.Default.MaxErrorCharacters], "…");
                    }

                    int statusCode = (int)httpResponseMessage.StatusCode;
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Harness: provider {Provider} answered {StatusCode}.", providerConfiguration.Name ?? string.Empty, statusCode);
                    return new CompletionResult(null, StopReason.Undefined, null, ErrorCategory.UpstreamFault, string.Concat("The model provider answered ", statusCode.ToString(System.Globalization.CultureInfo.InvariantCulture), ": ", message));
                }

                CompletionState completionState = new(providerConfiguration.Protocol);
                try
                {
                    using Stream stream = await httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                    await stream.ReadServerSentEventsAsync(async (serverSentEvent, cancellationToken_Event) =>
                    {
                        if (string.IsNullOrWhiteSpace(serverSentEvent.Data) || serverSentEvent.Data == Constants.OpenAI.Done)
                        {
                            return;
                        }

                        JsonObject? jsonObject;
                        try
                        {
                            jsonObject = JsonNode.Parse(serverSentEvent.Data) as JsonObject;
                        }
                        catch (JsonException)
                        {
                            return;
                        }

                        double elapsedMilliseconds = stopwatch?.Elapsed.TotalMilliseconds ?? 0;
                        List<HarnessEvent> harnessEvents = providerConfiguration.Protocol == Protocol.Anthropic
                            ? completionState.Update_Anthropic(jsonObject, elapsedMilliseconds)
                            : completionState.Update_OpenAI(jsonObject, elapsedMilliseconds);

                        if (func is not null)
                        {
                            foreach (HarnessEvent harnessEvent in harnessEvents)
                            {
                                await func(harnessEvent, cancellationToken_Event).ConfigureAwait(false);
                            }
                        }
                    }, cancellationToken).ConfigureAwait(false);
                }
                catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                {
                    throw;
                }
                catch (Exception exception) when (exception is HttpRequestException or IOException or TaskCanceledException)
                {
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Harness: stream from provider {Provider} broke off ({Error}).", providerConfiguration.Name ?? string.Empty, exception.GetType().Name);
                    return new CompletionResult(null, StopReason.Undefined, null, ErrorCategory.Unavailable, "The connection to the model provider dropped while the answer was streaming.");
                }

                Usage usage = new(completionState.InputTokens, completionState.OutputTokens, completionState.CacheReadInputTokens, completionState.CacheCreationInputTokens);

                if (!string.IsNullOrEmpty(completionState.ErrorMessage))
                {
                    string message = completionState.ErrorMessage.Length > Constants.Default.MaxErrorCharacters ? string.Concat(completionState.ErrorMessage[..Constants.Default.MaxErrorCharacters], "…") : completionState.ErrorMessage;
                    return new CompletionResult(null, completionState.StopReason, usage, ErrorCategory.UpstreamFault, string.Concat("The model provider reported an error: ", message));
                }

                return new CompletionResult(Convert.ToHarness_Message(completionState), completionState.StopReason, usage, ErrorCategory.Undefined, completionState.RefusalMessage);
            }
        }
    }
}
