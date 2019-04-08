using JSONClasses;
using Xunit;


namespace JSONClasses_Tests
{
   public class ChoiceFacts
    {

        [Fact]
        public void Should_return_Empty_String()
        {
            IPattern choice = new Choice(
                new Character('0'),
                new Range('1', '5')
                );
            //Arrange
            IMatch match = choice.Match("");
            //Act
            Assert.Equal("",match.RemainingText());
            Assert.False(match.Success());
            //Assert
        }

        [Fact]
        public void Should_return_Empty_Null()
        {
            IPattern choice = new Choice(
                new Character('0'),
                new Range('1','5')
                );
            //Arranging part
            IMatch match=choice.Match(null);
            //Acting part
            Assert.Null(match.RemainingText());
            Assert.False(match.Success());
            //Asserting part
        }

        [Fact]
        public void Should_eliminate_first_digit__Number_is_in__Range()
        {
            var choice = new Choice(
                new Character('0'),
                new Range('1', '9')
                );
            //Arrange
            var match = choice.Match("123");
            //Act
            Assert.Equal("23", match.RemainingText());
            Assert.True(match.Success());
            //Assert
        }

        [Fact]
        public void Should_return_same_string_when_it_Does_NOT_Match()
        {
            var choice = new Choice(
                new Character('b'),
                new Range('1', '9')
                );
            //Arrange
            var match = choice.Match("abC");
            //Act
            Assert.Equal("abC", match.RemainingText());
            Assert.False(match.Success());
            //Assert
        }

        [Fact]
        public void Check_String_when_it_contains_Hexadecimal_Characters()
        {
            IPattern digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );
            IPattern hex = new Choice(
                digit,
                new Range('a', 'f'),
                new Range('A', 'F')
                );
            //Arrange
            var match = hex.Match("A7");
            //Act
            Assert.Equal("7", match.RemainingText());
            Assert.True(match.Success());
            //Assert
        }

    }
}
