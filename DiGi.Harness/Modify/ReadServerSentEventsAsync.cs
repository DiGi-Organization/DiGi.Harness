using DiGi.Harness.Classes;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.Harness
{
    public static partial class Modify
    {
        /// <summary>
        /// Reads a <c>text/event-stream</c> to its end and hands each event to <paramref name="func"/>.
        /// <para>Follows the SSE format: lines are <c>field: value</c>; <c>data</c> lines of one event are joined with <c>\n</c>; a blank line ends the event; lines starting with <c>:</c> are comments. An event without data is skipped. A last event not followed by a blank line is still delivered.</para>
        /// </summary>
        /// <param name="stream">The response stream.</param>
        /// <param name="func">The handler called for every event, in order.</param>
        /// <param name="cancellationToken">The token that stops reading.</param>
        /// <returns>The number of events delivered.</returns>
        public static async Task<int> ReadServerSentEventsAsync(this Stream? stream, Func<ServerSentEvent, CancellationToken, Task>? func, CancellationToken cancellationToken = default)
        {
            if (stream is null || func is null)
            {
                return 0;
            }

            int result = 0;
            string? name = null;
            StringBuilder stringBuilder = new();
            bool hasData = false;

            using StreamReader streamReader = new(stream, Encoding.UTF8);
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                string? line = await streamReader.ReadLineAsync(cancellationToken).ConfigureAwait(false);
                if (line is null)
                {
                    break;
                }

                if (line.Length == 0)
                {
                    if (hasData)
                    {
                        await func(new ServerSentEvent(name, stringBuilder.ToString()), cancellationToken).ConfigureAwait(false);
                        result++;
                    }

                    name = null;
                    stringBuilder.Clear();
                    hasData = false;
                    continue;
                }

                if (line[0] == ':')
                {
                    continue;
                }

                int index = line.IndexOf(':');
                string field = index < 0 ? line : line[..index];
                string value = index < 0 ? string.Empty : line[(index + 1)..];
                if (value.Length != 0 && value[0] == ' ')
                {
                    value = value[1..];
                }

                switch (field)
                {
                    case "event":
                        name = value;
                        break;

                    case "data":
                        if (hasData)
                        {
                            stringBuilder.Append('\n');
                        }

                        stringBuilder.Append(value);
                        hasData = true;
                        break;
                }
            }

            if (hasData)
            {
                await func(new ServerSentEvent(name, stringBuilder.ToString()), cancellationToken).ConfigureAwait(false);
                result++;
            }

            return result;
        }
    }
}
