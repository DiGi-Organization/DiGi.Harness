namespace DiGi.Harness.Enums
{
    /// <summary>
    /// The author of a conversation message.
    /// </summary>
    public enum Role
    {
        /// <summary>
        /// The role is not set.
        /// </summary>
        Undefined,

        /// <summary>
        /// A message written by the user, or tool results returned on the user's side of the conversation.
        /// </summary>
        User,

        /// <summary>
        /// A message produced by the model.
        /// </summary>
        Assistant,
    }
}
