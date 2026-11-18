using DiGi.Harness.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// The <c>call_endpoint</c> tool: calls one operation of a WebAPI described by an OpenAPI document, with the signed-in user's bearer token.
    /// <para>Guarded so the model cannot reach anything else: the path must match an operation of the document under <c>pathPrefix</c> (<see cref="Query.PathTemplate(JsonObject?, string?, string?)"/> rejects absolute, protocol-relative and <c>..</c> paths, queries and fragments), the request always goes to the fixed base URI, GET is always allowed, and POST only for path templates on the allowlist. Query values are URL-encoded. A POST body given as a string holding a JSON object or array is sent as that object or array; any other string is sent as a JSON string. A binary response is described, not returned.</para>
    /// </summary>
    public class CallEndpointTool : ITool
    {
        private readonly Uri baseUri;
        private readonly string? pathPrefix;
        private readonly JsonObject? swagger;
        private readonly HashSet<string> postPathTemplates;
        private readonly string? bearerToken;
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="CallEndpointTool"/> class.
        /// </summary>
        /// <param name="baseUri">The base URI every request goes to, such as <c>https://api.digiproject.uk</c>.</param>
        /// <param name="pathPrefix">The path prefix the model may call, such as <c>/gis/</c>; null allows every path of the document.</param>
        /// <param name="swagger">The OpenAPI document listing the callable operations.</param>
        /// <param name="postPathTemplates">The path templates (as written in the document) that may be called with POST; every other POST is refused.</param>
        /// <param name="bearerToken">The signed-in user's bearer token, or null to call anonymously.</param>
        /// <param name="httpClient">The HTTP client; its timeout bounds each call.</param>
        public CallEndpointTool(Uri baseUri, string? pathPrefix, JsonObject? swagger, IEnumerable<string>? postPathTemplates, string? bearerToken, HttpClient httpClient)
        {
            this.baseUri = baseUri;
            this.pathPrefix = pathPrefix;
            this.swagger = swagger;
            this.postPathTemplates = postPathTemplates is null ? new HashSet<string>(StringComparer.OrdinalIgnoreCase) : new HashSet<string>(postPathTemplates, StringComparer.OrdinalIgnoreCase);
            this.bearerToken = bearerToken;
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Gets the definition sent to the model.
        /// </summary>
        public ToolDefinition ToolDefinition { get; } = new(
            Constants.ToolName.CallEndpoint,
            "Calls one WebAPI endpoint from the API index and returns the HTTP status and the response body (JSON). Use GET for reads; POST works only for the endpoints that allow it. Put query parameters in 'query', never in the path. Prefer narrow requests (one county, a few references) - long results are truncated.",
            """{"type":"object","properties":{"method":{"type":"string","enum":["GET","POST"],"description":"The HTTP method from the API index."},"path":{"type":"string","description":"The endpoint path from the API index with any {parameter} segments filled in, without a query string."},"query":{"type":"object","description":"Query parameters by name; arrays repeat the parameter.","additionalProperties":{}},"body":{"description":"The JSON request body of a POST endpoint, shaped as its schema requires: pass the JSON object or array itself, not a string containing JSON."}},"required":["method","path"],"additionalProperties":false}""");

        /// <summary>
        /// Calls the endpoint named in the call's input and returns the status and body, or an error result when the call is refused or fails.
        /// </summary>
        /// <param name="toolUseContent">The call made by the model.</param>
        /// <param name="cancellationToken">The token that cancels the call.</param>
        /// <returns>The status line and the response body; an error result for a refused call, a failure status or no answer.</returns>
        public async Task<ToolResultContent> InvokeAsync(ToolUseContent toolUseContent, CancellationToken cancellationToken = default)
        {
            JsonObject? input = Query.Input(toolUseContent);
            string? method = (input?["method"] as JsonValue)?.TryGetValue(out string? method_Temp) == true ? method_Temp?.Trim().ToUpperInvariant() : null;
            string? path = (input?["path"] as JsonValue)?.TryGetValue(out string? path_Temp) == true ? path_Temp?.Trim() : null;

            if (method != "GET" && method != "POST")
            {
                return new ToolResultContent(toolUseContent.Id, "Only GET and POST are supported.", true);
            }

            if (path is null || (pathPrefix is not null && !path.StartsWith(pathPrefix, StringComparison.OrdinalIgnoreCase)))
            {
                return new ToolResultContent(toolUseContent.Id, string.Concat("Only endpoints under ", pathPrefix, " can be called."), true);
            }

            string? pathTemplate = Query.PathTemplate(swagger, method, path);
            if (pathTemplate is null)
            {
                return new ToolResultContent(toolUseContent.Id, string.Concat("No ", method, " endpoint matches '", path, "'. Use a path from the API index, with query parameters in 'query'."), true);
            }

            if (method == "POST" && !postPathTemplates.Contains(pathTemplate))
            {
                return new ToolResultContent(toolUseContent.Id, string.Concat("POST ", pathTemplate, " is not allowed for the assistant. Use a GET endpoint instead."), true);
            }

            StringBuilder stringBuilder = new(path);
            if (input?["query"] is JsonObject jsonObject_Query)
            {
                char separator = '?';
                foreach (KeyValuePair<string, JsonNode?> keyValuePair in jsonObject_Query)
                {
                    List<JsonNode?> jsonNodes = keyValuePair.Value is JsonArray jsonArray ? [.. jsonArray] : [keyValuePair.Value];
                    foreach (JsonNode? jsonNode in jsonNodes)
                    {
                        if (jsonNode is null)
                        {
                            continue;
                        }

                        string value = jsonNode is JsonValue jsonValue && jsonValue.TryGetValue(out string? @string) ? @string : jsonNode.ToJsonString();
                        stringBuilder.Append(separator).Append(Uri.EscapeDataString(keyValuePair.Key)).Append('=').Append(Uri.EscapeDataString(value));
                        separator = '&';
                    }
                }
            }

            Uri uri = new(baseUri, stringBuilder.ToString());
            if (!string.Equals(uri.Host, baseUri.Host, StringComparison.OrdinalIgnoreCase) || uri.Scheme != baseUri.Scheme || uri.Port != baseUri.Port || (pathPrefix is not null && !uri.AbsolutePath.StartsWith(pathPrefix, StringComparison.OrdinalIgnoreCase)))
            {
                return new ToolResultContent(toolUseContent.Id, "The path does not stay on the WebAPI host.", true);
            }

            using HttpRequestMessage httpRequestMessage = new(method == "POST" ? HttpMethod.Post : HttpMethod.Get, uri);
            if (!string.IsNullOrWhiteSpace(bearerToken))
            {
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            }

            if (method == "POST")
            {
                // Models often pass the body as a string holding JSON; sending its ToJsonString() would post a JSON string literal the endpoint cannot bind (DiGi-Organization/DiGi.Harness#5).
                JsonNode? jsonNode_Body = input?["body"];
                if (jsonNode_Body is JsonValue jsonValue_Body && jsonValue_Body.TryGetValue(out string? body_String) && body_String is not null)
                {
                    string body_Trimmed = body_String.Trim();
                    if (body_Trimmed.StartsWith('{') || body_Trimmed.StartsWith('['))
                    {
                        try
                        {
                            JsonNode? jsonNode_Parsed = JsonNode.Parse(body_Trimmed);
                            if (jsonNode_Parsed is JsonObject or JsonArray)
                            {
                                jsonNode_Body = jsonNode_Parsed;
                            }
                        }
                        catch (JsonException)
                        {
                            // Not JSON: the string is sent as a JSON string, as for an endpoint taking a string body.
                        }
                    }
                }

                string body = jsonNode_Body?.ToJsonString() ?? "null";
                httpRequestMessage.Content = new StringContent(body, Encoding.UTF8, "application/json");
            }

            try
            {
                using HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

                int statusCode = (int)httpResponseMessage.StatusCode;
                string statusLine = string.Concat("HTTP ", statusCode.ToString(CultureInfo.InvariantCulture), " ", httpResponseMessage.ReasonPhrase);
                string? mediaType = httpResponseMessage.Content.Headers.ContentType?.MediaType;

                string text;
                if (mediaType is not null && !mediaType.Contains("json", StringComparison.OrdinalIgnoreCase) && !mediaType.StartsWith("text/", StringComparison.OrdinalIgnoreCase))
                {
                    byte[] bytes = await httpResponseMessage.Content.ReadAsByteArrayAsync(cancellationToken).ConfigureAwait(false);
                    text = string.Concat("(", mediaType, " content of ", bytes.Length.ToString(CultureInfo.InvariantCulture), " bytes, not shown)");
                }
                else
                {
                    text = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    if (text.Length == 0)
                    {
                        text = "(empty body)";
                    }
                }

                return new ToolResultContent(toolUseContent.Id, string.Concat(statusLine, "\n", text), !httpResponseMessage.IsSuccessStatusCode);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                throw;
            }
            catch (Exception exception) when (exception is HttpRequestException or TaskCanceledException or IOException or JsonException)
            {
                return new ToolResultContent(toolUseContent.Id, string.Concat("The WebAPI did not answer (", exception is TaskCanceledException ? "timeout" : exception.GetType().Name, "). Try a narrower request or try again later."), true);
            }
        }
    }
}
