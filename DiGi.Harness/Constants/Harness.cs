namespace DiGi.Harness.Constants
{
    /// <summary>
    /// File names used by DiGi.Harness.
    /// </summary>
    public static class FileName
    {
        /// <summary>
        /// The JSON configuration file holding the providers and limits; the real one, with keys, belongs in <c>user files/</c>.
        /// </summary>
        public const string Harness = "Harness.json";
    }

    /// <summary>
    /// Wire constants of the Anthropic Messages protocol.
    /// </summary>
    public static class Anthropic
    {
        /// <summary>
        /// The relative path of the Messages endpoint, appended to the provider base URI.
        /// </summary>
        public const string MessagesPath = "v1/messages";

        /// <summary>
        /// The value of the <c>anthropic-version</c> header.
        /// </summary>
        public const string Version = "2023-06-01";

        /// <summary>
        /// The beta flag enabling server-side refusal fallbacks (<c>fallbacks: "default"</c>).
        /// </summary>
        public const string FallbackBeta = "server-side-fallback-2026-07-01";
    }

    /// <summary>
    /// Wire constants of the OpenAI Chat Completions protocol.
    /// </summary>
    public static class OpenAI
    {
        /// <summary>
        /// The relative path of the Chat Completions endpoint, appended to the provider base URI (which normally ends in <c>/v1</c>).
        /// </summary>
        public const string ChatCompletionsPath = "chat/completions";

        /// <summary>
        /// The data line that ends an OpenAI stream.
        /// </summary>
        public const string Done = "[DONE]";
    }

    /// <summary>
    /// Names of the tools shipped with DiGi.Harness.
    /// </summary>
    public static class ToolName
    {
        /// <summary>
        /// The tool returning one WebAPI operation's parameters and schemas.
        /// </summary>
        public const string DescribeEndpoint = "describe_endpoint";

        /// <summary>
        /// The tool calling one WebAPI operation.
        /// </summary>
        public const string CallEndpoint = "call_endpoint";
    }

    /// <summary>
    /// Default limits used when the configuration does not set them.
    /// </summary>
    public static class Default
    {
        /// <summary>
        /// The default maximum number of steps in one turn in which the model may call tools. A model still calling tools after the last of them gets one more request with tool use turned off (<see cref="FinalStepPrompt"/>), so a turn makes at most this many requests plus one.
        /// </summary>
        public const int MaxToolIterations = 12;

        /// <summary>
        /// The instruction appended to the system prompt of the one tool-less request that follows the last allowed tool step, asking the model to answer from what the tools already returned.
        /// </summary>
        public const string FinalStepPrompt = "## Tool budget used\n\nThe tool budget for this turn is used up and no more tools can be called. Answer the user now, in the language of the question, from the tool results above only: what was found, and what is still unknown or unchecked. Do not invent figures and do not call tools.";

        /// <summary>
        /// The default maximum number of characters of one tool result returned to the model.
        /// </summary>
        public const int MaxToolResultCharacters = 20000;

        /// <summary>
        /// The default maximum number of output tokens of one model request.
        /// </summary>
        public const int MaxTokens = 16000;

        /// <summary>
        /// The default timeout of one model request, in seconds.
        /// </summary>
        public const int RequestTimeoutSeconds = 300;

        /// <summary>
        /// The maximum number of characters of an upstream error body quoted in an error message.
        /// </summary>
        public const int MaxErrorCharacters = 500;

        /// <summary>
        /// The maximum number of characters of an operation summary in the OpenAPI index.
        /// </summary>
        public const int MaxSummaryCharacters = 160;
    }
}
