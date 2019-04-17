using JSONClasses;
using Xunit;

namespace JSONClasses_Tests
{
     public class StringFacts
     {
        [Fact]
        public void Should_Return_False_Quotation_Marks_Only()
        {
            var word = new String();
            var match = word.Match("\"");
            Assert.Equal("\"",match.RemainingText());
            Assert.False(match.Success());

        }

        [Fact]
        public void Should_Return_Correctly_No_Quotation_Marks()
        {
            var word = new String();
            var match = word.Match("Andrei");
            Assert.Equal("Andrei", match.RemainingText());
            Assert.False(match.Success());

        }

        [Fact]
        public void Should_Return_Empty_String_Quotation_Marks_Only_At_Start()
        {
            var word = new String();
            var match = word.Match("\"are");
            Assert.Equal("\"are", match.RemainingText());
            Assert.False(match.Success());

        }

        [Fact]
        public void Should_Return_Correctly_Word_Has_Control_Character()
        {
            var word = new String();
            var match = word.Match("\"An\0drei\"");
            Assert.Equal("\"An\0drei\"", match.RemainingText());
            Assert.False(match.Success());

        }

        [Fact]
        public void Should_Return_Correctly_Word_Has_Escape_Characters()
        {
            var word = new String();
            var match = word.Match("\"An\\drei\"");
            Assert.Equal("\"An\\drei\"", match.RemainingText());
            Assert.False(match.Success());

        }

        [Fact]
        public void Should_Return_Correctly_Word_Has_Hexadecimal_Characters()
        {
            var word = new String();
            var match = word.Match("\"An\\u005ddrei\"");
            Assert.Equal("", match.RemainingText());
            Assert.True(match.Success());

        }

     }
}
