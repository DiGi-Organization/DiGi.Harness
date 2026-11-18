using DiGi.Harness.Classes;
using DiGi.Harness.Enums;
using DiGi.Harness.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;

namespace DiGi.Harness
{
    public static partial class Convert
    {
        /// <summary>
        /// Builds the body of a streamed OpenAI Chat Completions request (<c>POST /chat/completions</c>) from a conversation.
        /// <para>Tool results become <c>role: tool</c> messages placed before any user text of the same message. Assistant tool calls carry their input as the <c>arguments</c> string. Reasoning is replayed as <c>reasoning_content</c> only when <see cref="ProviderConfiguration.ReplayReasoning"/> is set (DeepSeek thinking mode with tools needs it; most servers ignore or reject it). Effort goes to <c>reasoning_effort</c>; usage is requested with <c>stream_options.include_usage</c>.</para>
        /// </summary>
        /// <param name="conversation">The conversation.</param>
        /// <param name="providerConfiguration">The provider.</param>
        /// <param name="toolDefinitions">The tools offered to the model, or null for none.</param>
        /// <param name="systemPrompt">The system prompt, or null for none.</param>
        /// <param name="toolChoice">Whether the model may call the tools (<c>tool_choice</c> <c>"auto"</c> or <c>"none"</c>); <see cref="ToolChoice.Undefined"/> is <see cref="ToolChoice.Auto"/>. Ignored when no tools are offered.</param>
        /// <returns>The request body, or null when the conversation or provider is null.</returns>
        public static JsonObject? ToOpenAI_JsonObject(this Conversation? conversation, ProviderConfiguration? providerConfiguration, IEnumerable<ToolDefinition>? toolDefinitions, string? systemPrompt, ToolChoice toolChoice = ToolChoice.Undefined)
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
                ["stream_options"] = new JsonObject { ["include_usage"] = true },
            };

            JsonArray jsonArray_Messages = [];
            if (!string.IsNullOrWhiteSpace(systemPrompt))
            {
                jsonArray_Messages.Add(new JsonObject { ["role"] = "system", ["content"] = systemPrompt });
            }

            foreach (Message message in conversation.Messages)
            {
                if (message.Contents is null || message.Contents.Count == 0)
                {
                    continue;
                }

                if (message.Role == Role.Assistant)
                {
                    StringBuilder stringBuilder_Text = new();
                    StringBuilder stringBuilder_Reasoning = new();
                    JsonArray jsonArray_ToolCalls = [];
                    foreach (IContent content in message.Contents)
                    {
                        switch (content)
                        {
                            case TextContent textContent:
                                stringBuilder_Text.Append(textContent.Text);
                                break;

                            case ThinkingContent thinkingContent:
                                stringBuilder_Reasoning.Append(thinkingContent.Text);
                                break;

                            case ToolUseContent toolUseContent:
                                jsonArray_ToolCalls.Add(new JsonObject
                                {
                                    ["id"] = toolUseContent.Id,
                                    ["type"] = "function",
                                    ["function"] = new JsonObject
                                    {
                                        ["name"] = toolUseContent.Name,
                                        ["arguments"] = (Query.Input(toolUseContent) ?? []).ToJsonString(),
                                    },
                                });
                                break;
                        }
                    }

                    JsonObject jsonObject_Assistant = new()
                    {
                        ["role"] = "assistant",
                        ["content"] = stringBuilder_Text.Length == 0 ? null : stringBuilder_Text.ToString(),
                    };

                    if (jsonArray_ToolCalls.Count != 0)
                    {
                        jsonObject_Assistant["tool_calls"] = jsonArray_ToolCalls;
                    }

                    if (providerConfiguration.ReplayReasoning && stringBuilder_Reasoning.Length != 0)
                    {
                        jsonObject_Assistant["reasoning_content"] = stringBuilder_Reasoning.ToString();
                    }

                    if (stringBuilder_Text.Length != 0 || jsonArray_ToolCalls.Count != 0)
                    {
                        jsonArray_Messages.Add(jsonObject_Assistant);
                    }

                    continue;
                }

                StringBuilder stringBuilder_User = new();
                foreach (IContent content in message.Contents)
                {
                    switch (content)
                    {
                        case ToolResultContent toolResultContent:
                            string text = string.IsNullOrEmpty(toolResultContent.Text) ? "(empty)" : toolResultContent.Text;
                            jsonArray_Messages.Add(new JsonObject
                            {
                                ["role"] = "tool",
                                ["tool_call_id"] = toolResultContent.ToolUseId,
                                ["content"] = toolResultContent.IsError ? string.Concat("Error: ", text) : text,
                            });
                            break;

                        case TextContent textContent:
                            if (stringBuilder_User.Length != 0)
                            {
                                stringBuilder_User.Append("\n\n");
                            }

                            stringBuilder_User.Append(textContent.Text);
                            break;
                    }
                }

                if (stringBuilder_User.Length != 0)
                {
                    jsonArray_Messages.Add(new JsonObject { ["role"] = "user", ["content"] = stringBuilder_User.ToString() });
                }
            }

            result["messages"] = jsonArray_Messages;

            if (toolDefinitions is not null)
            {
                JsonArray jsonArray_Tools = [];
                foreach (ToolDefinition toolDefinition in toolDefinitions)
                {
                    jsonArray_Tools.Add(new JsonObject
                    {
                        ["type"] = "function",
                        ["function"] = new JsonObject
                        {
                            ["name"] = toolDefinition.Name,
                            ["description"] = toolDefinition.Description,
                            ["parameters"] = Query.InputSchema(toolDefinition),
                        },
                    });
                }

                if (jsonArray_Tools.Count != 0)
                {
                    result["tools"] = jsonArray_Tools;
                    result["tool_choice"] = toolChoice == ToolChoice.None ? "none" : "auto";
                }
            }

            if (!string.IsNullOrWhiteSpace(providerConfiguration.Effort))
            {
                result["reasoning_effort"] = providerConfiguration.Effort.Trim().ToLowerInvariant();
            }

            return result;
        }
    }
}
