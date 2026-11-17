using DiGi.Harness.Classes;
using System;

namespace DiGi.Harness
{
    public static partial class Query
    {
        /// <summary>
        /// Finds a usable provider by name, or the default provider when <paramref name="name"/> is empty.
        /// <para>Names compare ordinal, ignoring case. A disabled or incomplete provider is never returned.</para>
        /// </summary>
        /// <param name="harnessConfiguration">The configuration.</param>
        /// <param name="name">The provider name, or null for <see cref="HarnessConfiguration.DefaultProviderName"/>.</param>
        /// <returns>The usable provider, or null when none matches.</returns>
        public static ProviderConfiguration? ProviderConfiguration(this HarnessConfiguration? harnessConfiguration, string? name = null)
        {
            if (harnessConfiguration?.Providers is null)
            {
                return null;
            }

            string? name_Temp = string.IsNullOrWhiteSpace(name) ? harnessConfiguration.DefaultProviderName : name;
            if (string.IsNullOrWhiteSpace(name_Temp))
            {
                return null;
            }

            foreach (ProviderConfiguration providerConfiguration in harnessConfiguration.Providers)
            {
                if (string.Equals(providerConfiguration.Name, name_Temp, StringComparison.OrdinalIgnoreCase) && providerConfiguration.IsUsable())
                {
                    return providerConfiguration;
                }
            }

            return null;
        }
    }
}
