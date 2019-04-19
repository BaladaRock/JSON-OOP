using System;

namespace JSONClasses
{
    public class Choice : IPattern
    {
        private  IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns= patterns;
        }

        public IMatch Match(string text)
        {

            foreach(var digit in patterns)
            {
                IMatch match = digit.Match(text);
                if (match.Success())
                    return match;
            }
            return new FailedMatch(text);
        }
        
        public void Add(IPattern pattern)
        {
            Array.Resize(ref patterns, patterns.Length + 1);
            patterns[patterns.Length-1] = pattern;
        }

    }
}
