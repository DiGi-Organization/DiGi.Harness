using DiGi.Core.Classes;
using DiGi.Harness.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// The base of every event emitted while a turn runs.
    /// <para>Clients tell events apart by the serialized type name (<c>_type</c>), so the names of the derived classes are a wire contract.</para>
    /// </summary>
    public abstract class HarnessEvent : SerializableObject, IHarnessEvent
    {
        [JsonInclude, JsonPropertyName(nameof(ElapsedMilliseconds))]
        private readonly double elapsedMilliseconds;

        /// <summary>
        /// Initializes a new instance of the <see cref="HarnessEvent"/> class.
        /// </summary>
        /// <param name="elapsedMilliseconds">The time elapsed since the turn started, in milliseconds.</param>
        protected HarnessEvent(double elapsedMilliseconds)
        {
            this.elapsedMilliseconds = elapsedMilliseconds;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HarnessEvent"/> class by copying another instance.
        /// </summary>
        /// <param name="harnessEvent">The instance to copy from.</param>
        protected HarnessEvent(HarnessEvent? harnessEvent)
            : base(harnessEvent)
        {
            if (harnessEvent is not null)
            {
                elapsedMilliseconds = harnessEvent.elapsedMilliseconds;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HarnessEvent"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        protected HarnessEvent(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the time elapsed since the turn started, in milliseconds.
        /// </summary>
        [JsonIgnore]
        public double ElapsedMilliseconds => elapsedMilliseconds;
    }
}
