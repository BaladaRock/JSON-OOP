namespace JSONClasses
{
    public class Many : IPattern
    {
        private readonly IPattern pattern;
        private readonly int minRecurrence;
        private readonly int maxRecurrence;
        
        public Many(IPattern pattern, int minRecurrence = 0, int maxRecurrence = int.MaxValue)
        {
            this.pattern = pattern;
            this.minRecurrence = minRecurrence;
            this.maxRecurrence = maxRecurrence;
        }

        public IMatch Match(string text)
        {
            if (minRecurrence > maxRecurrence)
                return new FailedMatch(text);

            var match = pattern.Match(text);
            int patternCounter = 0;

            while (match.Success())
            {
                patternCounter++;
                if (patternCounter == maxRecurrence)
                    return new SuccessMatch(match.RemainingText());
                match = pattern.Match(match.RemainingText());
            }

            return patternCounter >= minRecurrence
                ? new SuccessMatch(match.RemainingText())
                : (IMatch)new FailedMatch(text);

        }
    }
}
