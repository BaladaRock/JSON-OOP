using System;
using System.Collections.Generic;
using System.Text;

namespace JSONClasses
{
    public class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            // aici construiește patternul pentru
            // un JSON string
            //pattern = ...;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
