using DiGi.Core.Classes;
using DiGi.Harness.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// Token usage reported by a provider.
    /// </summary>
    public class Usage : SerializableObject, IHarnessSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(InputTokens))]
        private readonly int inputTokens;

        [JsonInclude, JsonPropertyName(nameof(OutputTokens))]
        private readonly int outputTokens;

        [JsonInclude, JsonPropertyName(nameof(CacheReadInputTokens))]
        private readonly int cacheReadInputTokens;

        [JsonInclude, JsonPropertyName(nameof(CacheCreationInputTokens))]
        private readonly int cacheCreationInputTokens;

        /// <summary>
        /// Initializes a new instance of the <see cref="Usage"/> class.
        /// </summary>
        /// <param name="inputTokens">The uncached input tokens.</param>
        /// <param name="outputTokens">The output tokens.</param>
        /// <param name="cacheReadInputTokens">The input tokens read from the prompt cache.</param>
        /// <param name="cacheCreationInputTokens">The input tokens written to the prompt cache.</param>
        public Usage(int inputTokens, int outputTokens, int cacheReadInputTokens, int cacheCreationInputTokens)
        {
            this.inputTokens = inputTokens;
            this.outputTokens = outputTokens;
            this.cacheReadInputTokens = cacheReadInputTokens;
            this.cacheCreationInputTokens = cacheCreationInputTokens;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Usage"/> class by copying another instance.
        /// </summary>
        /// <param name="usage">The instance to copy from.</param>
        public Usage(Usage? usage)
            : base(usage)
        {
            if (usage is not null)
            {
                inputTokens = usage.inputTokens;
                outputTokens = usage.outputTokens;
                cacheReadInputTokens = usage.cacheReadInputTokens;
                cacheCreationInputTokens = usage.cacheCreationInputTokens;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Usage"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public Usage(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the uncached input tokens.
        /// </summary>
        [JsonIgnore]
        public int InputTokens => inputTokens;

        /// <summary>
        /// Gets the output tokens.
        /// </summary>
        [JsonIgnore]
        public int OutputTokens => outputTokens;

        /// <summary>
        /// Gets the input tokens read from the prompt cache.
        /// </summary>
        [JsonIgnore]
        public int CacheReadInputTokens => cacheReadInputTokens;

        /// <summary>
        /// Gets the input tokens written to the prompt cache.
        /// </summary>
        [JsonIgnore]
        public int CacheCreationInputTokens => cacheCreationInputTokens;
    }
}
