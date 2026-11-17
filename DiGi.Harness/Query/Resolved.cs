using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace DiGi.Harness
{
    public static partial class Query
    {
        /// <summary>
        /// Copies a JSON node from an OpenAPI document with its local <c>$ref</c>s (<c>#/components/...</c>) replaced by the referenced nodes, down to <paramref name="depth"/> levels of references.
        /// <para>A reference beyond the depth, or one that cannot be resolved, stays as <c>{"$ref": ...}</c>; <c>example</c> and <c>examples</c> members are dropped to keep the result short.</para>
        /// </summary>
        /// <param name="jsonNode">The node to copy.</param>
        /// <param name="swagger">The OpenAPI document the references point into.</param>
        /// <param name="depth">How many levels of references to resolve.</param>
        /// <returns>The copied node with references resolved, or null when <paramref name="jsonNode"/> is null.</returns>
        public static JsonNode? Resolved(this JsonNode? jsonNode, JsonObject? swagger, int depth)
        {
            if (jsonNode is null)
            {
                return null;
            }

            if (jsonNode is JsonArray jsonArray)
            {
                JsonArray jsonArray_Result = [];
                foreach (JsonNode? jsonNode_Item in jsonArray)
                {
                    jsonArray_Result.Add(Resolved(jsonNode_Item, swagger, depth));
                }

                return jsonArray_Result;
            }

            if (jsonNode is not JsonObject jsonObject)
            {
                return jsonNode.DeepClone();
            }

            if (jsonObject["$ref"] is JsonValue jsonValue_Ref && jsonValue_Ref.TryGetValue(out string? reference) && reference is not null)
            {
                if (depth > 0 && swagger is not null && reference.StartsWith("#/", StringComparison.Ordinal))
                {
                    JsonNode? jsonNode_Target = swagger;
                    foreach (string segment in reference[2..].Split('/'))
                    {
                        jsonNode_Target = (jsonNode_Target as JsonObject)?[segment.Replace("~1", "/", StringComparison.Ordinal).Replace("~0", "~", StringComparison.Ordinal)];
                        if (jsonNode_Target is null)
                        {
                            break;
                        }
                    }

                    if (jsonNode_Target is not null)
                    {
                        return Resolved(jsonNode_Target, swagger, depth - 1);
                    }
                }

                return new JsonObject { ["$ref"] = reference };
            }

            JsonObject jsonObject_Result = [];
            foreach (KeyValuePair<string, JsonNode?> keyValuePair in jsonObject)
            {
                if (keyValuePair.Key == "example" || keyValuePair.Key == "examples")
                {
                    continue;
                }

                jsonObject_Result[keyValuePair.Key] = Resolved(keyValuePair.Value, swagger, depth);
            }

            return jsonObject_Result;
        }
    }
}
