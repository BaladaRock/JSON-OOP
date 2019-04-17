using JSONClasses;
using Xunit;

namespace JSONClasses_Tests
{
     public class NumberFacts
     {
       [Fact]
        public void Should_Return_Empty_String_One_Digit()
        {
            var number = new Number();
            var match = number.Match("1");

            Assert.Empty(match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_Empty_String_Natural_Number()
        {
            var number = new Number();
            var match=number.Match("123");

            Assert.Empty(match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_Empty_String_Int_Number()
        {
            var number = new Number();
            var match = number.Match("-123");

            Assert.Empty(match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Eliminate_0_When_Number_Starts_With_0()
        {
            var number = new Number();
            var match = number.Match("012");

            Assert.Equal("12",match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_ReturnCorrectly_When_Number_Starts_With_Sign_And_0()
        {
            var number = new Number();
            var match = number.Match("-012");

            Assert.Equal("12", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_Correctly_For_Decimal_Number()
        {
            var number = new Number();
            var match = number.Match("3.4567");

            Assert.Empty(match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_Correctly_For_Smaller_Then_1_Decimal_Number()
        {
            var number = new Number();
            var match = number.Match("0.4567");

            Assert.Empty(match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_Correctly_For_Smaller_Then_1_Negative_Decimal_Number()
        {
            var number = new Number();
            var match = number.Match("-0.4567");

            Assert.Empty(match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_Correctly_For_Decimal_Number_With_Exponent()
        {
            var number = new Number();
            var match = number.Match("3.45E7");

            Assert.Empty(match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_Correctly_For_Decimal_Number_With_Exponent_And_Symbols()
        {
            var number = new Number();
            var match = number.Match("3.45e+7");

            Assert.Empty(match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_Correctly_For_Decimal_Number_With_Exponent_More_Complex_Case()
        {
            var number = new Number();
            var match = number.Match("3.45e3E2.3");

            Assert.Equal("E2.3",match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_Correctly_For_Decimal_Number_With_Exponent_Double_()
        {
            var number = new Number();
            var match = number.Match("3.45e3.243");

            Assert.Equal(".243", match.RemainingText());
            Assert.True(match.Success());
        }

     }
}
