namespace JSONClasses
{
    public class Text : IPattern
    {
        private readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text) || prefix == null)
                return new FailedMatch(text);

            return text.StartsWith(prefix)
                ? new SuccessMatch(text.Substring(prefix.Length))
                : (IMatch)new FailedMatch(text);
        }
    }
}