using DiGi.Harness.Classes;
using DiGi.Harness.Enums;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;

namespace DiGi.Harness
{
    public static partial class Create
    {
        /// <summary>
        /// Builds the streamed HTTP request of one model call: the endpoint URI, the protocol headers and the JSON body.
        /// <para>Anthropic: <c>{BaseUri}/v1/messages</c> with <c>x-api-key</c>, <c>anthropic-version</c> and, when fallbacks are on, <c>anthropic-beta</c>. OpenAI: <c>{BaseUri}/chat/completions</c> with <c>Authorization: Bearer</c> when a key is configured.</para>
        /// </summary>
        /// <param name="providerConfiguration">The provider.</param>
        /// <param name="body">The request body built by <see cref="Convert.ToAnthropic_JsonObject(Conversation?, ProviderConfiguration?, System.Collections.Generic.IEnumerable{ToolDefinition}?, string?)"/> or <see cref="Convert.ToOpenAI_JsonObject(Conversation?, ProviderConfiguration?, System.Collections.Generic.IEnumerable{ToolDefinition}?, string?)"/>.</param>
        /// <returns>The request, or null when the provider is not usable or the body is null.</returns>
        public static HttpRequestMessage? HttpRequestMessage(this ProviderConfiguration? providerConfiguration, JsonObject? body)
        {
            if (body is null || !Query.IsUsable(providerConfiguration) || providerConfiguration?.BaseUri is null)
            {
                return null;
            }

            string relativePath = providerConfiguration.Protocol == Protocol.Anthropic ? Constants.Anthropic.MessagesPath : Constants.OpenAI.ChatCompletionsPath;
            Uri uri = new(string.Concat(providerConfiguration.BaseUri.TrimEnd('/'), "/", relativePath));

            HttpRequestMessage result = new(HttpMethod.Post, uri)
            {
                Content = new StringContent(body.ToJsonString(), Encoding.UTF8, "application/json"),
            };

            result.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/event-stream"));

            string? apiKey = Query.ApiKey(providerConfiguration);
            switch (providerConfiguration.Protocol)
            {
                case Protocol.Anthropic:
                    if (apiKey is not null)
                    {
                        result.Headers.TryAddWithoutValidation("x-api-key", apiKey);
                    }

                    result.Headers.TryAddWithoutValidation("anthropic-version", Constants.Anthropic.Version);
                    if (providerConfiguration.AnthropicFallbacks)
                    {
                        result.Headers.TryAddWithoutValidation("anthropic-beta", Constants.Anthropic.FallbackBeta);
                    }

                    break;

                case Protocol.OpenAI:
                    if (apiKey is not null)
                    {
                        result.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                    }

                    break;
            }

            return result;
        }
    }
}
