using DiGi.Core.Classes;
using DiGi.Harness.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// A tool call made by the model.
    /// <para>The input travels as JSON text (<see cref="InputJson"/>): a <see cref="JsonObject"/> member does not survive the DiGi serializer. Read it parsed with <see cref="Query.Input(ToolUseContent?)"/>.</para>
    /// </summary>
    public class ToolUseContent : SerializableObject, IContent
    {
        [JsonInclude, JsonPropertyName(nameof(Id))]
        private readonly string? id;

        [JsonInclude, JsonPropertyName(nameof(Name))]
        private readonly string? name;

        [JsonInclude, JsonPropertyName(nameof(InputJson))]
        private readonly string? inputJson;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolUseContent"/> class.
        /// </summary>
        /// <param name="id">The call identifier assigned by the provider.</param>
        /// <param name="name">The name of the tool.</param>
        /// <param name="inputJson">The input as JSON text, exactly as the model produced it.</param>
        public ToolUseContent(string? id, string? name, string? inputJson)
        {
            this.id = id;
            this.name = name;
            this.inputJson = inputJson;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolUseContent"/> class by copying another instance.
        /// </summary>
        /// <param name="toolUseContent">The instance to copy from.</param>
        public ToolUseContent(ToolUseContent? toolUseContent)
            : base(toolUseContent)
        {
            if (toolUseContent is not null)
            {
                id = toolUseContent.id;
                name = toolUseContent.name;
                inputJson = toolUseContent.inputJson;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolUseContent"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public ToolUseContent(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the call identifier assigned by the provider.
        /// </summary>
        [JsonIgnore]
        public string? Id => id;

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        [JsonIgnore]
        public string? Name => name;

        /// <summary>
        /// Gets the input as JSON text, exactly as the model produced it (may be invalid or truncated).
        /// </summary>
        [JsonIgnore]
        public string? InputJson => inputJson;
    }
}
