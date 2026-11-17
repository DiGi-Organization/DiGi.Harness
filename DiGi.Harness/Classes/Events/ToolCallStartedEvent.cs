using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// A tool call has started.
    /// </summary>
    public class ToolCallStartedEvent : HarnessEvent
    {
        [JsonInclude, JsonPropertyName(nameof(ToolUseId))]
        private readonly string? toolUseId;

        [JsonInclude, JsonPropertyName(nameof(ToolName))]
        private readonly string? toolName;

        [JsonInclude, JsonPropertyName(nameof(InputJson))]
        private readonly string? inputJson;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolCallStartedEvent"/> class.
        /// </summary>
        /// <param name="toolUseId">The call identifier.</param>
        /// <param name="toolName">The name of the tool.</param>
        /// <param name="inputJson">The input as JSON text.</param>
        /// <param name="elapsedMilliseconds">The time elapsed since the turn started, in milliseconds.</param>
        public ToolCallStartedEvent(string? toolUseId, string? toolName, string? inputJson, double elapsedMilliseconds)
            : base(elapsedMilliseconds)
        {
            this.toolUseId = toolUseId;
            this.toolName = toolName;
            this.inputJson = inputJson;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolCallStartedEvent"/> class by copying another instance.
        /// </summary>
        /// <param name="toolCallStartedEvent">The instance to copy from.</param>
        public ToolCallStartedEvent(ToolCallStartedEvent? toolCallStartedEvent)
            : base(toolCallStartedEvent)
        {
            if (toolCallStartedEvent is not null)
            {
                toolUseId = toolCallStartedEvent.toolUseId;
                toolName = toolCallStartedEvent.toolName;
                inputJson = toolCallStartedEvent.inputJson;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolCallStartedEvent"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public ToolCallStartedEvent(JsonObject? jsonObject)
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
        /// Gets the input as JSON text.
        /// </summary>
        [JsonIgnore]
        public string? InputJson => inputJson;
    }
}
