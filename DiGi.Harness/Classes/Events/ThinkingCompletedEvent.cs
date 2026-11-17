using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// A thinking block is complete; carries its whole text.
    /// <para>The WebAPI layer turns it into a short summary line or drops it, depending on the client's thinking visibility.</para>
    /// </summary>
    public class ThinkingCompletedEvent : HarnessEvent
    {
        [JsonInclude, JsonPropertyName(nameof(Text))]
        private readonly string? text;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThinkingCompletedEvent"/> class.
        /// </summary>
        /// <param name="text">The whole thinking text of the block.</param>
        /// <param name="elapsedMilliseconds">The time elapsed since the turn started, in milliseconds.</param>
        public ThinkingCompletedEvent(string? text, double elapsedMilliseconds)
            : base(elapsedMilliseconds)
        {
            this.text = text;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThinkingCompletedEvent"/> class by copying another instance.
        /// </summary>
        /// <param name="thinkingCompletedEvent">The instance to copy from.</param>
        public ThinkingCompletedEvent(ThinkingCompletedEvent? thinkingCompletedEvent)
            : base(thinkingCompletedEvent)
        {
            if (thinkingCompletedEvent is not null)
            {
                text = thinkingCompletedEvent.text;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThinkingCompletedEvent"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public ThinkingCompletedEvent(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the whole thinking text of the block.
        /// </summary>
        [JsonIgnore]
        public string? Text => text;
    }
}
