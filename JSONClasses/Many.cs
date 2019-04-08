using System;
using System.Collections.Generic;
using System.Text;

namespace JSONClasses
{
    public class Many : IPattern
    {
        private IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            if (text == null)
                return new SuccessMatch(null);

            foreach (var character in text)
            {
                IMatch match = pattern.Match(text);
                if (!match.Success())
                    return new SuccessMatch(text);
                text = match.RemainingText();
            }
            return new SuccessMatch(text);

        }
    }
}
