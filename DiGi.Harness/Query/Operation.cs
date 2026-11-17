using System.Text.Json.Nodes;

namespace DiGi.Harness
{
    public static partial class Query
    {
        /// <summary>
        /// Finds one operation of an OpenAPI document by method and request path, with its schemas resolved two levels deep.
        /// </summary>
        /// <param name="swagger">The OpenAPI document.</param>
        /// <param name="method">The HTTP method, any case.</param>
        /// <param name="path">The request path or path template, starting with <c>/</c>.</param>
        /// <returns>A copy of the operation (<c>method</c>, <c>path</c>, then the operation members), or null when nothing matches.</returns>
        public static JsonObject? Operation(this JsonObject? swagger, string? method, string? path)
        {
            string? pathTemplate = PathTemplate(swagger, method, path);
            if (pathTemplate is null || method is null)
            {
                return null;
            }

            string method_Lower = method.Trim().ToLowerInvariant();
            if (swagger?["paths"]?[pathTemplate]?[method_Lower] is not JsonObject jsonObject_Operation)
            {
                return null;
            }

            JsonObject result = new()
            {
                ["method"] = method_Lower.ToUpperInvariant(),
                ["path"] = pathTemplate,
            };

            if (Resolved(jsonObject_Operation, swagger, 2) is JsonObject jsonObject_Resolved)
            {
                foreach (System.Collections.Generic.KeyValuePair<string, JsonNode?> keyValuePair in jsonObject_Resolved)
                {
                    result[keyValuePair.Key] = keyValuePair.Value?.DeepClone();
                }
            }

            return result;
        }
    }
}
