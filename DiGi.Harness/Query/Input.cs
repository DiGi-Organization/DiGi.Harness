using DiGi.Harness.Classes;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DiGi.Harness
{
    public static partial class Query
    {
        /// <summary>
        /// Parses the input of a tool call.
        /// <para>An empty input is an empty object; input that is not a JSON object (invalid, or truncated by the output limit) returns null.</para>
        /// </summary>
        /// <param name="toolUseContent">The tool call.</param>
        /// <returns>The parsed input, or null when it is not a JSON object.</returns>
        public static JsonObject? Input(this ToolUseContent? toolUseContent)
        {
            if (toolUseContent is null)
            {
                return null;
            }

            string? inputJson = toolUseContent.InputJson;
            if (string.IsNullOrWhiteSpace(inputJson))
            {
                return [];
            }

            try
            {
                return JsonNode.Parse(inputJson) as JsonObject;
            }
            catch (JsonException)
            {
                return null;
            }
        }
    }
}
