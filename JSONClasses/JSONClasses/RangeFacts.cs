using JSONClasses;
using Xunit;

namespace JSONClasses_Tests
{
    public class RangeFacts
    {
        [Fact]
        public void CheckWord_One_Character()
        {
            var match = new SuccessMatch("abc");
            Assert.True(match.Succes());
            Assert.Equal("abc", match.RemainingText());
        }

        [Fact]
        public void CheckWord_EmptyString()
        {
            IMatch match = new SuccessMatch("");
            Assert.True(match.Succes());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CheckWord_Numbers()
        {
            IMatch match = new SuccessMatch("5");
            Assert.True(match.Succes());
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
            
            Assert.True(hex.Succes());

        }


       
    }
}
