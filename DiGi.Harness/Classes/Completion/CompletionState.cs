using DiGi.Harness.Enums;
using DiGi.Harness.Interfaces;
using System.Collections.Generic;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// The state of one streamed model response while it is being read.
    /// <para>Filled by <see cref="Modify.Update_Anthropic(CompletionState?, System.Text.Json.Nodes.JsonObject?, double)"/> or <see cref="Modify.Update_OpenAI(CompletionState?, System.Text.Json.Nodes.JsonObject?, double)"/> and turned into a message by <see cref="Convert.ToHarness_Message(CompletionState?)"/>.</para>
    /// </summary>
    public class CompletionState : IHarnessObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompletionState"/> class.
        /// </summary>
        /// <param name="protocol">The protocol of the stream.</param>
        public CompletionState(Protocol protocol)
        {
            Protocol = protocol;
        }

        /// <summary>
        /// Gets the protocol of the stream.
        /// </summary>
        public Protocol Protocol { get; }

        /// <summary>
        /// Gets the content blocks keyed by their position: the Anthropic block index, or for OpenAI 0 for reasoning, 1 for text and 2 + index for tool calls.
        /// </summary>
        public SortedDictionary<int, ContentState> ContentStates { get; } = [];

        /// <summary>
        /// Gets or sets the stop reason.
        /// </summary>
        public StopReason StopReason { get; set; }

        /// <summary>
        /// Gets or sets the uncached input tokens.
        /// </summary>
        public int InputTokens { get; set; }

        /// <summary>
        /// Gets or sets the output tokens.
        /// </summary>
        public int OutputTokens { get; set; }

        /// <summary>
        /// Gets or sets the input tokens read from the prompt cache.
        /// </summary>
        public int CacheReadInputTokens { get; set; }

        /// <summary>
        /// Gets or sets the input tokens written to the prompt cache.
        /// </summary>
        public int CacheCreationInputTokens { get; set; }

        /// <summary>
        /// Gets or sets the error reported inside the stream, or null.
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the refusal explanation reported with a refusal stop reason, or null.
        /// </summary>
        public string? RefusalMessage { get; set; }
    }
}
