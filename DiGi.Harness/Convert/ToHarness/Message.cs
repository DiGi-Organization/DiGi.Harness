using DiGi.Harness.Classes;
using DiGi.Harness.Enums;
using DiGi.Harness.Interfaces;
using System.Collections.Generic;

namespace DiGi.Harness
{
    public static partial class Convert
    {
        /// <summary>
        /// Turns the accumulated state of a streamed response into the assistant message, blocks in stream order.
        /// <para>Empty text blocks are dropped. A thinking block is kept when it has text, a signature or redacted data, since an Anthropic block with empty text still has to be replayed. A tool call keeps its input JSON exactly as streamed; an empty input becomes <c>{}</c>.</para>
        /// </summary>
        /// <param name="completionState">The accumulated state.</param>
        /// <returns>The assistant message, or null when <paramref name="completionState"/> is null.</returns>
        public static Message? ToHarness_Message(this CompletionState? completionState)
        {
            if (completionState is null)
            {
                return null;
            }

            List<IContent> contents = [];
            foreach (ContentState contentState in completionState.ContentStates.Values)
            {
                string text = contentState.StringBuilder.ToString();
                switch (contentState.ContentKind)
                {
                    case ContentKind.Text:
                        if (text.Length != 0)
                        {
                            contents.Add(new TextContent(text));
                        }

                        break;

                    case ContentKind.Thinking:
                        if (text.Length != 0 || !string.IsNullOrEmpty(contentState.Signature))
                        {
                            contents.Add(new ThinkingContent(text, contentState.Signature, null));
                        }

                        break;

                    case ContentKind.RedactedThinking:
                        if (!string.IsNullOrEmpty(contentState.RedactedData))
                        {
                            contents.Add(new ThinkingContent(null, null, contentState.RedactedData));
                        }

                        break;

                    case ContentKind.ToolUse:
                        contents.Add(new ToolUseContent(contentState.Id, contentState.Name, text.Length == 0 ? "{}" : text));
                        break;
                }
            }

            return new Message(Role.Assistant, contents);
        }
    }
}
