using JSONClasses;
using Xunit;

namespace JSONClasses_Tests
{
    public class SequenceFacts
    {
        [Fact]
        public void Should_Return_Modified_Text()
        {
            var word = new Sequence(
            new Character('a'),
            new Character('b')
            );

            var match = word.Match("abcd");
            Assert.Equal("cd", match.RemainingText());
            Assert.True(match.Succes());
        }
    }
}
