using JSONClasses;
using System;
using Xunit;

namespace JSONClasses_Tests
{
    public class RangeFacts
    {
        [Fact]
        public void CheckWord_One_Character()
        {
            var word = new Range('a', 'f');
            Assert.True(word.Match("a"));
        }

        [Fact]
        public void CheckWord_EmptyString()
        {
            var word = new Range('a', 'f');
            Assert.False(word.Match(""));
        }
    }
}
