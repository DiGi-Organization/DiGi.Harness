using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// A piece of the answer text has arrived.
    /// </summary>
    public class TextDeltaEvent : HarnessEvent
    {
        [JsonInclude, JsonPropertyName(nameof(Text))]
        private readonly string? text;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextDeltaEvent"/> class.
        /// </summary>
        /// <param name="text">The text fragment.</param>
        /// <param name="elapsedMilliseconds">The time elapsed since the turn started, in milliseconds.</param>
        public TextDeltaEvent(string? text, double elapsedMilliseconds)
            : base(elapsedMilliseconds)
        {
            this.text = text;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextDeltaEvent"/> class by copying another instance.
        /// </summary>
        /// <param name="textDeltaEvent">The instance to copy from.</param>
        public TextDeltaEvent(TextDeltaEvent? textDeltaEvent)
            : base(textDeltaEvent)
        {
            if (textDeltaEvent is not null)
            {
                text = textDeltaEvent.text;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextDeltaEvent"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public TextDeltaEvent(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the text fragment.
        /// </summary>
        [JsonIgnore]
        public string? Text => text;
    }
}
