namespace DiGi.Harness.Enums
{
    /// <summary>
    /// How much of a conversation an export contains.
    /// </summary>
    public enum ExportMode
    {
        /// <summary>
        /// Not set; treated as <see cref="Messages"/>.
        /// </summary>
        Undefined,

        /// <summary>
        /// The user and assistant text only.
        /// </summary>
        Messages,

        /// <summary>
        /// The text, the complete thinking text, the tool calls and the tool results.
        /// </summary>
        Full,
    }
}
