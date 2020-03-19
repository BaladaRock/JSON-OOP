namespace JSONClasses
{
    public class SuccessMatch : IMatch
    {
        private readonly string text;

        public SuccessMatch(string text)
        {
            this.text = text;
        }

        public string RemainingText()
        {
            return text;
        }

        public bool Success()
        {
            return true;
        }
    }
}