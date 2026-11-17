using DiGi.Harness.Enums;
using DiGi.Harness.Interfaces;
using System.Text;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// One content block being accumulated from a streamed response.
    /// </summary>
    public class ContentState : IHarnessObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentState"/> class.
        /// </summary>
        /// <param name="contentKind">The kind of block.</param>
        public ContentState(ContentKind contentKind)
        {
            ContentKind = contentKind;
        }

        /// <summary>
        /// Gets the kind of block.
        /// </summary>
        public ContentKind ContentKind { get; }

        /// <summary>
        /// Gets the accumulated text: answer text, thinking text, or the tool input JSON.
        /// </summary>
        public StringBuilder StringBuilder { get; } = new();

        /// <summary>
        /// Gets or sets the Anthropic signature of a thinking block.
        /// </summary>
        public string? Signature { get; set; }

        /// <summary>
        /// Gets or sets the opaque data of a redacted thinking block.
        /// </summary>
        public string? RedactedData { get; set; }

        /// <summary>
        /// Gets or sets the identifier of a tool call.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the tool name of a tool call.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the block is complete.
        /// </summary>
        public bool Completed { get; set; }
    }
}
