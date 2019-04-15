using JSONClasses;
using Xunit;

namespace JSONClasses_Tests
{
     public class OptionalFacts
     {
        [Fact]
        public void Should_Return_Remaining_String_Word_Has_Pattern()
        {
            var pattern = new Optional(
             new Character('a'));
            var match = pattern.Match("abc");

            Assert.Equal("bc", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_Original_String_Word_Does_Not_Contain_Pattern()
        {
            var pattern = new Optional(
             new Character('z'));
            var match = pattern.Match("abc");

            Assert.Equal("abc", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_correct_string_when_Pattern_is_Repeated()
        {
            var pattern = new Optional(
             new Character('a'));
            var match = pattern.Match("aaaabc");

            Assert.Equal("aaabc", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_correctly_For_Empty_String()
        {
            var pattern = new Optional(
             new Character('a'));
            var match = pattern.Match("");

            Assert.Equal("", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_correctly_For_Null_()
        {
            var pattern = new Optional(
             new Character('a'));
            var match = pattern.Match(null);

            Assert.Null( match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_correctly_More_Complex_Case()
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

            var pattern = new Optional(hexSeq);
            var match = pattern.Match("uAE12U345");

            Assert.Equal("U345",match.RemainingText());
            Assert.True(match.Success());
        }

    }
}
