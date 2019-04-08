using JSONClasses;
using Xunit;

namespace JSONClasses_Tests
{
    public class ManyFacts
    {
        [Fact]
        public void Should_Return_True_Simple_Case()
        {
            var pattern = new Many(
            new Character('a'));

            var match = pattern.Match("abc");

            Assert.Equal("bc", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_True_Repeated_Pattern()
        {
            var pattern = new Many(
            new Character('a'));

            var match = pattern.Match("aaaaaabc");

            Assert.Equal("bc", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return__Empty_String_When_Pattern_Is_Equal_To_String()
        {
            var pattern = new Many(
            new Range('a','d'));

            var match = pattern.Match("aaaaaabc");

            Assert.Equal("", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return__Original_String()
        {
            var pattern = new Many(
            new Range('a', 'd'));

            var match = pattern.Match("RMN");

            Assert.Equal("RMN", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return__Empty_String()
        {
            var pattern = new Many(
            new Range('a', 'd'));

            var match = pattern.Match("");

            Assert.Equal("", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return__Null()
        {
            var pattern = new Many(
            new Range('a', 'd'));

            var match = pattern.Match(null);

            Assert.Null(match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return__Correct_String_More_Complicated_Case()
        {
            var pattern = new Many(
            new Range('a', 'd'));

            var match = pattern.Match("abcd1234abc");

            Assert.Equal("1234abc", match.RemainingText());
            Assert.True(match.Success());
        }

    }
}
