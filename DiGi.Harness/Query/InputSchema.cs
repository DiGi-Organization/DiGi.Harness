using DiGi.Harness.Classes;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DiGi.Harness
{
    public static partial class Query
    {
        /// <summary>
        /// Parses the JSON input schema of a tool definition.
        /// <para>A missing or invalid schema returns the empty object schema <c>{"type":"object","properties":{}}</c>, which every protocol accepts.</para>
        /// </summary>
        /// <param name="toolDefinition">The tool definition.</param>
        /// <returns>The parsed schema, or null when <paramref name="toolDefinition"/> is null.</returns>
        public static JsonObject? InputSchema(this ToolDefinition? toolDefinition)
        {
            if (toolDefinition is null)
            {
                return null;
            }

            string? inputSchemaJson = toolDefinition.InputSchemaJson;
            if (!string.IsNullOrWhiteSpace(inputSchemaJson))
            {
                try
                {
                    if (JsonNode.Parse(inputSchemaJson) is JsonObject jsonObject)
                    {
                        return jsonObject;
                    }
                }
                catch (JsonException)
                {
                }
            }

            return new JsonObject
            {
                ["type"] = "object",
                ["properties"] = new JsonObject(),
            };
        }
    }
}
