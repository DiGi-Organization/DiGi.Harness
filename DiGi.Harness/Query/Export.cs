using DiGi.Harness.Classes;
using DiGi.Harness.Enums;
using DiGi.Harness.Interfaces;
using System.Collections.Generic;

namespace DiGi.Harness
{
    public static partial class Query
    {
        /// <summary>
        /// Builds the copy of a conversation written to an export file.
        /// <para><see cref="ExportMode.Messages"/> (and <see cref="ExportMode.Undefined"/>) keeps the text only; <see cref="ExportMode.Full"/> also keeps the complete thinking text, the tool calls and the tool results. Thinking signatures and redacted thinking data are never copied. A message left without content is dropped; order and roles are kept. The source conversation is not modified.</para>
        /// </summary>
        /// <param name="conversation">The conversation.</param>
        /// <param name="exportMode">The export mode.</param>
        /// <returns>The filtered copy, or null when <paramref name="conversation"/> is null.</returns>
        public static Conversation? Export(this Conversation? conversation, ExportMode exportMode)
        {
            if (conversation is null)
            {
                return null;
            }

            bool full = exportMode == ExportMode.Full;

            List<Message> messages = [];
            foreach (Message message in conversation.Messages)
            {
                List<IContent> contents = [];
                foreach (IContent content in message.Contents ?? [])
                {
                    if (content is ThinkingContent thinkingContent)
                    {
                        if (full && !string.IsNullOrWhiteSpace(thinkingContent.Text))
                        {
                            contents.Add(new ThinkingContent(thinkingContent.Text, null, null));
                        }

                        continue;
                    }

                    if (!full && content is not TextContent)
                    {
                        continue;
                    }

                    if (Core.Query.Clone(content) is IContent content_Clone)
                    {
                        contents.Add(content_Clone);
                    }
                }

                if (contents.Count != 0)
                {
                    messages.Add(new Message(message.Role, contents));
                }
            }

            return new Conversation(conversation.ProviderName, messages);
        }
    }
}
