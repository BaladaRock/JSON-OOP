using JSONClasses;
using Xunit;

namespace JSONClasses_Tests
{
    public class TextFacts
    {
        [Fact]
        public void Should_Return_True_PrefixedString__Words_are_Identical()
        {
            var word = new Text("rock");
            var match = word.Match("rock");

            Assert.Equal("", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_Remaining_String_True_Case()
        {
            var word = new Text("rock");
            var match = word.Match("rockBalada");

            Assert.Equal("Balada", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_Initial_String_False_Case()
        {
            var word = new Text("ABC");
            var match = word.Match("rockBalada");

            Assert.Equal("rockBalada", match.RemainingText());
            Assert.False(match.Success());
        }

        [Fact]
        public void Should_Return_False_Empty_String()
        {
            var word = new Text("ABC");
            var match = word.Match("");

            Assert.Equal("", match.RemainingText());
            Assert.False(match.Success());
        }

        [Fact]
        public void Should_Return_False_Null_String()
        {
            var word = new Text("ABC");
            var match = word.Match(null);

            Assert.Null(match.RemainingText());
            Assert.False(match.Success());
        }

        [Fact]
        public void Should_Return_False_Prefix_Is_Empty()
        {
            var word = new Text("");
            var match = word.Match(null);

            Assert.Null(match.RemainingText());
            Assert.False(match.Success());
        }

        [Fact]
        public void Should_Return_False_Prefix_Is_Null()
        {
            var word = new Text(null);
            var match = word.Match("Rock");

            Assert.Equal("Rock", match.RemainingText());
            Assert.False(match.Success());
        }
    }
}