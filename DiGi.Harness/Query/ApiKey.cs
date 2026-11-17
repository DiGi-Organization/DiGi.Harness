using DiGi.Harness.Classes;
using System;

namespace DiGi.Harness
{
    public static partial class Query
    {
        /// <summary>
        /// Resolves the API key of a provider: <see cref="ProviderConfiguration.Key"/>, or else the environment variable named by <see cref="ProviderConfiguration.KeyEnvironmentVariable"/>.
        /// <para>Never log the result or return it to a client.</para>
        /// </summary>
        /// <param name="providerConfiguration">The provider.</param>
        /// <returns>The API key, or null when none is configured (a local server).</returns>
        public static string? ApiKey(this ProviderConfiguration? providerConfiguration)
        {
            if (providerConfiguration is null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(providerConfiguration.Key))
            {
                return providerConfiguration.Key;
            }

            if (string.IsNullOrWhiteSpace(providerConfiguration.KeyEnvironmentVariable))
            {
                return null;
            }

            string? key = Environment.GetEnvironmentVariable(providerConfiguration.KeyEnvironmentVariable);
            return string.IsNullOrWhiteSpace(key) ? null : key;
        }
    }
}
