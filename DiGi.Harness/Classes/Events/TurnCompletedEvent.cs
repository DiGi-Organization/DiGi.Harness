using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// The turn has ended, normally or not; always the last event of a turn.
    /// </summary>
    public class TurnCompletedEvent : HarnessEvent
    {
        [JsonInclude, JsonPropertyName(nameof(TurnResult))]
        private readonly TurnResult? turnResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="TurnCompletedEvent"/> class.
        /// </summary>
        /// <param name="turnResult">The outcome of the turn.</param>
        /// <param name="elapsedMilliseconds">The time elapsed since the turn started, in milliseconds.</param>
        public TurnCompletedEvent(TurnResult? turnResult, double elapsedMilliseconds)
            : base(elapsedMilliseconds)
        {
            this.turnResult = turnResult;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TurnCompletedEvent"/> class by copying another instance.
        /// </summary>
        /// <param name="turnCompletedEvent">The instance to copy from.</param>
        public TurnCompletedEvent(TurnCompletedEvent? turnCompletedEvent)
            : base(turnCompletedEvent)
        {
            if (turnCompletedEvent is not null)
            {
                turnResult = Core.Query.Clone(turnCompletedEvent.turnResult);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TurnCompletedEvent"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public TurnCompletedEvent(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the outcome of the turn.
        /// </summary>
        [JsonIgnore]
        public TurnResult? TurnResult => turnResult;
    }
}
