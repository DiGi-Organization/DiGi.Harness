using DiGi.Harness.Enums;
using DiGi.Harness.Interfaces;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// The outcome of one streamed model request: the assistant message, how it stopped, its usage, or why it failed.
    /// </summary>
    public class CompletionResult : IHarnessObject, Core.Interfaces.IResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompletionResult"/> class.
        /// </summary>
        /// <param name="message">The assistant message, or null when the request failed.</param>
        /// <param name="stopReason">The stop reason.</param>
        /// <param name="usage">The token usage.</param>
        /// <param name="errorCategory">Why the request failed, or <see cref="ErrorCategory.Undefined"/>.</param>
        /// <param name="errorMessage">A short, key-free description of the failure.</param>
        public CompletionResult(Message? message, StopReason stopReason, Usage? usage, ErrorCategory errorCategory, string? errorMessage)
        {
            Message = message;
            StopReason = stopReason;
            Usage = usage;
            ErrorCategory = errorCategory;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Gets the assistant message, or null when the request failed.
        /// </summary>
        public Message? Message { get; }

        /// <summary>
        /// Gets the stop reason.
        /// </summary>
        public StopReason StopReason { get; }

        /// <summary>
        /// Gets the token usage.
        /// </summary>
        public Usage? Usage { get; }

        /// <summary>
        /// Gets why the request failed, or <see cref="ErrorCategory.Undefined"/>.
        /// </summary>
        public ErrorCategory ErrorCategory { get; }

        /// <summary>
        /// Gets a short, key-free description of the failure.
        /// </summary>
        public string? ErrorMessage { get; }
    }
}
