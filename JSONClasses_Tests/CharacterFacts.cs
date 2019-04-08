using JSONClasses;
using Xunit;

namespace JSONClasses_Tests
{
    public class CharacterFacts
    {
        [Fact]
        public void Should_Return_Empty_String()
        {
            IMatch match = new SuccessMatch("");
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void Check_Returned_String_Number()
        {
            var character = new Character('1');
            IMatch match = character.Match("12");
            Assert.True(match.Success());
            Assert.Equal("2", match.RemainingText());
        }

    }
}
