using DiGi.Core.Classes;
using DiGi.Harness.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// A text block of a conversation message.
    /// </summary>
    public class TextContent : SerializableObject, IContent
    {
        [JsonInclude, JsonPropertyName(nameof(Text))]
        private readonly string? text;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextContent"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        public TextContent(string? text)
        {
            this.text = text;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextContent"/> class by copying another instance.
        /// </summary>
        /// <param name="textContent">The instance to copy from.</param>
        public TextContent(TextContent? textContent)
            : base(textContent)
        {
            if (textContent is not null)
            {
                text = textContent.text;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextContent"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public TextContent(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        [JsonIgnore]
        public string? Text => text;
    }
}
