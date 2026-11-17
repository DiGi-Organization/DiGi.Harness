using DiGi.Core.Classes;
using DiGi.Harness.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// A thinking block of an assistant message.
    /// <para>Anthropic thinking blocks are replayed to the same provider unchanged: <see cref="Signature"/> for a <c>thinking</c> block and <see cref="RedactedData"/> for a <c>redacted_thinking</c> block. OpenAI-protocol reasoning (<c>reasoning_content</c>) has neither.</para>
    /// </summary>
    public class ThinkingContent : SerializableObject, IContent
    {
        [JsonInclude, JsonPropertyName(nameof(Text))]
        private readonly string? text;

        [JsonInclude, JsonPropertyName(nameof(Signature))]
        private readonly string? signature;

        [JsonInclude, JsonPropertyName(nameof(RedactedData))]
        private readonly string? redactedData;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThinkingContent"/> class.
        /// </summary>
        /// <param name="text">The thinking text (a summary on current Anthropic models; may be empty).</param>
        /// <param name="signature">The Anthropic signature of the block.</param>
        /// <param name="redactedData">The opaque data of an Anthropic <c>redacted_thinking</c> block.</param>
        public ThinkingContent(string? text, string? signature, string? redactedData)
        {
            this.text = text;
            this.signature = signature;
            this.redactedData = redactedData;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThinkingContent"/> class by copying another instance.
        /// </summary>
        /// <param name="thinkingContent">The instance to copy from.</param>
        public ThinkingContent(ThinkingContent? thinkingContent)
            : base(thinkingContent)
        {
            if (thinkingContent is not null)
            {
                text = thinkingContent.text;
                signature = thinkingContent.signature;
                redactedData = thinkingContent.redactedData;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThinkingContent"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public ThinkingContent(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the thinking text.
        /// </summary>
        [JsonIgnore]
        public string? Text => text;

        /// <summary>
        /// Gets the Anthropic signature of the block.
        /// </summary>
        [JsonIgnore]
        public string? Signature => signature;

        /// <summary>
        /// Gets the opaque data of an Anthropic <c>redacted_thinking</c> block.
        /// </summary>
        [JsonIgnore]
        public string? RedactedData => redactedData;
    }
}
