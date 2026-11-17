using DiGi.Core.Classes;
using DiGi.Harness.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// The result of one tool call, returned to the model.
    /// </summary>
    public class ToolResultContent : SerializableObject, IContent
    {
        [JsonInclude, JsonPropertyName(nameof(ToolUseId))]
        private readonly string? toolUseId;

        [JsonInclude, JsonPropertyName(nameof(Text))]
        private readonly string? text;

        [JsonInclude, JsonPropertyName(nameof(IsError))]
        private readonly bool isError;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolResultContent"/> class.
        /// </summary>
        /// <param name="toolUseId">The identifier of the call this result answers.</param>
        /// <param name="text">The result text.</param>
        /// <param name="isError">Whether the call failed.</param>
        public ToolResultContent(string? toolUseId, string? text, bool isError)
        {
            this.toolUseId = toolUseId;
            this.text = text;
            this.isError = isError;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolResultContent"/> class by copying another instance.
        /// </summary>
        /// <param name="toolResultContent">The instance to copy from.</param>
        public ToolResultContent(ToolResultContent? toolResultContent)
            : base(toolResultContent)
        {
            if (toolResultContent is not null)
            {
                toolUseId = toolResultContent.toolUseId;
                text = toolResultContent.text;
                isError = toolResultContent.isError;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolResultContent"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public ToolResultContent(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the identifier of the call this result answers.
        /// </summary>
        [JsonIgnore]
        public string? ToolUseId => toolUseId;

        /// <summary>
        /// Gets the result text.
        /// </summary>
        [JsonIgnore]
        public string? Text => text;

        /// <summary>
        /// Gets a value indicating whether the call failed.
        /// </summary>
        [JsonIgnore]
        public bool IsError => isError;
    }
}
