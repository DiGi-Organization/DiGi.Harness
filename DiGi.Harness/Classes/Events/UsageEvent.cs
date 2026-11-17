using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// The token usage of one model request.
    /// </summary>
    public class UsageEvent : HarnessEvent
    {
        [JsonInclude, JsonPropertyName(nameof(Usage))]
        private readonly Usage? usage;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsageEvent"/> class.
        /// </summary>
        /// <param name="usage">The token usage of the request.</param>
        /// <param name="elapsedMilliseconds">The time elapsed since the turn started, in milliseconds.</param>
        public UsageEvent(Usage? usage, double elapsedMilliseconds)
            : base(elapsedMilliseconds)
        {
            this.usage = usage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsageEvent"/> class by copying another instance.
        /// </summary>
        /// <param name="usageEvent">The instance to copy from.</param>
        public UsageEvent(UsageEvent? usageEvent)
            : base(usageEvent)
        {
            if (usageEvent is not null)
            {
                usage = Core.Query.Clone(usageEvent.usage);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsageEvent"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public UsageEvent(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the token usage of the request.
        /// </summary>
        [JsonIgnore]
        public Usage? Usage => usage;
    }
}
