using DiGi.Harness.Classes;
using DiGi.Harness.Enums;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace DiGi.Harness
{
    public static partial class Modify
    {
        /// <summary>
        /// Applies one OpenAI Chat Completions stream chunk to the state of a response and returns the events to emit.
        /// <para>Reads the first choice's <c>delta.content</c>, <c>delta.reasoning_content</c> or <c>delta.reasoning</c> (DeepSeek, LM Studio and others), indexed <c>delta.tool_calls</c> fragments (the id and name arrive once, the <c>arguments</c> string in pieces), <c>finish_reason</c>, <c>usage</c> and an <c>error</c> object. Reasoning is kept at position 0, text at 1 and tool call <c>i</c> at <c>2 + i</c>, so the message lists them in that order; the reasoning block completes when text or a tool call starts.</para>
        /// </summary>
        /// <param name="completionState">The response state.</param>
        /// <param name="jsonObject">The parsed <c>data</c> of the chunk.</param>
        /// <param name="elapsedMilliseconds">The time elapsed since the turn started, stamped on the returned events.</param>
        /// <returns>The events to emit (text and thinking deltas, completed thinking); empty when there are none.</returns>
        public static List<HarnessEvent> Update_OpenAI(this CompletionState? completionState, JsonObject? jsonObject, double elapsedMilliseconds)
        {
            List<HarnessEvent> result = [];
            if (completionState is null || jsonObject is null)
            {
                return result;
            }

            if (jsonObject["error"] is JsonNode jsonNode_Error)
            {
                completionState.ErrorMessage = Text(jsonNode_Error["message"]) ?? jsonNode_Error.ToJsonString();
            }

            if (jsonObject["usage"] is JsonObject jsonObject_Usage)
            {
                int cachedTokens = Integer(jsonObject_Usage["prompt_tokens_details"]?["cached_tokens"]);
                completionState.InputTokens = Integer(jsonObject_Usage["prompt_tokens"]) - cachedTokens;
                completionState.CacheReadInputTokens = cachedTokens;
                completionState.OutputTokens = Integer(jsonObject_Usage["completion_tokens"]);
            }

            if (jsonObject["choices"] is not JsonArray jsonArray_Choices || jsonArray_Choices.Count == 0 || jsonArray_Choices[0] is not JsonObject jsonObject_Choice)
            {
                return result;
            }

            JsonNode? jsonNode_Delta = jsonObject_Choice["delta"];

            string? reasoning = Text(jsonNode_Delta?["reasoning_content"]) ?? Text(jsonNode_Delta?["reasoning"]);
            if (!string.IsNullOrEmpty(reasoning))
            {
                if (!completionState.ContentStates.TryGetValue(0, out ContentState? contentState_Reasoning))
                {
                    contentState_Reasoning = new ContentState(ContentKind.Thinking);
                    completionState.ContentStates[0] = contentState_Reasoning;
                }

                contentState_Reasoning.StringBuilder.Append(reasoning);
                result.Add(new ThinkingDeltaEvent(reasoning, elapsedMilliseconds));
            }

            string? content = Text(jsonNode_Delta?["content"]);
            if (!string.IsNullOrEmpty(content))
            {
                CompleteReasoning(completionState, result, elapsedMilliseconds);
                if (!completionState.ContentStates.TryGetValue(1, out ContentState? contentState_Text))
                {
                    contentState_Text = new ContentState(ContentKind.Text);
                    completionState.ContentStates[1] = contentState_Text;
                }

                contentState_Text.StringBuilder.Append(content);
                result.Add(new TextDeltaEvent(content, elapsedMilliseconds));
            }

            if (jsonNode_Delta?["tool_calls"] is JsonArray jsonArray_ToolCalls)
            {
                CompleteReasoning(completionState, result, elapsedMilliseconds);
                foreach (JsonNode? jsonNode_ToolCall in jsonArray_ToolCalls)
                {
                    if (jsonNode_ToolCall is null)
                    {
                        continue;
                    }

                    int key = 2 + Integer(jsonNode_ToolCall["index"]);
                    if (!completionState.ContentStates.TryGetValue(key, out ContentState? contentState_ToolCall))
                    {
                        contentState_ToolCall = new ContentState(ContentKind.ToolUse);
                        completionState.ContentStates[key] = contentState_ToolCall;
                    }

                    string? id = Text(jsonNode_ToolCall["id"]);
                    if (!string.IsNullOrEmpty(id))
                    {
                        contentState_ToolCall.Id = id;
                    }

                    string? name = Text(jsonNode_ToolCall["function"]?["name"]);
                    if (!string.IsNullOrEmpty(name))
                    {
                        contentState_ToolCall.Name = string.Concat(contentState_ToolCall.Name, name);
                    }

                    contentState_ToolCall.StringBuilder.Append(Text(jsonNode_ToolCall["function"]?["arguments"]));
                }
            }

            string? finishReason = Text(jsonObject_Choice["finish_reason"]);
            if (!string.IsNullOrEmpty(finishReason))
            {
                CompleteReasoning(completionState, result, elapsedMilliseconds);
                completionState.StopReason = Convert.ToHarness_StopReason(finishReason);

                int number = 0;
                foreach (KeyValuePair<int, ContentState> keyValuePair in completionState.ContentStates)
                {
                    keyValuePair.Value.Completed = true;
                    if (keyValuePair.Value.ContentKind == ContentKind.ToolUse && string.IsNullOrEmpty(keyValuePair.Value.Id))
                    {
                        keyValuePair.Value.Id = string.Concat("call_", number.ToString(System.Globalization.CultureInfo.InvariantCulture), "_", System.Guid.NewGuid().ToString("N"));
                    }

                    number++;
                }
            }

            return result;

            static void CompleteReasoning(CompletionState completionState, List<HarnessEvent> harnessEvents, double elapsedMilliseconds)
            {
                if (completionState.ContentStates.TryGetValue(0, out ContentState? contentState) && !contentState.Completed)
                {
                    contentState.Completed = true;
                    if (contentState.StringBuilder.Length != 0)
                    {
                        harnessEvents.Add(new ThinkingCompletedEvent(contentState.StringBuilder.ToString(), elapsedMilliseconds));
                    }
                }
            }

            static string? Text(JsonNode? jsonNode)
            {
                return jsonNode is JsonValue jsonValue && jsonValue.TryGetValue(out string? @string) ? @string : null;
            }

            static int Integer(JsonNode? jsonNode)
            {
                return jsonNode is JsonValue jsonValue && jsonValue.TryGetValue(out int @int) ? @int : 0;
            }
        }
    }
}
