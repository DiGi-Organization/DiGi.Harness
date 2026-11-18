namespace DiGi.Harness.Enums
{
    /// <summary>
    /// Whether the model may call the tools offered in a request. The tools stay in the request either way: Anthropic rejects a conversation holding tool calls and results when no tools are defined.
    /// </summary>
    public enum ToolChoice
    {
        /// <summary>
        /// Not set; treated as <see cref="Auto"/>.
        /// </summary>
        Undefined,

        /// <summary>
        /// The model decides whether to call a tool (<c>tool_choice: auto</c>).
        /// </summary>
        Auto,

        /// <summary>
        /// The model must answer without calling a tool (<c>tool_choice: none</c>). Some OpenAI-compatible servers ignore it, so a tool call can still come back.
        /// </summary>
        None,
    }
}
