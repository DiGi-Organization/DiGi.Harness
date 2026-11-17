namespace DiGi.Harness.Enums
{
    /// <summary>
    /// The wire protocol used to talk to a model provider.
    /// </summary>
    public enum Protocol
    {
        /// <summary>
        /// The protocol is not set; a provider with this value is not usable.
        /// </summary>
        Undefined,

        /// <summary>
        /// The OpenAI Chat Completions protocol (<c>POST {BaseUri}/chat/completions</c>), used by DeepSeek, Xiaomi MiMo, LM Studio, Strata and other compatible servers.
        /// </summary>
        OpenAI,

        /// <summary>
        /// The Anthropic Messages protocol (<c>POST {BaseUri}/v1/messages</c>), used by Anthropic and by Anthropic-compatible endpoints.
        /// </summary>
        Anthropic,
    }
}
