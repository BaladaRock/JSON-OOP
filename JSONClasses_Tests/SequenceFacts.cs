using JSONClasses;
using Xunit;

namespace JSONClasses_Tests
{
    public class SequenceFacts
    {
        [Fact]
        public void Should_Return_Modified_Text_Simple_Case()
        {
            var word = new Sequence(
            new Character('a'),
            new Character('b')
            );

            var match = word.Match("abcd");
            Assert.Equal("cd", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_Modified_Text_False_Case()
        {
            var word = new Sequence(
            new Character('a'),
            new Character('b')
            );

            var match = word.Match("ac");
            Assert.Equal("ac", match.RemainingText());
            Assert.False(match.Success());
        }

        [Fact]
        public void Should_Return_Original_Text()
        {
            var word = new Sequence(
            new Character('a'),
            new Range('b', 'c')
            );

            var match = word.Match("12Rf2");
            Assert.Equal("12Rf2", match.RemainingText());
            Assert.False(match.Success());
        }

        [Fact]
        public void Should_Return_Empty_String()
        {
            var word = new Sequence(
            new Character('a'),
            new Character('b')
            );

            var match = word.Match("ab");
            Assert.Equal("", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_Modified_Text_More_Complex_Case()
        {
            var word = new Sequence(
            new Character('a'),
            new Character('b')
            );
            var sequance = new Sequence(
            word,
            new Range('3', '5')
            );
            var match = sequance.Match("ab4Andrei");
            Assert.Equal("Andrei", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_Modified_Text_Hexadecimal_Case()
        {
            //Given
            var hex = new Choice(
            new Range('0', '9'),
            new Range('a', 'f'),
            new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            //When
            var match = hexSeq.Match("u1234end");
            //Then
            Assert.Equal("end", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_Modified_Text_Hexadecimal_Case_II_()
        {
            var hex = new Choice(
            new Range('0', '9'),
            new Range('a', 'f'),
            new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            //Arrange
            var match = hexSeq.Match("uB005 ab");
            //Act
            Assert.Equal(" ab", match.RemainingText());
            Assert.True(match.Success());
            //Assert
        }
    }
}