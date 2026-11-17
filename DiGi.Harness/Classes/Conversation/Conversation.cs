using DiGi.Core.Classes;
using DiGi.Harness.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// A conversation with one provider: the ordered messages exchanged so far.
    /// <para>The history is append-only (<see cref="Modify.Add(Conversation?, Message?)"/>): Anthropic thinking blocks are valid only in the exact conversation that produced them, so a message is never edited or removed once added.</para>
    /// </summary>
    public class Conversation : SerializableObject, IHarnessSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(ProviderName))]
        private readonly string? providerName;

        [JsonInclude, JsonPropertyName(nameof(Messages))]
        private readonly List<Message> messages = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="Conversation"/> class.
        /// </summary>
        /// <param name="providerName">The name of the provider the conversation is locked to.</param>
        /// <param name="messages">The messages exchanged so far.</param>
        public Conversation(string? providerName, IEnumerable<Message>? messages)
        {
            this.providerName = providerName;
            if (messages is not null)
            {
                this.messages = [.. messages];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Conversation"/> class by copying another instance.
        /// </summary>
        /// <param name="conversation">The instance to copy from.</param>
        public Conversation(Conversation? conversation)
            : base(conversation)
        {
            if (conversation is not null)
            {
                providerName = conversation.providerName;
                foreach (Message message in conversation.messages)
                {
                    if (Core.Query.Clone(message) is Message message_Temp)
                    {
                        messages.Add(message_Temp);
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Conversation"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public Conversation(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the name of the provider the conversation is locked to.
        /// </summary>
        [JsonIgnore]
        public string? ProviderName => providerName;

        /// <summary>
        /// Gets the messages exchanged so far.
        /// </summary>
        [JsonIgnore]
        public IReadOnlyList<Message> Messages => messages;

        /// <summary>
        /// Appends a message; the only mutation the history allows.
        /// </summary>
        /// <param name="message">The message to append.</param>
        internal void Append(Message message)
        {
            messages.Add(message);
        }
    }
}
