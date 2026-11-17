using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// A tool call has finished.
    /// </summary>
    public class ToolCallCompletedEvent : HarnessEvent
    {
        [JsonInclude, JsonPropertyName(nameof(ToolUseId))]
        private readonly string? toolUseId;

        [JsonInclude, JsonPropertyName(nameof(ToolName))]
        private readonly string? toolName;

        [JsonInclude, JsonPropertyName(nameof(IsError))]
        private readonly bool isError;

        [JsonInclude, JsonPropertyName(nameof(DurationMilliseconds))]
        private readonly double durationMilliseconds;

        [JsonInclude, JsonPropertyName(nameof(Characters))]
        private readonly int characters;

        [JsonInclude, JsonPropertyName(nameof(Truncated))]
        private readonly bool truncated;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolCallCompletedEvent"/> class.
        /// </summary>
        /// <param name="toolUseId">The call identifier.</param>
        /// <param name="toolName">The name of the tool.</param>
        /// <param name="isError">Whether the call failed.</param>
        /// <param name="durationMilliseconds">The duration of the call in milliseconds.</param>
        /// <param name="characters">The length of the full result text, before truncation.</param>
        /// <param name="truncated">Whether the result was truncated before it was returned to the model.</param>
        /// <param name="elapsedMilliseconds">The time elapsed since the turn started, in milliseconds.</param>
        public ToolCallCompletedEvent(string? toolUseId, string? toolName, bool isError, double durationMilliseconds, int characters, bool truncated, double elapsedMilliseconds)
            : base(elapsedMilliseconds)
        {
            this.toolUseId = toolUseId;
            this.toolName = toolName;
            this.isError = isError;
            this.durationMilliseconds = durationMilliseconds;
            this.characters = characters;
            this.truncated = truncated;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolCallCompletedEvent"/> class by copying another instance.
        /// </summary>
        /// <param name="toolCallCompletedEvent">The instance to copy from.</param>
        public ToolCallCompletedEvent(ToolCallCompletedEvent? toolCallCompletedEvent)
            : base(toolCallCompletedEvent)
        {
            if (toolCallCompletedEvent is not null)
            {
                toolUseId = toolCallCompletedEvent.toolUseId;
                toolName = toolCallCompletedEvent.toolName;
                isError = toolCallCompletedEvent.isError;
                durationMilliseconds = toolCallCompletedEvent.durationMilliseconds;
                characters = toolCallCompletedEvent.characters;
                truncated = toolCallCompletedEvent.truncated;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolCallCompletedEvent"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public ToolCallCompletedEvent(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the call identifier.
        /// </summary>
        [JsonIgnore]
        public string? ToolUseId => toolUseId;

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        [JsonIgnore]
        public string? ToolName => toolName;

        /// <summary>
        /// Gets a value indicating whether the call failed.
        /// </summary>
        [JsonIgnore]
        public bool IsError => isError;

        /// <summary>
        /// Gets the duration of the call in milliseconds.
        /// </summary>
        [JsonIgnore]
        public double DurationMilliseconds => durationMilliseconds;

        /// <summary>
        /// Gets the length of the full result text, before truncation.
        /// </summary>
        [JsonIgnore]
        public int Characters => characters;

        /// <summary>
        /// Gets a value indicating whether the result was truncated before it was returned to the model.
        /// </summary>
        [JsonIgnore]
        public bool Truncated => truncated;
    }
}
