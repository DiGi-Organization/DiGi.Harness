using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DiGi.Harness
{
    public static partial class Create
    {
        /// <summary>
        /// Loads the harness configuration from <c>Harness.json</c>.
        /// <para>Looks at <paramref name="path"/>, then the application base directory, then the working directory. Fails closed: a missing or unreadable file returns a disabled configuration with no providers. The <c>_type</c> discriminators may be left out of the hand-written file; they are filled in before reading. Keys are never logged.</para>
        /// </summary>
        /// <param name="path">An explicit path to the configuration file, or null to search the default locations.</param>
        /// <returns>The loaded configuration, or a disabled one.</returns>
        public static Classes.HarnessConfiguration HarnessConfiguration(string? path = null)
        {
            List<string> paths = [];
            if (!string.IsNullOrWhiteSpace(path))
            {
                paths.Add(path);
            }

            paths.Add(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Constants.FileName.Harness));
            paths.Add(Path.Combine(Directory.GetCurrentDirectory(), Constants.FileName.Harness));

            string? path_Resolved = paths.Find(File.Exists);
            if (path_Resolved is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Harness: no {FileName} found - the harness is disabled.", Constants.FileName.Harness);
                return new Classes.HarnessConfiguration(false, null, null, 0, 0, 0, null);
            }

            try
            {
                if (JsonNode.Parse(File.ReadAllText(path_Resolved)) is not JsonObject jsonObject)
                {
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Harness: {Path} is not a JSON object - the harness is disabled.", path_Resolved);
                    return new Classes.HarnessConfiguration(false, null, null, 0, 0, 0, null);
                }

                string? typeName_Configuration = Core.Query.FullTypeName(typeof(Classes.HarnessConfiguration));
                string? typeName_Provider = Core.Query.FullTypeName(typeof(Classes.ProviderConfiguration));

                jsonObject[Core.Constants.Serialization.PropertyName.Type] = typeName_Configuration;
                if (jsonObject[nameof(Classes.HarnessConfiguration.Providers)] is JsonArray jsonArray_Providers)
                {
                    foreach (JsonNode? jsonNode_Provider in jsonArray_Providers)
                    {
                        if (jsonNode_Provider is JsonObject jsonObject_Provider)
                        {
                            jsonObject_Provider[Core.Constants.Serialization.PropertyName.Type] = typeName_Provider;
                        }
                    }
                }

                Classes.HarnessConfiguration harnessConfiguration = new(jsonObject);

                Serilog.Modify.Log("Harness: {Path} loaded (Enabled={Enabled}, Providers={Count}).", path_Resolved, harnessConfiguration.Enabled, harnessConfiguration.Providers?.Count ?? 0);
                return harnessConfiguration;
            }
            catch (Exception exception) when (exception is JsonException or IOException or UnauthorizedAccessException)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Harness: {Path} could not be read ({Error}) - the harness is disabled.", path_Resolved, exception.GetType().Name);
                return new Classes.HarnessConfiguration(false, null, null, 0, 0, 0, null);
            }
        }
    }
}
