using DiGi.Harness.Classes;
using DiGi.Harness.Enums;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace DiGi.Harness
{
    public static partial class Modify
    {
        /// <summary>
        /// Applies one Anthropic Messages stream event to the state of a response and returns the events to emit.
        /// <para>Handles <c>message_start</c> (usage), <c>content_block_start</c> (text, thinking, redacted_thinking, tool_use), <c>content_block_delta</c> (<c>text_delta</c>, <c>thinking_delta</c>, <c>signature_delta</c>, <c>input_json_delta</c>), <c>content_block_stop</c>, <c>message_delta</c> (stop reason, refusal details, output usage) and <c>error</c>. Unknown events and block types are ignored.</para>
        /// </summary>
        /// <param name="completionState">The response state.</param>
        /// <param name="jsonObject">The parsed <c>data</c> of the event.</param>
        /// <param name="elapsedMilliseconds">The time elapsed since the turn started, stamped on the returned events.</param>
        /// <returns>The events to emit (text and thinking deltas, completed thinking blocks); empty when there are none.</returns>
        public static List<HarnessEvent> Update_Anthropic(this CompletionState? completionState, JsonObject? jsonObject, double elapsedMilliseconds)
        {
            List<HarnessEvent> result = [];
            if (completionState is null || jsonObject is null)
            {
                return result;
            }

            string? type = Text(jsonObject["type"]);
            int index = Integer(jsonObject["index"]);

            switch (type)
            {
                case "message_start":
                    if (jsonObject["message"]?["usage"] is JsonObject jsonObject_Usage)
                    {
                        completionState.InputTokens = Integer(jsonObject_Usage["input_tokens"]);
                        completionState.OutputTokens = Integer(jsonObject_Usage["output_tokens"]);
                        completionState.CacheReadInputTokens = Integer(jsonObject_Usage["cache_read_input_tokens"]);
                        completionState.CacheCreationInputTokens = Integer(jsonObject_Usage["cache_creation_input_tokens"]);
                    }

                    break;

                case "content_block_start":
                    JsonNode? jsonNode_Block = jsonObject["content_block"];
                    switch (Text(jsonNode_Block?["type"]))
                    {
                        case "text":
                            ContentState contentState_Text = new(ContentKind.Text);
                            contentState_Text.StringBuilder.Append(Text(jsonNode_Block?["text"]));
                            completionState.ContentStates[index] = contentState_Text;
                            if (contentState_Text.StringBuilder.Length != 0)
                            {
                                result.Add(new TextDeltaEvent(contentState_Text.StringBuilder.ToString(), elapsedMilliseconds));
                            }

                            break;

                        case "thinking":
                            ContentState contentState_Thinking = new(ContentKind.Thinking);
                            contentState_Thinking.StringBuilder.Append(Text(jsonNode_Block?["thinking"]));
                            contentState_Thinking.Signature = Text(jsonNode_Block?["signature"]);
                            completionState.ContentStates[index] = contentState_Thinking;
                            break;

                        case "redacted_thinking":
                            completionState.ContentStates[index] = new ContentState(ContentKind.RedactedThinking)
                            {
                                RedactedData = Text(jsonNode_Block?["data"]),
                            };
                            break;

                        case "tool_use":
                            completionState.ContentStates[index] = new ContentState(ContentKind.ToolUse)
                            {
                                Id = Text(jsonNode_Block?["id"]),
                                Name = Text(jsonNode_Block?["name"]),
                            };
                            break;
                    }

                    break;

                case "content_block_delta":
                    if (!completionState.ContentStates.TryGetValue(index, out ContentState? contentState_Delta))
                    {
                        break;
                    }

                    JsonNode? jsonNode_Delta = jsonObject["delta"];
                    switch (Text(jsonNode_Delta?["type"]))
                    {
                        case "text_delta":
                            string? text = Text(jsonNode_Delta?["text"]);
                            if (!string.IsNullOrEmpty(text))
                            {
                                contentState_Delta.StringBuilder.Append(text);
                                result.Add(new TextDeltaEvent(text, elapsedMilliseconds));
                            }

                            break;

                        case "thinking_delta":
                            string? thinking = Text(jsonNode_Delta?["thinking"]);
                            if (!string.IsNullOrEmpty(thinking))
                            {
                                contentState_Delta.StringBuilder.Append(thinking);
                                result.Add(new ThinkingDeltaEvent(thinking, elapsedMilliseconds));
                            }

                            break;

                        case "signature_delta":
                            contentState_Delta.Signature = string.Concat(contentState_Delta.Signature, Text(jsonNode_Delta?["signature"]));
                            break;

                        case "input_json_delta":
                            contentState_Delta.StringBuilder.Append(Text(jsonNode_Delta?["partial_json"]));
                            break;
                    }

                    break;

                case "content_block_stop":
                    if (completionState.ContentStates.TryGetValue(index, out ContentState? contentState_Stop))
                    {
                        contentState_Stop.Completed = true;
                        if (contentState_Stop.ContentKind == ContentKind.Thinking && contentState_Stop.StringBuilder.Length != 0)
                        {
                            result.Add(new ThinkingCompletedEvent(contentState_Stop.StringBuilder.ToString(), elapsedMilliseconds));
                        }
                    }

                    break;

                case "message_delta":
                    string? stopReason = Text(jsonObject["delta"]?["stop_reason"]);
                    if (stopReason is not null)
                    {
                        completionState.StopReason = Convert.ToHarness_StopReason(stopReason);
                    }

                    string? explanation = Text(jsonObject["delta"]?["stop_details"]?["explanation"]) ?? Text(jsonObject["delta"]?["stop_details"]?["category"]);
                    if (explanation is not null)
                    {
                        completionState.RefusalMessage = explanation;
                    }

                    if (jsonObject["usage"]?["output_tokens"] is JsonNode jsonNode_OutputTokens)
                    {
                        completionState.OutputTokens = Integer(jsonNode_OutputTokens);
                    }

                    break;

                case "error":
                    completionState.ErrorMessage = string.Concat(Text(jsonObject["error"]?["type"]) ?? "error", ": ", Text(jsonObject["error"]?["message"]));
                    break;
            }

            return result;

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
