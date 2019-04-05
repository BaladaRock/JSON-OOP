using JSONClasses;
using Xunit;

namespace JSONClasses_Tests
{
    public class CharacterFacts
    {
        [Fact]
        public void Check_Returned_String_Empty()
        {
            IMatch match = new SuccessMatch("");
            Assert.True(match.Succes());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void Check_Returned_String_Number()
        {
            IMatch match = new SuccessMatch("12");
            Assert.True(match.Succes());
            Assert.Equal("12", match.RemainingText());
        }

    }
}
