using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// A piece of thinking text has arrived (sent to clients only with full thinking visibility).
    /// </summary>
    public class ThinkingDeltaEvent : HarnessEvent
    {
        [JsonInclude, JsonPropertyName(nameof(Text))]
        private readonly string? text;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThinkingDeltaEvent"/> class.
        /// </summary>
        /// <param name="text">The thinking fragment.</param>
        /// <param name="elapsedMilliseconds">The time elapsed since the turn started, in milliseconds.</param>
        public ThinkingDeltaEvent(string? text, double elapsedMilliseconds)
            : base(elapsedMilliseconds)
        {
            this.text = text;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThinkingDeltaEvent"/> class by copying another instance.
        /// </summary>
        /// <param name="thinkingDeltaEvent">The instance to copy from.</param>
        public ThinkingDeltaEvent(ThinkingDeltaEvent? thinkingDeltaEvent)
            : base(thinkingDeltaEvent)
        {
            if (thinkingDeltaEvent is not null)
            {
                text = thinkingDeltaEvent.text;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThinkingDeltaEvent"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public ThinkingDeltaEvent(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the thinking fragment.
        /// </summary>
        [JsonIgnore]
        public string? Text => text;
    }
}
