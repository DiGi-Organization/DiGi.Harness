using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// A short summary line of one completed thinking block (sent to clients with summary thinking visibility).
    /// </summary>
    public class ThinkingSummaryEvent : HarnessEvent
    {
        [JsonInclude, JsonPropertyName(nameof(Text))]
        private readonly string? text;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThinkingSummaryEvent"/> class.
        /// </summary>
        /// <param name="text">The summary line.</param>
        /// <param name="elapsedMilliseconds">The time elapsed since the turn started, in milliseconds.</param>
        public ThinkingSummaryEvent(string? text, double elapsedMilliseconds)
            : base(elapsedMilliseconds)
        {
            this.text = text;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThinkingSummaryEvent"/> class by copying another instance.
        /// </summary>
        /// <param name="thinkingSummaryEvent">The instance to copy from.</param>
        public ThinkingSummaryEvent(ThinkingSummaryEvent? thinkingSummaryEvent)
            : base(thinkingSummaryEvent)
        {
            if (thinkingSummaryEvent is not null)
            {
                text = thinkingSummaryEvent.text;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThinkingSummaryEvent"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public ThinkingSummaryEvent(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the summary line.
        /// </summary>
        [JsonIgnore]
        public string? Text => text;
    }
}
