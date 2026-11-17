using DiGi.Harness.Enums;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// The turn failed; carries the category and a short, key-free message.
    /// </summary>
    public class ErrorEvent : HarnessEvent
    {
        [JsonInclude, JsonPropertyName(nameof(ErrorCategory))]
        private readonly ErrorCategory errorCategory;

        [JsonInclude, JsonPropertyName(nameof(Message))]
        private readonly string? message;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorEvent"/> class.
        /// </summary>
        /// <param name="errorCategory">Why the turn failed.</param>
        /// <param name="message">A short, key-free description.</param>
        /// <param name="elapsedMilliseconds">The time elapsed since the turn started, in milliseconds.</param>
        public ErrorEvent(ErrorCategory errorCategory, string? message, double elapsedMilliseconds)
            : base(elapsedMilliseconds)
        {
            this.errorCategory = errorCategory;
            this.message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorEvent"/> class by copying another instance.
        /// </summary>
        /// <param name="errorEvent">The instance to copy from.</param>
        public ErrorEvent(ErrorEvent? errorEvent)
            : base(errorEvent)
        {
            if (errorEvent is not null)
            {
                errorCategory = errorEvent.errorCategory;
                message = errorEvent.message;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorEvent"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public ErrorEvent(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets why the turn failed.
        /// </summary>
        [JsonIgnore]
        public ErrorCategory ErrorCategory => errorCategory;

        /// <summary>
        /// Gets a short, key-free description.
        /// </summary>
        [JsonIgnore]
        public string? Message => message;
    }
}
