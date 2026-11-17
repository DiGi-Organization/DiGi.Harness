using DiGi.Harness.Interfaces;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// The <c>describe_endpoint</c> tool: returns one WebAPI operation's description, parameters, request body and response schemas from an OpenAPI document.
    /// </summary>
    public class DescribeEndpointTool : ITool
    {
        private readonly JsonObject? swagger;
        private readonly string? pathPrefix;

        /// <summary>
        /// Initializes a new instance of the <see cref="DescribeEndpointTool"/> class.
        /// </summary>
        /// <param name="swagger">The OpenAPI document.</param>
        /// <param name="pathPrefix">The path prefix the model may ask about, such as <c>/gis/</c>; null allows every path of the document.</param>
        public DescribeEndpointTool(JsonObject? swagger, string? pathPrefix)
        {
            this.swagger = swagger;
            this.pathPrefix = pathPrefix;
        }

        /// <summary>
        /// Gets the definition sent to the model.
        /// </summary>
        public ToolDefinition ToolDefinition { get; } = new(
            Constants.ToolName.DescribeEndpoint,
            "Returns the full description of one WebAPI endpoint from the API index: what it does, every parameter with its type and meaning, the request body schema and the response schema. Call it before call_endpoint whenever the index line is not enough to build the call.",
            """{"type":"object","properties":{"method":{"type":"string","enum":["GET","POST"],"description":"The HTTP method from the API index."},"path":{"type":"string","description":"The endpoint path from the API index, such as /gis/building2d/itemsbyreferences."}},"required":["method","path"],"additionalProperties":false}""");

        /// <summary>
        /// Returns the description of the endpoint named in the call's input, or an error result when it is unknown.
        /// </summary>
        /// <param name="toolUseContent">The call made by the model.</param>
        /// <param name="cancellationToken">The token that cancels the call (unused; the lookup is synchronous).</param>
        /// <returns>The endpoint description as JSON text, or an error result.</returns>
        public Task<ToolResultContent> InvokeAsync(ToolUseContent toolUseContent, CancellationToken cancellationToken = default)
        {
            JsonObject? input = Query.Input(toolUseContent);
            string? method = (input?["method"] as JsonValue)?.TryGetValue(out string? method_Temp) == true ? method_Temp : null;
            string? path = (input?["path"] as JsonValue)?.TryGetValue(out string? path_Temp) == true ? path_Temp : null;

            if (path is not null && pathPrefix is not null && !path.StartsWith(pathPrefix, System.StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(new ToolResultContent(toolUseContent.Id, string.Concat("Only endpoints under ", pathPrefix, " can be described."), true));
            }

            JsonObject? operation = Query.Operation(swagger, method, path);
            if (operation is null)
            {
                return Task.FromResult(new ToolResultContent(toolUseContent.Id, string.Concat("No ", method, " endpoint matches '", path, "'. Use a method and path exactly as listed in the API index."), true));
            }

            return Task.FromResult(new ToolResultContent(toolUseContent.Id, operation.ToJsonString(), false));
        }
    }
}
