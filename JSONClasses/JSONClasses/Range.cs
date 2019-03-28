using System;
using System.Collections.Generic;
using System.Text;

namespace JSONClasses
{
    public class Range
    {
        readonly private char start;
        readonly private char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public bool Match(string text)
        {
            if (text.Length==0)
                return false;
            char firstCharacter = text[0];
            return firstCharacter <= end && firstCharacter >= start;
        }
    }
}
