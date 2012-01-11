using System;
using NUnit.Framework;
using Should;

namespace Tim.SentenceParser.Tests
{
    [TestFixture]
    public class TrimSentenceTests
    {
        [Test]
        public void When_I_am_given_an_empty_string_return_an_empty_string()
        {
            var emptyString = string.Empty;
            var result = emptyString.TrimSentence(50);

            result.ShouldBeEmpty();
        }

        [Test]
        public void When_the_length_is_longer_than_the_length_of_the_string_then_return_the_string()
        {
            var sentence = "This is a fairly long sentence.";

            var result = sentence.TrimSentence(50000);

            result.ShouldEqual(sentence);
        }

        [Test]
        public void When_the_length_is_zero_then_return_an_empty_string()
        {
            var sentence = "A sentence.";

            var result = sentence.TrimSentence(0);

            result.ShouldBeEmpty();
        }

        [Test]
        public void When_the_length_is_in_the_middle_of_a_word_then_end_at_the_previous_word()
        {
            var sentence = "The big sea creature was nice.";

            var result = sentence.TrimSentence(15);

            result.ShouldEqual("The big sea");
        }

        [Test]
        public void When_the_length_is_at_the_position_of_a_whitespace_then_the_substring_should_be_returned()
        {
            var sentence = "The big sea creature was nice.";

            var result = sentence.TrimSentence(12);

            result.ShouldEqual("The big sea");
        }

        [Test]
        public void When_I_am_given_an_empty_string_with_the_ellipsis_option_return_an_empty_string()
        {
            var emptyString = string.Empty;
            var result = emptyString.TrimSentence(50, true);

            result.ShouldBeEmpty();
        }

        [Test]
        public void When_the_length_is_longer_than_the_length_of_the_string_and_there_is_the_ellipsis_option_then_return_the_string()
        {
            var sentence = "This is a fairly long sentence.";

            var result = sentence.TrimSentence(50000, true);

            result.ShouldEqual(sentence);
        }

        [Test]
        public void When_the_length_is_zero_with_the_ellipsis_option_then_return_an_empty_string()
        {
            var sentence = "A sentence.";

            var result = sentence.TrimSentence(0, true);

            result.ShouldBeEmpty();
        }

        [Test]
        public void When_the_length_is_in_the_middle_of_a_word_and_the_ellipsis_is_wanted_then_end_at_the_previous_word_and_add_an_ellipsis()
        {
            var sentence = "The big sea creature was nice.";

            var result = sentence.TrimSentence(15, true);

            result.ShouldEqual("The big sea...");
        }

        [Test]
        public void When_the_length_is_at_the_position_of_a_whitespace_and_the_ellipsis_is_wanted_then_the_substring_with_an_ellipsis_should_be_returned()
        {
            var sentence = "The big sea creature was nice.";

            var result = sentence.TrimSentence(12, true);

            result.ShouldEqual("The big sea...");
        }
    }
}