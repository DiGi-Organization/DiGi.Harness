using DiGi.Harness.Classes;
using DiGi.Harness.Enums;
using System;

namespace DiGi.Harness
{
    public static partial class Create
    {
        /// <summary>
        /// Builds the export of a conversation.
        /// <para>The conversation is filtered with <see cref="Query.Export(Conversation?, ExportMode)"/>; <see cref="ExportMode.Undefined"/> is stored as <see cref="ExportMode.Messages"/>.</para>
        /// </summary>
        /// <param name="conversation">The conversation.</param>
        /// <param name="exportMode">The export mode.</param>
        /// <param name="exportedAt">The time of the export.</param>
        /// <param name="version">The version of the harness that produced the export (for example the assembly informational version).</param>
        /// <returns>The export, or null when <paramref name="conversation"/> is null.</returns>
        public static Classes.ConversationExport? ConversationExport(Conversation? conversation, ExportMode exportMode, DateTimeOffset exportedAt, string? version)
        {
            if (conversation is null)
            {
                return null;
            }

            ExportMode exportMode_Resolved = exportMode == ExportMode.Full ? ExportMode.Full : ExportMode.Messages;

            return new Classes.ConversationExport(exportMode_Resolved, exportedAt, conversation.ProviderName, version, conversation.Export(exportMode_Resolved));
        }
    }
}
