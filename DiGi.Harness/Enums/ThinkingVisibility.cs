namespace DiGi.Harness.Enums
{
    /// <summary>
    /// How much of the model's thinking a client receives.
    /// </summary>
    public enum ThinkingVisibility
    {
        /// <summary>
        /// Not set; treated as <see cref="Summary"/>.
        /// </summary>
        Undefined,

        /// <summary>
        /// Every thinking delta is sent as it arrives.
        /// </summary>
        Full,

        /// <summary>
        /// One short line per thinking block is sent once the block is complete.
        /// </summary>
        Summary,

        /// <summary>
        /// No thinking is sent at all.
        /// </summary>
        None,
    }
}
