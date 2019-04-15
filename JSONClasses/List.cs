namespace JSONClasses
{
    public class List : IPattern
    {
        private readonly IPattern element;
        private readonly Many list;

        public List(IPattern element, IPattern separator)
        {
            this.element = element;
            list = new Many(new Sequence(separator, element));
        }


        public IMatch Match(string text)
        {
            IMatch match = element.Match(text);
            return match.Success()
                ? list.Match(match.RemainingText())
                : new SuccessMatch(match.RemainingText());
        }
    }
}
