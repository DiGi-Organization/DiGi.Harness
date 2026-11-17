using DiGi.Core.Classes;
using DiGi.Core.Interfaces;
using DiGi.Harness.Enums;
using DiGi.Harness.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// The outcome of one turn: how it stopped, how many steps and tool calls it took, the token usage and the elapsed time.
    /// </summary>
    public class TurnResult : SerializableObject, IHarnessSerializableObject, ISerializableResult
    {
        [JsonInclude, JsonPropertyName(nameof(StopReason))]
        private readonly StopReason stopReason;

        [JsonInclude, JsonPropertyName(nameof(ErrorCategory))]
        private readonly ErrorCategory errorCategory;

        [JsonInclude, JsonPropertyName(nameof(ErrorMessage))]
        private readonly string? errorMessage;

        [JsonInclude, JsonPropertyName(nameof(Steps))]
        private readonly int steps;

        [JsonInclude, JsonPropertyName(nameof(ToolCalls))]
        private readonly int toolCalls;

        [JsonInclude, JsonPropertyName(nameof(Usage))]
        private readonly Usage? usage;

        [JsonInclude, JsonPropertyName(nameof(TotalMilliseconds))]
        private readonly double totalMilliseconds;

        /// <summary>
        /// Initializes a new instance of the <see cref="TurnResult"/> class.
        /// </summary>
        /// <param name="stopReason">The stop reason of the last model request.</param>
        /// <param name="errorCategory">Why the turn did not finish normally, or <see cref="ErrorCategory.Undefined"/>.</param>
        /// <param name="errorMessage">A short, key-free description of the error.</param>
        /// <param name="steps">The number of model requests made.</param>
        /// <param name="toolCalls">The number of tool calls run.</param>
        /// <param name="usage">The token usage summed over every request.</param>
        /// <param name="totalMilliseconds">The duration of the turn in milliseconds.</param>
        public TurnResult(StopReason stopReason, ErrorCategory errorCategory, string? errorMessage, int steps, int toolCalls, Usage? usage, double totalMilliseconds)
        {
            this.stopReason = stopReason;
            this.errorCategory = errorCategory;
            this.errorMessage = errorMessage;
            this.steps = steps;
            this.toolCalls = toolCalls;
            this.usage = usage;
            this.totalMilliseconds = totalMilliseconds;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TurnResult"/> class by copying another instance.
        /// </summary>
        /// <param name="turnResult">The instance to copy from.</param>
        public TurnResult(TurnResult? turnResult)
            : base(turnResult)
        {
            if (turnResult is not null)
            {
                stopReason = turnResult.stopReason;
                errorCategory = turnResult.errorCategory;
                errorMessage = turnResult.errorMessage;
                steps = turnResult.steps;
                toolCalls = turnResult.toolCalls;
                usage = Core.Query.Clone(turnResult.usage);
                totalMilliseconds = turnResult.totalMilliseconds;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TurnResult"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public TurnResult(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the stop reason of the last model request.
        /// </summary>
        [JsonIgnore]
        public StopReason StopReason => stopReason;

        /// <summary>
        /// Gets why the turn did not finish normally, or <see cref="ErrorCategory.Undefined"/>.
        /// </summary>
        [JsonIgnore]
        public ErrorCategory ErrorCategory => errorCategory;

        /// <summary>
        /// Gets a short, key-free description of the error.
        /// </summary>
        [JsonIgnore]
        public string? ErrorMessage => errorMessage;

        /// <summary>
        /// Gets the number of model requests made.
        /// </summary>
        [JsonIgnore]
        public int Steps => steps;

        /// <summary>
        /// Gets the number of tool calls run.
        /// </summary>
        [JsonIgnore]
        public int ToolCalls => toolCalls;

        /// <summary>
        /// Gets the token usage summed over every request.
        /// </summary>
        [JsonIgnore]
        public Usage? Usage => usage;

        /// <summary>
        /// Gets the duration of the turn in milliseconds.
        /// </summary>
        [JsonIgnore]
        public double TotalMilliseconds => totalMilliseconds;
    }
}
