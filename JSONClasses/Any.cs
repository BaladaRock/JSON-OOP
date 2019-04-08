using System;
using System.Collections.Generic;
using System.Text;

namespace JSONClasses
{
    public class Any : IPattern
    {
        private readonly string accepted;

        public Any(string accepted)
        {
            this.accepted=accepted;
        }

        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text)
                && accepted?.Contains(text[0]) == true
                ? (IMatch)new SuccessMatch(text.Substring(1))
                : new FailedMatch(text);
        }

    }
}
