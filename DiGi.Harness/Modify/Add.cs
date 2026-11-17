using DiGi.Harness.Classes;

namespace DiGi.Harness
{
    public static partial class Modify
    {
        /// <summary>
        /// Appends a message to a conversation; the history is append-only, so this is its only mutation.
        /// <para>Consecutive messages of the same role are kept as they are: both protocols accept them, and merging would edit history already sent.</para>
        /// </summary>
        /// <param name="conversation">The conversation.</param>
        /// <param name="message">The message to append.</param>
        /// <returns>True when the message was appended.</returns>
        public static bool Add(this Conversation? conversation, Message? message)
        {
            if (conversation is null || message is null)
            {
                return false;
            }

            conversation.Append(message);
            return true;
        }
    }
}
