using System;
using System.Collections.Generic;
using System.Text;

namespace JSONClasses
{
    public class Many : IPattern
    {
        private readonly IPattern pattern;
        private readonly int minRequerence;
        private readonly int maxRequerence;
        
        public Many(IPattern pattern, int minRequerence = 0, int maxRequerence = int.MaxValue)
        {
            this.pattern = pattern;
            this.minRequerence = minRequerence;
            this.maxRequerence = maxRequerence;
        }

        public IMatch Match(string text)
        {
            int patternCounter = 0;
            var match = pattern.Match(text);
            while (match.Success() && minRequerence <= maxRequerence)
            {
                patternCounter++;
                match = pattern.Match(match.RemainingText());
                if (patternCounter == maxRequerence-1)
                    return new SuccessMatch(match.RemainingText());
            }

            return patternCounter>=minRequerence && minRequerence<=maxRequerence
                ? new SuccessMatch(match.RemainingText())
                : (IMatch) new FailedMatch(text);
            

        }
    }
}
