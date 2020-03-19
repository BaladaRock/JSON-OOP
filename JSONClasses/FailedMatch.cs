namespace JSONClasses
{
    public class FailedMatch : IMatch
    {
        private readonly string text;

        public FailedMatch(string text)
        {
            this.text = text;
        }

        public string RemainingText()
        {
            return text;
        }

        public bool Success()
        {
            return false;
        }
    }
}