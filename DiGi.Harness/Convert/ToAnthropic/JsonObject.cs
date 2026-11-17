using DiGi.Harness.Classes;
using DiGi.Harness.Enums;
using DiGi.Harness.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace DiGi.Harness
{
    public static partial class Convert
    {
        /// <summary>
        /// Builds the body of a streamed Anthropic Messages request (<c>POST /v1/messages</c>) from a conversation.
        /// <para>The system prompt is one cached text block (<c>cache_control: ephemeral</c>), so the tools and the system prompt form a stable cached prefix. Tools use <c>tool_choice: auto</c> (forced tool choice is rejected by current models). Thinking is <c>{"type":"adaptive","display":"summarized"}</c> when <see cref="ProviderConfiguration.Thinking"/> is set; effort goes to <c>output_config.effort</c>; <c>fallbacks: "default"</c> is sent when <see cref="ProviderConfiguration.AnthropicFallbacks"/> is set. Thinking blocks are replayed unchanged with their signatures.</para>
        /// </summary>
        /// <param name="conversation">The conversation.</param>
        /// <param name="providerConfiguration">The provider.</param>
        /// <param name="toolDefinitions">The tools offered to the model, or null for none.</param>
        /// <param name="systemPrompt">The system prompt, or null for none.</param>
        /// <returns>The request body, or null when the conversation or provider is null.</returns>
        public static JsonObject? ToAnthropic_JsonObject(this Conversation? conversation, ProviderConfiguration? providerConfiguration, IEnumerable<ToolDefinition>? toolDefinitions, string? systemPrompt)
        {
            if (conversation is null || providerConfiguration is null)
            {
                return null;
            }

            JsonObject result = new()
            {
                ["model"] = providerConfiguration.Model,
                ["max_tokens"] = providerConfiguration.MaxTokens > 0 ? providerConfiguration.MaxTokens : Constants.Default.MaxTokens,
                ["stream"] = true,
            };

            if (!string.IsNullOrWhiteSpace(systemPrompt))
            {
                result["system"] = new JsonArray
                {
                    new JsonObject
                    {
                        ["type"] = "text",
                        ["text"] = systemPrompt,
                        ["cache_control"] = new JsonObject { ["type"] = "ephemeral" },
                    },
                };
            }

            JsonArray jsonArray_Messages = [];
            foreach (Message message in conversation.Messages)
            {
                if (message.Contents is null || message.Contents.Count == 0)
                {
                    continue;
                }

                JsonArray jsonArray_Content = [];
                foreach (IContent content in message.Contents)
                {
                    switch (content)
                    {
                        case TextContent textContent:
                            if (!string.IsNullOrEmpty(textContent.Text))
                            {
                                jsonArray_Content.Add(new JsonObject { ["type"] = "text", ["text"] = textContent.Text });
                            }

                            break;

                        case ThinkingContent thinkingContent:
                            if (message.Role != Role.Assistant)
                            {
                                break;
                            }

                            if (!string.IsNullOrEmpty(thinkingContent.RedactedData))
                            {
                                jsonArray_Content.Add(new JsonObject { ["type"] = "redacted_thinking", ["data"] = thinkingContent.RedactedData });
                            }
                            else if (!string.IsNullOrEmpty(thinkingContent.Signature))
                            {
                                jsonArray_Content.Add(new JsonObject { ["type"] = "thinking", ["thinking"] = thinkingContent.Text ?? string.Empty, ["signature"] = thinkingContent.Signature });
                            }

                            break;

                        case ToolUseContent toolUseContent:
                            jsonArray_Content.Add(new JsonObject
                            {
                                ["type"] = "tool_use",
                                ["id"] = toolUseContent.Id,
                                ["name"] = toolUseContent.Name,
                                ["input"] = Query.Input(toolUseContent) ?? [],
                            });
                            break;

                        case ToolResultContent toolResultContent:
                            JsonObject jsonObject_ToolResult = new()
                            {
                                ["type"] = "tool_result",
                                ["tool_use_id"] = toolResultContent.ToolUseId,
                                ["content"] = string.IsNullOrEmpty(toolResultContent.Text) ? "(empty)" : toolResultContent.Text,
                            };

                            if (toolResultContent.IsError)
                            {
                                jsonObject_ToolResult["is_error"] = true;
                            }

                            jsonArray_Content.Add(jsonObject_ToolResult);
                            break;
                    }
                }

                if (jsonArray_Content.Count == 0)
                {
                    continue;
                }

                jsonArray_Messages.Add(new JsonObject
                {
                    ["role"] = message.Role == Role.Assistant ? "assistant" : "user",
                    ["content"] = jsonArray_Content,
                });
            }

            result["messages"] = jsonArray_Messages;

            if (toolDefinitions is not null)
            {
                JsonArray jsonArray_Tools = [];
                foreach (ToolDefinition toolDefinition in toolDefinitions)
                {
                    jsonArray_Tools.Add(new JsonObject
                    {
                        ["name"] = toolDefinition.Name,
                        ["description"] = toolDefinition.Description,
                        ["input_schema"] = Query.InputSchema(toolDefinition),
                    });
                }

                if (jsonArray_Tools.Count != 0)
                {
                    result["tools"] = jsonArray_Tools;
                    result["tool_choice"] = new JsonObject { ["type"] = "auto" };
                }
            }

            if (providerConfiguration.Thinking)
            {
                result["thinking"] = new JsonObject { ["type"] = "adaptive", ["display"] = "summarized" };
            }

            if (!string.IsNullOrWhiteSpace(providerConfiguration.Effort))
            {
                result["output_config"] = new JsonObject { ["effort"] = providerConfiguration.Effort.Trim().ToLowerInvariant() };
            }

            if (providerConfiguration.AnthropicFallbacks)
            {
                result["fallbacks"] = "default";
            }

            return result;
        }
    }
}
