using JSONClasses;
using Xunit;

namespace JSONClasses_Tests
{
    public class RangeFacts
    {
        [Fact]
        public void CheckWord_One_Character()
        {
            var range = new Range('a', 'e');
            var match = range.Match("a");
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CheckWord_EmptyString()
        {
            var range = new Range('1', '0');
            IMatch match = range.Match("");
            Assert.False(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CheckWord_Numbers()
        {
            var range = new Range('1', '9');
            IMatch match = new SuccessMatch("5");
            Assert.True(match.Success());
            Assert.Equal("5", match.RemainingText());
        }

        [Theory]
        [InlineData("012")]
        [InlineData("92")]
        [InlineData("a9")]
        [InlineData("A5")]
        [InlineData("B3")]
        [InlineData("f6")]
        public void Check__Word_HasHexadecimal_Characters_(string input)
        {
            var hex = new SuccessMatch(input);

            Assert.True(hex.Success());
        }
    }
}