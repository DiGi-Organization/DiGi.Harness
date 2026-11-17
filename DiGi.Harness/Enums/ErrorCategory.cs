namespace DiGi.Harness.Enums
{
    /// <summary>
    /// Why a turn did not finish normally.
    /// </summary>
    public enum ErrorCategory
    {
        /// <summary>
        /// No error.
        /// </summary>
        Undefined,

        /// <summary>
        /// The provider gave no answer (unreachable, timed out, or the connection dropped); the WebAPI equivalent is 503.
        /// </summary>
        Unavailable,

        /// <summary>
        /// The provider answered with a failure status or an error event; the WebAPI equivalent is 502.
        /// </summary>
        UpstreamFault,

        /// <summary>
        /// The provider declined the request.
        /// </summary>
        Refusal,

        /// <summary>
        /// The answer was cut off at the maximum number of output tokens.
        /// </summary>
        MaxTokens,

        /// <summary>
        /// The model kept calling tools beyond the configured iteration limit.
        /// </summary>
        MaxToolIterations,

        /// <summary>
        /// The provider configuration is incomplete (no base URI, model or protocol).
        /// </summary>
        InvalidConfiguration,
    }
}
