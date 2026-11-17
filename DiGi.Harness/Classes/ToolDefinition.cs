using DiGi.Core.Classes;
using DiGi.Harness.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// The definition of a tool sent to the model: its name, description and JSON input schema.
    /// <para>The schema travels as JSON text (<see cref="InputSchemaJson"/>); read it parsed with <see cref="Query.InputSchema(ToolDefinition?)"/>.</para>
    /// </summary>
    public class ToolDefinition : SerializableObject, IHarnessSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Name))]
        private readonly string? name;

        [JsonInclude, JsonPropertyName(nameof(Description))]
        private readonly string? description;

        [JsonInclude, JsonPropertyName(nameof(InputSchemaJson))]
        private readonly string? inputSchemaJson;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolDefinition"/> class.
        /// </summary>
        /// <param name="name">The tool name (letters, digits, <c>_</c> and <c>-</c>).</param>
        /// <param name="description">What the tool does and when to use it.</param>
        /// <param name="inputSchemaJson">The JSON schema of the input, as JSON text.</param>
        public ToolDefinition(string? name, string? description, string? inputSchemaJson)
        {
            this.name = name;
            this.description = description;
            this.inputSchemaJson = inputSchemaJson;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolDefinition"/> class by copying another instance.
        /// </summary>
        /// <param name="toolDefinition">The instance to copy from.</param>
        public ToolDefinition(ToolDefinition? toolDefinition)
            : base(toolDefinition)
        {
            if (toolDefinition is not null)
            {
                name = toolDefinition.name;
                description = toolDefinition.description;
                inputSchemaJson = toolDefinition.inputSchemaJson;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolDefinition"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public ToolDefinition(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the tool name.
        /// </summary>
        [JsonIgnore]
        public string? Name => name;

        /// <summary>
        /// Gets what the tool does and when to use it.
        /// </summary>
        [JsonIgnore]
        public string? Description => description;

        /// <summary>
        /// Gets the JSON schema of the input, as JSON text.
        /// </summary>
        [JsonIgnore]
        public string? InputSchemaJson => inputSchemaJson;
    }
}
