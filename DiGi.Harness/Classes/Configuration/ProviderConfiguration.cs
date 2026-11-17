using DiGi.Core.Classes;
using DiGi.Harness.Enums;
using DiGi.Harness.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// One model provider: where it is, which protocol it speaks, which model it runs and how it is called.
    /// <para>Anthropic, DeepSeek, Xiaomi MiMo, LM Studio and Strata are all configured with this one type; only <see cref="Protocol"/>, <see cref="BaseUri"/> and <see cref="Model"/> differ.</para>
    /// </summary>
    public class ProviderConfiguration : SerializableObject, IHarnessSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Name))]
        private readonly string? name;

        [JsonInclude, JsonPropertyName(nameof(DisplayName))]
        private readonly string? displayName;

        [JsonInclude, JsonPropertyName(nameof(Protocol))]
        private readonly Protocol protocol;

        [JsonInclude, JsonPropertyName(nameof(BaseUri))]
        private readonly string? baseUri;

        [JsonInclude, JsonPropertyName(nameof(Model))]
        private readonly string? model;

        [JsonInclude, JsonPropertyName(nameof(Key))]
        private readonly string? key;

        [JsonInclude, JsonPropertyName(nameof(KeyEnvironmentVariable))]
        private readonly string? keyEnvironmentVariable;

        [JsonInclude, JsonPropertyName(nameof(MaxTokens))]
        private readonly int maxTokens;

        [JsonInclude, JsonPropertyName(nameof(Effort))]
        private readonly string? effort;

        [JsonInclude, JsonPropertyName(nameof(Thinking))]
        private readonly bool thinking;

        [JsonInclude, JsonPropertyName(nameof(ReplayReasoning))]
        private readonly bool replayReasoning;

        [JsonInclude, JsonPropertyName(nameof(AnthropicFallbacks))]
        private readonly bool anthropicFallbacks;

        [JsonInclude, JsonPropertyName(nameof(Enabled))]
        private readonly bool enabled;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderConfiguration"/> class.
        /// </summary>
        /// <param name="name">The unique name clients select the provider by.</param>
        /// <param name="displayName">The name shown to users.</param>
        /// <param name="protocol">The wire protocol.</param>
        /// <param name="baseUri">The base URI: for <see cref="Protocol.Anthropic"/> without <c>/v1</c> (<c>https://api.anthropic.com</c>), for <see cref="Protocol.OpenAI"/> including it (<c>http://localhost:1234/v1</c>).</param>
        /// <param name="model">The model identifier sent to the provider.</param>
        /// <param name="key">The API key, or null for a local server that needs none.</param>
        /// <param name="keyEnvironmentVariable">The environment variable holding the API key, read when <paramref name="key"/> is empty.</param>
        /// <param name="maxTokens">The maximum number of output tokens of one request; zero or less uses the default.</param>
        /// <param name="effort">The effort level (<c>low</c> to <c>max</c>), sent as <c>output_config.effort</c> (Anthropic) or <c>reasoning_effort</c> (OpenAI); null sends nothing.</param>
        /// <param name="thinking">Whether summarized adaptive thinking is requested (Anthropic protocol only).</param>
        /// <param name="replayReasoning">Whether reasoning text is sent back as <c>reasoning_content</c> (OpenAI protocol; DeepSeek thinking mode with tools needs it).</param>
        /// <param name="anthropicFallbacks">Whether server-side refusal fallbacks are requested (Anthropic first-party API only; compatible endpoints reject the field).</param>
        /// <param name="enabled">Whether the provider can be selected.</param>
        public ProviderConfiguration(
            string? name,
            string? displayName,
            Protocol protocol,
            string? baseUri,
            string? model,
            string? key,
            string? keyEnvironmentVariable,
            int maxTokens,
            string? effort,
            bool thinking,
            bool replayReasoning,
            bool anthropicFallbacks,
            bool enabled)
        {
            this.name = name;
            this.displayName = displayName;
            this.protocol = protocol;
            this.baseUri = baseUri;
            this.model = model;
            this.key = key;
            this.keyEnvironmentVariable = keyEnvironmentVariable;
            this.maxTokens = maxTokens;
            this.effort = effort;
            this.thinking = thinking;
            this.replayReasoning = replayReasoning;
            this.anthropicFallbacks = anthropicFallbacks;
            this.enabled = enabled;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderConfiguration"/> class by copying another instance.
        /// </summary>
        /// <param name="providerConfiguration">The instance to copy from.</param>
        public ProviderConfiguration(ProviderConfiguration? providerConfiguration)
            : base(providerConfiguration)
        {
            if (providerConfiguration is not null)
            {
                name = providerConfiguration.name;
                displayName = providerConfiguration.displayName;
                protocol = providerConfiguration.protocol;
                baseUri = providerConfiguration.baseUri;
                model = providerConfiguration.model;
                key = providerConfiguration.key;
                keyEnvironmentVariable = providerConfiguration.keyEnvironmentVariable;
                maxTokens = providerConfiguration.maxTokens;
                effort = providerConfiguration.effort;
                thinking = providerConfiguration.thinking;
                replayReasoning = providerConfiguration.replayReasoning;
                anthropicFallbacks = providerConfiguration.anthropicFallbacks;
                enabled = providerConfiguration.enabled;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderConfiguration"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public ProviderConfiguration(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the unique name clients select the provider by.
        /// </summary>
        [JsonIgnore]
        public string? Name => name;

        /// <summary>
        /// Gets the name shown to users.
        /// </summary>
        [JsonIgnore]
        public string? DisplayName => displayName;

        /// <summary>
        /// Gets the wire protocol.
        /// </summary>
        [JsonIgnore]
        public Protocol Protocol => protocol;

        /// <summary>
        /// Gets the base URI of the provider.
        /// </summary>
        [JsonIgnore]
        public string? BaseUri => baseUri;

        /// <summary>
        /// Gets the model identifier sent to the provider.
        /// </summary>
        [JsonIgnore]
        public string? Model => model;

        /// <summary>
        /// Gets the API key; never log it or return it to a client.
        /// </summary>
        [JsonIgnore]
        public string? Key => key;

        /// <summary>
        /// Gets the environment variable holding the API key, read when <see cref="Key"/> is empty.
        /// </summary>
        [JsonIgnore]
        public string? KeyEnvironmentVariable => keyEnvironmentVariable;

        /// <summary>
        /// Gets the maximum number of output tokens of one request; zero or less uses the default.
        /// </summary>
        [JsonIgnore]
        public int MaxTokens => maxTokens;

        /// <summary>
        /// Gets the effort level, or null to send none.
        /// </summary>
        [JsonIgnore]
        public string? Effort => effort;

        /// <summary>
        /// Gets a value indicating whether summarized adaptive thinking is requested (Anthropic protocol only).
        /// </summary>
        [JsonIgnore]
        public bool Thinking => thinking;

        /// <summary>
        /// Gets a value indicating whether reasoning text is sent back as <c>reasoning_content</c> (OpenAI protocol).
        /// </summary>
        [JsonIgnore]
        public bool ReplayReasoning => replayReasoning;

        /// <summary>
        /// Gets a value indicating whether server-side refusal fallbacks are requested (Anthropic first-party API only).
        /// </summary>
        [JsonIgnore]
        public bool AnthropicFallbacks => anthropicFallbacks;

        /// <summary>
        /// Gets a value indicating whether the provider can be selected.
        /// </summary>
        [JsonIgnore]
        public bool Enabled => enabled;
    }
}
