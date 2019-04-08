using System;
using System.Collections.Generic;
using System.Text;

namespace JSONClasses
{
     public class OneOrMore : IPattern
     {

        public OneOrMore(IPattern pattern)
        {
        
        }

        public IMatch Match(string text)
        {
            return null;
        }
    }
}
