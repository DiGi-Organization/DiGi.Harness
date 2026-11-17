using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace DiGi.Harness
{
    public static partial class Query
    {
        /// <summary>
        /// Finds the OpenAPI path template an actual request path matches, for one HTTP method.
        /// <para>A literal segment compares ordinal, ignoring case; a <c>{parameter}</c> segment matches any one non-empty segment. A path that is absolute (<c>http://</c>), protocol-relative (<c>//host</c>), contains <c>..</c>, a backslash, a percent-encoding, a query (<c>?</c>) or a fragment (<c>#</c>) never matches, so the result is safe to append to a fixed base URI.</para>
        /// </summary>
        /// <param name="swagger">The OpenAPI document.</param>
        /// <param name="method">The HTTP method, any case (<c>GET</c>, <c>post</c>).</param>
        /// <param name="path">The request path, starting with <c>/</c>.</param>
        /// <returns>The matched path template as written in the document, or null when nothing matches.</returns>
        public static string? PathTemplate(this JsonObject? swagger, string? method, string? path)
        {
            if (swagger is null || string.IsNullOrWhiteSpace(method) || string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            if (!path.StartsWith('/') || path.StartsWith("//", StringComparison.Ordinal) || path.Contains("..", StringComparison.Ordinal) || path.Contains('\\') || path.Contains('%') || path.Contains('?') || path.Contains('#') || path.Contains("://", StringComparison.Ordinal))
            {
                return null;
            }

            if (swagger["paths"] is not JsonObject jsonObject_Paths)
            {
                return null;
            }

            string method_Lower = method.Trim().ToLowerInvariant();
            string[] segments = path.TrimEnd('/').Split('/');

            foreach (KeyValuePair<string, JsonNode?> keyValuePair in jsonObject_Paths)
            {
                if (keyValuePair.Value is not JsonObject jsonObject_Operations || !jsonObject_Operations.ContainsKey(method_Lower))
                {
                    continue;
                }

                string[] segments_Template = keyValuePair.Key.TrimEnd('/').Split('/');
                if (segments_Template.Length != segments.Length)
                {
                    continue;
                }

                bool matches = true;
                for (int i = 0; i < segments.Length; i++)
                {
                    string segment_Template = segments_Template[i];
                    if (segment_Template.StartsWith('{') && segment_Template.EndsWith('}'))
                    {
                        if (segments[i].Length == 0)
                        {
                            matches = false;
                            break;
                        }

                        continue;
                    }

                    if (!string.Equals(segment_Template, segments[i], StringComparison.OrdinalIgnoreCase))
                    {
                        matches = false;
                        break;
                    }
                }

                if (matches)
                {
                    return keyValuePair.Key;
                }
            }

            return null;
        }
    }
}
