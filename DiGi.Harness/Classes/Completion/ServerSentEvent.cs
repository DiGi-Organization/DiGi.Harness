using DiGi.Harness.Interfaces;

namespace DiGi.Harness.Classes
{
    /// <summary>
    /// One event of a <c>text/event-stream</c>: its optional event name and its data (multi-line data joined with <c>\n</c>).
    /// </summary>
    public class ServerSentEvent : IHarnessObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerSentEvent"/> class.
        /// </summary>
        /// <param name="name">The event name from the <c>event:</c> field, or null.</param>
        /// <param name="data">The data from the <c>data:</c> fields.</param>
        public ServerSentEvent(string? name, string? data)
        {
            Name = name;
            Data = data;
        }

        /// <summary>
        /// Gets the event name from the <c>event:</c> field, or null.
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// Gets the data from the <c>data:</c> fields.
        /// </summary>
        public string? Data { get; }
    }
}
