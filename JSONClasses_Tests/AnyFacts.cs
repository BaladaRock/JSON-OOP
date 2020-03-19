using JSONClasses;
using Xunit;

namespace JSONClasses_Tests
{
    public class AnyFacts
    {
        [Fact]
        public void Should_Return_True_One_Character_Word()
        {
            var word = new Any("A");
            IMatch match = word.Match("A");

            Assert.Equal("", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_True_One_Longer_Word()
        {
            var word = new Any("frgA");
            IMatch match = word.Match("Afd");

            Assert.Equal("fd", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_False_Null_String()
        {
            IPattern choice = new Any("frgA");
            IMatch match = choice.Match(null);

            Assert.Null(match.RemainingText());
            Assert.False(match.Success());
        }

        [Fact]
        public void Should_Return_False_Accepted_String_Is_Null()
        {
            IPattern choice = new Any(null);
            IMatch match = choice.Match("432");

            Assert.Equal("432", match.RemainingText());
            Assert.False(match.Success());
        }

        [Fact]
        public void Should_Return_False_Empty_String()
        {
            var word = new Any("frgA");
            IMatch match = word.Match("");

            Assert.Equal("", match.RemainingText());
            Assert.False(match.Success());
        }

        [Fact]
        public void Should_Return_False_Word_Doen_Not_Contain_Consttuctor_Characters()
        {
            var word = new Any("frgA");
            IMatch match = word.Match("s");

            Assert.False(match.Success());
            Assert.Equal("s", match.RemainingText());
        }
    }
}