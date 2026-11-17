namespace DiGi.Harness.Enums
{
    /// <summary>
    /// The kind of content block being accumulated from a stream.
    /// </summary>
    public enum ContentKind
    {
        /// <summary>
        /// Not set.
        /// </summary>
        Undefined,

        /// <summary>
        /// Answer text.
        /// </summary>
        Text,

        /// <summary>
        /// Thinking or reasoning text.
        /// </summary>
        Thinking,

        /// <summary>
        /// An Anthropic <c>redacted_thinking</c> block.
        /// </summary>
        RedactedThinking,

        /// <summary>
        /// A tool call.
        /// </summary>
        ToolUse,
    }
}
