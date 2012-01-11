namespace System
{
    public static class SentenceParser
    {
        public static string TrimSentence(this string @string, int length)
        {
            if (length <= 0 || string.IsNullOrEmpty(@string)) return string.Empty;
            if (length >= @string.Length) return @string;

            if (TheNextCharacterIsEmpty(@string, length)) return @string.Substring(0, length);

            return TheSentenceEndingAfterThePreviousWord(@string, length);
        }

        public static string TrimSentence(this string @string, int length, bool addEllipsis)
        {
            return TrimSentence(@string, length) + (ShouldAddAnEllipsis(addEllipsis, @string, length) ? "..." : string.Empty);
        }

        private static bool ShouldAddAnEllipsis(bool addEllipsis, string @string, int length)
        {
            return addEllipsis && @string.Length > length && length > 0;
        }

        private static string TheSentenceEndingAfterThePreviousWord(string @string, int length)
        {
            var lastSpaceIndex = @string.Substring(0, length).LastIndexOf(" ");
            return @string.Substring(0, lastSpaceIndex);
        }

        private static bool TheNextCharacterIsEmpty(string @string, int length)
        {
            return @string[length + 1] == ' ';
        }
    }
}