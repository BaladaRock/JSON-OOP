using JSONClasses;
using Xunit;

namespace JSONClasses_Tests
{
    public class ManyFacts
    {
        [Fact]
        public void Should_Return_True_Simple_Case()
        {
            var pattern = new Many(
            new Text("abc"));

            var match = pattern.Match("abc");

            Assert.Equal("", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_True_Repeated_Pattern()
        {
            var pattern = new Many(
            new Character('a'));

            var match = pattern.Match("aaaaaabc");

            Assert.Equal("bc", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return__Empty_String_When_Pattern_Is_Equal_To_String()
        {
            var pattern = new Many(
            new Range('a','d'));

            var match = pattern.Match("aaaaaabc");

            Assert.Equal("", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return__Original_String()
        {
            var pattern = new Many(
            new Range('a', 'd'));

            var match = pattern.Match("RMN");

            Assert.Equal("RMN", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return__Empty_String()
        {
            var pattern = new Many(
            new Range('a', 'd'));

            var match = pattern.Match("");

            Assert.Equal("", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return__Null()
        {
            var pattern = new Many(
            new Range('a', 'd'));

            var match = pattern.Match(null);

            Assert.Null(match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return__Correct_String_More_Complicated_Case()
        {
            var pattern = new Many(
            new Range('a', 'd'));

            var match = pattern.Match("abcd1234abc");

            Assert.Equal("1234abc", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return__Correct_String_Hexadecimal_Sequence()
        {
            var hex = new Choice(
            new Range('0', '9'),
            new Range('a', 'f'),
            new Range('A', 'F')
            );

            var hexSeq = new Sequance(
                new Character('u'),
                new Sequance(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            var pattern = new Many(
            new Sequance(hexSeq)
            );

            var match = pattern.Match("u1234u1234u12Zabc");

            Assert.Equal("u12Zabc", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return__Correct_String_Text_Test()
        {
            var pattern = new Many(
            new Text("I7Processor"));

            var match = pattern.Match("I7ProcessorI7ProcessorI5Processor");

            Assert.Equal("I5Processor", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_False_When_Min_value_Is_NOT_Reached()
        {
            var pattern = new Many(
            new Character('a'),3);

            var match = pattern.Match("aabc");

            Assert.Equal("aabc", match.RemainingText());
            Assert.False(match.Success());
        }

        [Fact]
        public void Should_Return_True_When_Min_And_Max_value_Are_given()
        {
            var pattern = new Many(
            new Character('a'),1,2);

            var match = pattern.Match("aaaabc");

            Assert.Equal("aabc", match.RemainingText());
            Assert.True(match.Success());
        }

        [Fact]
        public void Should_Return_Original_String_When_Min_And_Max_value_Are_given()
        {
            var pattern = new Many(
            new Range('a','d'), 3,4);

            var match = pattern.Match("aazzzz");

            Assert.Equal("aazzzz", match.RemainingText());
            Assert.False(match.Success());
        }

        [Fact]
        public void Should_Return_False_Minimum_Is_Greater_Then_Maximum()
        {
            var pattern = new Many(
            new Range('a', 'd'), 4, 3);

            var match = pattern.Match("aaaaazzzz");

            Assert.Equal("aaaaazzzz", match.RemainingText());
            Assert.False(match.Success());
        }

        [Fact]
        public void Should_Return_False_Minimum_Is_Equal_With_Maximum()
        {
            var pattern = new Many(
            new Range('a', 'd'), 4, 4);

            var match = pattern.Match("aaaaazzzz");

            Assert.Equal("azzzz", match.RemainingText());
            Assert.True(match.Success());
        }

    }
}
