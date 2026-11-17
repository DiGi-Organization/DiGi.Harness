namespace DiGi.Harness.Enums
{
    /// <summary>
    /// Why the model stopped producing output for one request.
    /// </summary>
    public enum StopReason
    {
        /// <summary>
        /// No stop reason was reported.
        /// </summary>
        Undefined,

        /// <summary>
        /// The model finished its answer.
        /// </summary>
        EndTurn,

        /// <summary>
        /// The model stopped to call one or more tools.
        /// </summary>
        ToolUse,

        /// <summary>
        /// The output reached the configured maximum number of tokens.
        /// </summary>
        MaxTokens,

        /// <summary>
        /// The provider declined the request (Anthropic <c>refusal</c>, OpenAI <c>content_filter</c>).
        /// </summary>
        Refusal,

        /// <summary>
        /// Any other reason reported by the provider.
        /// </summary>
        Other,
    }
}
