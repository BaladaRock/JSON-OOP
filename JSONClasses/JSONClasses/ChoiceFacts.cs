using JSONClasses;
using Xunit;


namespace JSONClasses_Tests
{
   public class ChoiceFacts
    {

        [Fact]
        public void Check_Empty_String()
        {
            
            var match = new SuccessMatch("0");
            Assert.True(match.Succes());
            Assert.Equal("0",match.RemainingText());
        }

        [Fact]
        public void Check_Word_Number()
        {

            var match = new SuccessMatch("012");
            Assert.Equal("012", match.RemainingText());
            Assert.True(match.Succes());

        }
    }
}
