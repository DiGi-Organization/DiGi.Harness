namespace DiGi.Harness
{
    public static partial class Query
    {
        /// <summary>
        /// Shortens a text to one summary line: its first sentence or first line, cut to <paramref name="maxCharacters"/> with an ellipsis.
        /// <para>Markdown emphasis and heading markers at the start are dropped, so a thinking summary such as <c>**Checking counties**</c> reads as plain text.</para>
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="maxCharacters">The maximum length of the line, ellipsis included; values below 10 use 10.</param>
        /// <returns>The summary line, or null when the text is empty.</returns>
        public static string? SummaryLine(this string? text, int maxCharacters)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            int maxCharacters_Temp = maxCharacters < 10 ? 10 : maxCharacters;

            string result = text.Trim().TrimStart('#', '*', '_', ' ', '-');

            int index_Line = result.IndexOf('\n');
            if (index_Line > 0)
            {
                result = result[..index_Line];
            }

            for (int i = 0; i < result.Length - 1; i++)
            {
                char @char = result[i];
                if (@char != '.' && @char != '!' && @char != '?')
                {
                    continue;
                }

                int index_Next = i + 1;
                while (index_Next < result.Length && (result[index_Next] == '*' || result[index_Next] == '_'))
                {
                    index_Next++;
                }

                if (index_Next < result.Length && char.IsWhiteSpace(result[index_Next]))
                {
                    result = result[..(i + 1)];
                    break;
                }
            }

            result = result.Trim().TrimEnd('*', '_', ' ');

            if (result.Length > maxCharacters_Temp)
            {
                result = string.Concat(result[..(maxCharacters_Temp - 1)].TrimEnd(), "…");
            }

            return result.Length == 0 ? null : result;
        }
    }
}
