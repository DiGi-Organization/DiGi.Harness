namespace DiGi.Harness.Interfaces
{
    /// <summary>
    /// An event emitted while a turn runs, streamed to the client.
    /// </summary>
    public interface IHarnessEvent : IHarnessSerializableObject
    {
        /// <summary>
        /// Gets the time elapsed since the turn started, in milliseconds.
        /// </summary>
        double ElapsedMilliseconds { get; }
    }
}
