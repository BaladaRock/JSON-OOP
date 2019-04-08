using System;
using System.Collections.Generic;
using System.Text;

namespace JSONClasses
{
     public class List : IPattern
     {

        public List(IPattern element, IPattern separator)
        {
        
        }

        public IMatch Match(string text)
        {
            return null;
        }
    }
}
