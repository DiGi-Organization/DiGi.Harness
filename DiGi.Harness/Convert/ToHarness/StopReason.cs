using DiGi.Harness.Enums;

namespace DiGi.Harness
{
    public static partial class Convert
    {
        /// <summary>
        /// Maps a provider stop reason (Anthropic <c>stop_reason</c>, OpenAI <c>finish_reason</c>) to a <see cref="StopReason"/>.
        /// </summary>
        /// <param name="text">The provider value, such as <c>end_turn</c>, <c>tool_use</c>, <c>stop</c> or <c>tool_calls</c>.</param>
        /// <returns>The stop reason; <see cref="StopReason.Undefined"/> for null or empty, <see cref="StopReason.Other"/> for an unknown value.</returns>
        public static StopReason ToHarness_StopReason(this string? text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return StopReason.Undefined;
            }

            return text.Trim().ToLowerInvariant() switch
            {
                "end_turn" or "stop" or "stop_sequence" => StopReason.EndTurn,
                "tool_use" or "tool_calls" or "function_call" => StopReason.ToolUse,
                "max_tokens" or "length" or "model_context_window_exceeded" => StopReason.MaxTokens,
                "refusal" or "content_filter" => StopReason.Refusal,
                _ => StopReason.Other,
            };
        }
    }
}
