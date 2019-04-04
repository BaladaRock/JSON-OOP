using JSONClasses;
using Xunit;

namespace JSONClasses_Tests
{
    public class RangeFacts
    {
        [Fact]
        public void CheckWord_One_Character()
        {
            var word = new Choice(
            new Character('1'),
            new Range('1', '9'),
            new Range('a', 'f'),
            new Range('A', 'F')
            );
            Assert.True(word.Match("a"));
        }

        [Fact]
        public void CheckWord_EmptyString()
        {
            var word = new Choice(
            new Character('1'),
            new Range('1', '9'),
            new Range('a', 'f'),
            new Range('A', 'F')
            );
            Assert.False(word.Match(""));
        }

        [Fact]
        public void CheckWord_Numbers()
        {
            var word = new Choice(
            new Character('1'),
            new Range('1', '9'),
            new Range('a', 'f'),
            new Range('A', 'F')
            );
            Assert.True(word.Match("5"));
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

            var hex = new Choice(
            new Character('0'),
            new Range('1', '9'),
            new Range('a', 'f'),
            new Range('A', 'F')
            );
            Assert.True(hex.Match(input));

        }


       
    }
}
