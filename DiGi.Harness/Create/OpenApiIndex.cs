using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;

namespace DiGi.Harness
{
    public static partial class Create
    {
        /// <summary>
        /// Builds a compact index of an OpenAPI document for a system prompt: one line per operation, <c>METHOD path — summary (parameter*: type, …) body: Schema</c>.
        /// <para>A <c>*</c> marks a required parameter. Summaries are cut to their first sentence. Only operations whose path starts with <paramref name="pathPrefix"/> are listed, and only the methods named in <paramref name="methods"/> (GET and POST when null).</para>
        /// </summary>
        /// <param name="swagger">The OpenAPI document.</param>
        /// <param name="pathPrefix">The path prefix to keep, such as <c>/gis/</c>; null keeps every path.</param>
        /// <param name="methods">The HTTP methods to list, any case; null lists GET and POST.</param>
        /// <returns>The index text, or null when the document has no paths.</returns>
        public static string? OpenApiIndex(this JsonObject? swagger, string? pathPrefix = null, IEnumerable<string>? methods = null)
        {
            if (swagger?["paths"] is not JsonObject jsonObject_Paths)
            {
                return null;
            }

            HashSet<string> methods_Lower = new(StringComparer.Ordinal);
            foreach (string method in methods ?? ["get", "post"])
            {
                if (!string.IsNullOrWhiteSpace(method))
                {
                    methods_Lower.Add(method.Trim().ToLowerInvariant());
                }
            }

            StringBuilder stringBuilder = new();
            foreach (KeyValuePair<string, JsonNode?> keyValuePair_Path in jsonObject_Paths)
            {
                if (pathPrefix is not null && !keyValuePair_Path.Key.StartsWith(pathPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (keyValuePair_Path.Value is not JsonObject jsonObject_Operations)
                {
                    continue;
                }

                foreach (KeyValuePair<string, JsonNode?> keyValuePair_Operation in jsonObject_Operations)
                {
                    if (!methods_Lower.Contains(keyValuePair_Operation.Key) || keyValuePair_Operation.Value is not JsonObject jsonObject_Operation)
                    {
                        continue;
                    }

                    stringBuilder.Append(keyValuePair_Operation.Key.ToUpperInvariant()).Append(' ').Append(keyValuePair_Path.Key);

                    string? summary = Query.SummaryLine(jsonObject_Operation["summary"]?.GetValue<string>(), Constants.Default.MaxSummaryCharacters);
                    if (summary is not null)
                    {
                        stringBuilder.Append(" — ").Append(summary);
                    }

                    if (jsonObject_Operation["parameters"] is JsonArray jsonArray_Parameters && jsonArray_Parameters.Count != 0)
                    {
                        List<string> parameters = [];
                        foreach (JsonNode? jsonNode_Parameter in jsonArray_Parameters)
                        {
                            JsonNode? jsonNode_Parameter_Resolved = Query.Resolved(jsonNode_Parameter, swagger, 1);
                            string? name = jsonNode_Parameter_Resolved?["name"]?.GetValue<string>();
                            if (string.IsNullOrWhiteSpace(name))
                            {
                                continue;
                            }

                            bool required = jsonNode_Parameter_Resolved?["required"] is JsonValue jsonValue_Required && jsonValue_Required.TryGetValue(out bool required_Temp) && required_Temp;
                            string? type = jsonNode_Parameter_Resolved?["schema"]?["type"]?.GetValue<string>();
                            if (type == "array")
                            {
                                type = string.Concat(jsonNode_Parameter_Resolved?["schema"]?["items"]?["type"]?.GetValue<string>() ?? "value", "[]");
                            }

                            parameters.Add(string.Concat(name, required ? "*" : string.Empty, ": ", type ?? "value"));
                        }

                        if (parameters.Count != 0)
                        {
                            stringBuilder.Append(" (").Append(string.Join(", ", parameters)).Append(')');
                        }
                    }

                    string? schemaName = BodySchemaName(jsonObject_Operation["requestBody"]);
                    if (schemaName is not null)
                    {
                        stringBuilder.Append(" body: ").Append(schemaName);
                    }

                    stringBuilder.Append('\n');
                }
            }

            return stringBuilder.Length == 0 ? null : stringBuilder.ToString();

            static string? BodySchemaName(JsonNode? jsonNode_RequestBody)
            {
                if (jsonNode_RequestBody?["content"] is not JsonObject jsonObject_Content)
                {
                    return null;
                }

                foreach (KeyValuePair<string, JsonNode?> keyValuePair in jsonObject_Content)
                {
                    JsonNode? jsonNode_Schema = keyValuePair.Value?["schema"];
                    if (jsonNode_Schema is null)
                    {
                        continue;
                    }

                    string? reference = jsonNode_Schema["$ref"]?.GetValue<string>() ?? jsonNode_Schema["items"]?["$ref"]?.GetValue<string>();
                    string? type = jsonNode_Schema["type"]?.GetValue<string>();
                    if (reference is not null)
                    {
                        string name = reference[(reference.LastIndexOf('/') + 1)..];
                        return type == "array" ? string.Concat(name, "[]") : name;
                    }

                    return type ?? "object";
                }

                return null;
            }
        }
    }
}
