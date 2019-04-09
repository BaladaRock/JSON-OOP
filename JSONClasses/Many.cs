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
            string maxIsHit = "";
            var match = pattern.Match(text);
            while (match.Success())
            {
                maxIsHit = match.RemainingText();
                if (maxRequerence != 0 && patternCounter == maxRequerence-1)
                    return new SuccessMatch(maxIsHit);
                
                
                match = pattern.Match(match.RemainingText());
                patternCounter++;
            }

            if (minRequerence != 0 && patternCounter < minRequerence)
                return new SuccessMatch(text);

            return new SuccessMatch(match.RemainingText());

        }
    }
}
