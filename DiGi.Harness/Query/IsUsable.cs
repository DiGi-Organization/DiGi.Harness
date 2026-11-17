using DiGi.Harness.Classes;
using DiGi.Harness.Enums;
using System;

namespace DiGi.Harness
{
    public static partial class Query
    {
        /// <summary>
        /// Checks that a provider can be called: enabled, with a protocol, an absolute HTTP(S) base URI, a model and a name.
        /// <para>The key is not checked: a local server needs none, and a provider that needs one answers 401, reported as an upstream fault.</para>
        /// </summary>
        /// <param name="providerConfiguration">The provider.</param>
        /// <returns>True when the provider can be called.</returns>
        public static bool IsUsable(this ProviderConfiguration? providerConfiguration)
        {
            if (providerConfiguration is null || !providerConfiguration.Enabled)
            {
                return false;
            }

            if (providerConfiguration.Protocol == Protocol.Undefined || string.IsNullOrWhiteSpace(providerConfiguration.Name) || string.IsNullOrWhiteSpace(providerConfiguration.Model))
            {
                return false;
            }

            if (!Uri.TryCreate(providerConfiguration.BaseUri, UriKind.Absolute, out Uri? uri))
            {
                return false;
            }

            return uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps;
        }
    }
}
