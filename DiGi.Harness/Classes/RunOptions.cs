using DiGi.Core.Classes;
using DiGi.Harness.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// Options of one turn of the agent loop.
    /// </summary>
    public class RunOptions : SerializableOptions, IHarnessSerializableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RunOptions"/> class with the default limits and no system prompt.
        /// </summary>
        public RunOptions()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RunOptions"/> class by copying another instance.
        /// </summary>
        /// <param name="runOptions">The instance to copy from.</param>
        public RunOptions(RunOptions? runOptions)
            : base(runOptions)
        {
            if (runOptions is not null)
            {
                SystemPrompt = runOptions.SystemPrompt;
                MaxToolIterations = runOptions.MaxToolIterations;
                MaxToolResultCharacters = runOptions.MaxToolResultCharacters;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RunOptions"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public RunOptions(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets or sets the system prompt sent with every request of the turn.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(SystemPrompt))]
        public string? SystemPrompt { get; set; } = null;

        /// <summary>
        /// Gets or sets the maximum number of model requests in the turn.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(MaxToolIterations))]
        public int MaxToolIterations { get; set; } = Constants.Default.MaxToolIterations;

        /// <summary>
        /// Gets or sets the maximum number of characters of one tool result returned to the model.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(MaxToolResultCharacters))]
        public int MaxToolResultCharacters { get; set; } = Constants.Default.MaxToolResultCharacters;
    }
}
