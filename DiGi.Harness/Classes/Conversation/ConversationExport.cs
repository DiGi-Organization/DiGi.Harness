using DiGi.Core.Classes;
using DiGi.Harness.Enums;
using DiGi.Harness.Interfaces;
using System;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// A conversation exported to a file: the filtered conversation and the metadata needed to match it to a build.
    /// <para>Build one with <see cref="Create.ConversationExport(Conversation?, ExportMode, DateTimeOffset, string?)"/>.</para>
    /// </summary>
    public class ConversationExport : SerializableObject, IHarnessSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Mode))]
        private readonly ExportMode mode;

        [JsonInclude, JsonPropertyName(nameof(ExportedAt))]
        private readonly DateTimeOffset exportedAt;

        [JsonInclude, JsonPropertyName(nameof(ProviderName))]
        private readonly string? providerName;

        [JsonInclude, JsonPropertyName(nameof(Version))]
        private readonly string? version;

        [JsonInclude, JsonPropertyName(nameof(Conversation))]
        private readonly Conversation? conversation;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConversationExport"/> class.
        /// </summary>
        /// <param name="mode">The export mode used.</param>
        /// <param name="exportedAt">The time of the export.</param>
        /// <param name="providerName">The name of the provider the conversation is locked to.</param>
        /// <param name="version">The version of the harness that produced the export.</param>
        /// <param name="conversation">The filtered conversation.</param>
        public ConversationExport(ExportMode mode, DateTimeOffset exportedAt, string? providerName, string? version, Conversation? conversation)
        {
            this.mode = mode;
            this.exportedAt = exportedAt;
            this.providerName = providerName;
            this.version = version;
            this.conversation = Core.Query.Clone(conversation);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConversationExport"/> class by copying another instance.
        /// </summary>
        /// <param name="conversationExport">The instance to copy from.</param>
        public ConversationExport(ConversationExport? conversationExport)
            : base(conversationExport)
        {
            if (conversationExport is not null)
            {
                mode = conversationExport.mode;
                exportedAt = conversationExport.exportedAt;
                providerName = conversationExport.providerName;
                version = conversationExport.version;
                conversation = Core.Query.Clone(conversationExport.conversation);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConversationExport"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to read from.</param>
        public ConversationExport(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the export mode used.
        /// </summary>
        [JsonIgnore]
        public ExportMode Mode => mode;

        /// <summary>
        /// Gets the time of the export.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset ExportedAt => exportedAt;

        /// <summary>
        /// Gets the name of the provider the conversation is locked to.
        /// </summary>
        [JsonIgnore]
        public string? ProviderName => providerName;

        /// <summary>
        /// Gets the version of the harness that produced the export.
        /// </summary>
        [JsonIgnore]
        public string? Version => version;

        /// <summary>
        /// Gets the filtered conversation.
        /// </summary>
        [JsonIgnore]
        public Conversation? Conversation => conversation;
    }
}
