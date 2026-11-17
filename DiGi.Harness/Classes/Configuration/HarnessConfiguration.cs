using DiGi.Core.Classes;
using DiGi.Harness.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// The harness configuration: whether it is enabled, the providers, and the limits of one turn.
    /// <para>Denies by default: a missing file or <see cref="Enabled"/> false turns the harness off. The committed <c>files/Harness.json</c> ships disabled and without keys; the real one belongs in <c>user files/</c>.</para>
    /// </summary>
    public class HarnessConfiguration : SerializableObject, IHarnessSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Enabled))]
        private readonly bool enabled;

        [JsonInclude, JsonPropertyName(nameof(DefaultProviderName))]
        private readonly string? defaultProviderName;

        [JsonInclude, JsonPropertyName(nameof(Providers))]
        private readonly List<ProviderConfiguration>? providers;

        [JsonInclude, JsonPropertyName(nameof(MaxToolIterations))]
        private readonly int maxToolIterations;

        [JsonInclude, JsonPropertyName(nameof(MaxToolResultCharacters))]
        private readonly int maxToolResultCharacters;

        [JsonInclude, JsonPropertyName(nameof(RequestTimeoutSeconds))]
        private readonly int requestTimeoutSeconds;

        [JsonInclude, JsonPropertyName(nameof(AllowedUserIds))]
        private readonly List<string>? allowedUserIds;

        /// <summary>
        /// Initializes a new instance of the <see cref="HarnessConfiguration"/> class.
        /// </summary>
        /// <param name="enabled">Whether the harness is enabled.</param>
        /// <param name="defaultProviderName">The name of the provider selected for a new session.</param>
        /// <param name="providers">The providers.</param>
        /// <param name="maxToolIterations">The maximum number of model requests in one turn; zero or less uses the default.</param>
        /// <param name="maxToolResultCharacters">The maximum number of characters of one tool result; zero or less uses the default.</param>
        /// <param name="requestTimeoutSeconds">The timeout of one model request in seconds; zero or less uses the default.</param>
        /// <param name="allowedUserIds">The users allowed to chat; null or empty allows every signed-in user.</param>
        public HarnessConfiguration(bool enabled, string? defaultProviderName, IEnumerable<ProviderConfiguration>? providers, int maxToolIterations, int maxToolResultCharacters, int requestTimeoutSeconds, IEnumerable<string>? allowedUserIds)
        {
            this.enabled = enabled;
            this.defaultProviderName = defaultProviderName;
            this.providers = providers is null ? null : [.. providers];
            this.maxToolIterations = maxToolIterations;
            this.maxToolResultCharacters = maxToolResultCharacters;
            this.requestTimeoutSeconds = requestTimeoutSeconds;
            this.allowedUserIds = allowedUserIds is null ? null : [.. allowedUserIds];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HarnessConfiguration"/> class by copying another instance.
        /// </summary>
        /// <param name="harnessConfiguration">The instance to copy from.</param>
        public HarnessConfiguration(HarnessConfiguration? harnessConfiguration)
            : base(harnessConfiguration)
        {
            if (harnessConfiguration is not null)
            {
                enabled = harnessConfiguration.enabled;
                defaultProviderName = harnessConfiguration.defaultProviderName;
                if (harnessConfiguration.providers is not null)
                {
                    providers = [];
                    foreach (ProviderConfiguration providerConfiguration in harnessConfiguration.providers)
                    {
                        if (Core.Query.Clone(providerConfiguration) is ProviderConfiguration providerConfiguration_Temp)
                        {
                            providers.Add(providerConfiguration_Temp);
                        }
                    }
                }

                maxToolIterations = harnessConfiguration.maxToolIterations;
                maxToolResultCharacters = harnessConfiguration.maxToolResultCharacters;
                requestTimeoutSeconds = harnessConfiguration.requestTimeoutSeconds;
                allowedUserIds = harnessConfiguration.allowedUserIds is null ? null : [.. harnessConfiguration.allowedUserIds];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HarnessConfiguration"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public HarnessConfiguration(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the harness is enabled; false turns every chat endpoint off.
        /// </summary>
        [JsonIgnore]
        public bool Enabled => enabled;

        /// <summary>
        /// Gets the name of the provider selected for a new session.
        /// </summary>
        [JsonIgnore]
        public string? DefaultProviderName => defaultProviderName;

        /// <summary>
        /// Gets the providers.
        /// </summary>
        [JsonIgnore]
        public IReadOnlyList<ProviderConfiguration>? Providers => providers;

        /// <summary>
        /// Gets the maximum number of model requests in one turn; zero or less uses the default.
        /// </summary>
        [JsonIgnore]
        public int MaxToolIterations => maxToolIterations;

        /// <summary>
        /// Gets the maximum number of characters of one tool result; zero or less uses the default.
        /// </summary>
        [JsonIgnore]
        public int MaxToolResultCharacters => maxToolResultCharacters;

        /// <summary>
        /// Gets the timeout of one model request in seconds; zero or less uses the default.
        /// </summary>
        [JsonIgnore]
        public int RequestTimeoutSeconds => requestTimeoutSeconds;

        /// <summary>
        /// Gets the users allowed to chat; null or empty allows every signed-in user.
        /// </summary>
        [JsonIgnore]
        public IReadOnlyList<string>? AllowedUserIds => allowedUserIds;
    }
}
