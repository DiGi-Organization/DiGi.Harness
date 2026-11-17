using DiGi.Core.Classes;
using DiGi.Harness.Enums;
using DiGi.Harness.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// One message of a conversation: a role and its content blocks.
    /// </summary>
    public class Message : SerializableObject, IHarnessSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Role))]
        private readonly Role role;

        [JsonInclude, JsonPropertyName(nameof(Contents))]
        private readonly List<IContent>? contents;

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="role">The author of the message.</param>
        /// <param name="contents">The content blocks, in order.</param>
        public Message(Role role, IEnumerable<IContent>? contents)
        {
            this.role = role;
            this.contents = contents is null ? null : [.. contents];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class by copying another instance.
        /// </summary>
        /// <param name="message">The instance to copy from.</param>
        public Message(Message? message)
            : base(message)
        {
            if (message is not null)
            {
                role = message.role;
                if (message.contents is not null)
                {
                    contents = [];
                    foreach (IContent content in message.contents)
                    {
                        if (Core.Query.Clone(content) is IContent content_Temp)
                        {
                            contents.Add(content_Temp);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public Message(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the author of the message.
        /// </summary>
        [JsonIgnore]
        public Role Role => role;

        /// <summary>
        /// Gets the content blocks, in order.
        /// </summary>
        [JsonIgnore]
        public IReadOnlyList<IContent>? Contents => contents;
    }
}
