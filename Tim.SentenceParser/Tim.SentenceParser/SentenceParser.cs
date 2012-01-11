namespace System
{
    public static class SentenceParser
    {
        public static string TrimSentence(this string @string, int length)
        {
            if (TheInputsAreNotValid(length, @string)) return AnEmptyString();
            if (TheStringIsLongerThanTheLengthProvided(length, @string)) return TheOriginalString(@string);

            if (TheNextCharacterIsEmpty(@string, length)) return TheNormallyParsedString(length, @string);

            return TheSentenceEndingAfterThePreviousWord(@string, length);
        }

        private static string TheNormallyParsedString(int length, string @string)
        {
            return @string.Substring(0, length);
        }

        private static bool TheInputsAreNotValid(int length, string @string)
        {
            return length <= 0 || string.IsNullOrEmpty(@string);
        }

        private static string AnEmptyString()
        {
            return string.Empty;
        }

        private static string TheOriginalString(string @string)
        {
            return @string;
        }

        private static bool TheStringIsLongerThanTheLengthProvided(int length, string @string)
        {
            return length >= @string.Length;
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