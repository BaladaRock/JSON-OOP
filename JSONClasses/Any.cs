using System;
using System.Collections.Generic;
using System.Text;

namespace JSONClasses
{
    public class Any:IPattern
    {
        private readonly string accepted;

        public Any(string accepted)
        {
            this.accepted=accepted;
        }

        public IMatch Match(string text)
        {
            foreach(var character in accepted)
            {
                if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(accepted))
                    return new FailedMatch(text);

                if (text[0] == character)
                    return new SuccessMatch(text.Substring(1));
            }
            return new FailedMatch(text);
            
        }

    }
}
