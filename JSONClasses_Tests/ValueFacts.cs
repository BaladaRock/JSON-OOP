using JSONClasses;
using Xunit;

namespace JSONClasses_Tests
{
    public class ValueFacts
    {
        [Fact]
        public void Test_Array_Should_Correctly_Match_Empty_Array()
        {
            var array = new Value();
            var match = array.Match("");

            Assert.Empty(match.RemainingText());
            Assert.False(match.Success());
        }

        [Fact]
        public void Test_Array_Should_Correctly_Match_More_Complex_Array()
        {
            var array = new Value();
            var match = array.Match("[\"are\"]");

            Assert.Empty(match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Test_Array_Should_Return_Correctly_When_Array_Deos_Not_Match_Format()
        {
            var array = new Value();
            var match = array.Match("[\"Maiden\".\"Maiden\".\"Maiden\"]");

            Assert.Equal("[\"Maiden\".\"Maiden\".\"Maiden\"]", match.RemainingText());
            Assert.False(match.Success());
        }

        [Fact]
        public void Test_Array_Should_Return_Correctly_When_Array__Matches_Format()
        {
            var array = new Value();

            var match = array.Match("[\"abc\",\"abc\",\"abc\"]");
            Assert.Empty(match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Test_Array_Should_Return_Correctly__WhiteSpaces_Inside_Brackets()
        {
            var array = new Value();

            var match = array.Match("[ \"abc\",\"abc\",\"abc\"]");
            Assert.Empty(match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Test_Array_Should_Return_Correctly__WhiteSpaces_After_Separator()
        {
            var array = new Value();

            var match = array.Match("[\"abc\", \"abc\", \"abc\"]");
            Assert.Empty(match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Test_Array_Should_Return_Correctly__More_WhiteSpaces()
        {
            var array = new Value();

            var match = array.Match("[ \"abc\", \"abc\" , \"abc\" ]");
            Assert.Empty(match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Test_Object_Should_Return_Correctly__Only_Brackets()
        {
            var obj = new Value();

            var match = obj.Match("{}");
            Assert.Empty(match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Test_Object_Should_Return_Correctly__Simple_Example()
        {
            var obj = new Value();

            var match = obj.Match("{\"abc\":\"abc\"}");
            Assert.Empty(match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Test_Object_Should_Return_Correctly__White_Spaces()
        {
            var obj = new Value();

            var match = obj.Match("{ \"abc\" :\"abc  \"}");
            Assert.Empty(match.RemainingText());
            Assert.True(match.Success());
        }
    }
}