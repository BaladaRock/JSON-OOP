

namespace JSONClasses
{
    public class SuccessMatch : IMatch
    {
        private string text;
        public SuccessMatch(string text)
        {
            this.text = text;  
        }

        public string RemainingText()
        {
            return text;
        }

        public bool Succes()
        {
            return true;
        }
    }
}
