using JSONClasses;
using Xunit;

namespace JSONClasses_Tests
{
    public class ListFacts
    {
        [Fact]
        public void Should_Return_Correct_String_Simple_Element_And_Separator()
        {
            //Given
            var list = new List(new Character('a'), new Character(','));

            //When
            var element = list.Match(",a,a,");

            //Then
            Assert.Equal(",a,a,", element.RemainingText());
            Assert.True(element.Success());
        }

        [Fact]
        public void Should_Return_True_EmptyString_Case()
        {
            //Given
            var list = new List(new Character('a'), new Character(','));

            //When
            var element = list.Match("");

            //Then
            Assert.Equal("", element.RemainingText());
            Assert.True(element.Success());
        }

        [Fact]
        public void Should_Return_True_Null_Case()
        {
            //Given
            var list = new List(new Character('a'), new Character(','));

            //When
            var element = list.Match(null);

            //Then
            Assert.Null(element.RemainingText());
            Assert.True(element.Success());
        }

        [Fact]
        public void Should_Return_Original_String_When_List_Pattern_Does_Not_Occur()
        {
            //Given
            var list = new List(new Character('a'), new Character(','));

            //When
            var element = list.Match("Ubisoft");

            //Then
            Assert.Equal("Ubisoft", element.RemainingText());
            Assert.True(element.Success());
        }

        [Fact]
        public void Should_Return_Remaining_String_When_Last_Element_Is_Separator()
        {
            //Given
            var list = new List(new Range('0', '9'), new Character(','));

            //When
            var element = list.Match("1,2,3,");

            //Then
            Assert.Equal(",", element.RemainingText());
            Assert.True(element.Success());
        }

        [Fact]
        public void Should_Return_Remaining_String_One_Element_Case()
        {
            //Given
            var list = new List(new Range('0', '9'), new Character(','));

            //When
            var element = list.Match("1");

            //Then
            Assert.Equal("", element.RemainingText());
            Assert.True(element.Success());
        }

        [Fact]
        public void Should_Return_Correctly_More_Complicated_Case()
        {
            //Given
            var digits = new Many(new Range('0', '9'), 1);
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            //When
            var element = list.Match("1; 22;\n 333 \t; 22");

            //Then
            Assert.Equal("", element.RemainingText());
            Assert.True(element.Success());
        }
    }
}