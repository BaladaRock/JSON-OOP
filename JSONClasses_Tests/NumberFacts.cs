using JSONClasses;
using Xunit;

namespace JSONClasses_Tests
{
     public class NumberFacts
     {
        [Fact]
        public void Should_Return_Empty_String_Natural_Number()
        {
            var number = new Number();
            var match=number.Match("123");

            Assert.Empty(match.RemainingText());
            Assert.True(match.Success());
        }

     }
}
