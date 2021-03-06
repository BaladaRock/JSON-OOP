namespace JSONClasses
{
    public class Sequence : IPattern
    {
        private readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            string original = text;
            foreach (var digit in patterns)
            {
                IMatch match = digit.Match(text);
                if (!match.Success())
                    return new FailedMatch(original);
                text = match.RemainingText();
            }
            return new SuccessMatch(text);
        }
    }
}