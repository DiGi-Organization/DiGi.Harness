using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// A model request (one step of the agent loop) has started.
    /// </summary>
    public class StepStartedEvent : HarnessEvent
    {
        [JsonInclude, JsonPropertyName(nameof(Step))]
        private readonly int step;

        /// <summary>
        /// Initializes a new instance of the <see cref="StepStartedEvent"/> class.
        /// </summary>
        /// <param name="step">The one-based step number.</param>
        /// <param name="elapsedMilliseconds">The time elapsed since the turn started, in milliseconds.</param>
        public StepStartedEvent(int step, double elapsedMilliseconds)
            : base(elapsedMilliseconds)
        {
            this.step = step;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StepStartedEvent"/> class by copying another instance.
        /// </summary>
        /// <param name="stepStartedEvent">The instance to copy from.</param>
        public StepStartedEvent(StepStartedEvent? stepStartedEvent)
            : base(stepStartedEvent)
        {
            if (stepStartedEvent is not null)
            {
                step = stepStartedEvent.step;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StepStartedEvent"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public StepStartedEvent(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the one-based step number.
        /// </summary>
        [JsonIgnore]
        public int Step => step;
    }
}
