using System;
using System.Collections.Generic;
using System.Text;

namespace JSONClasses
{
    public class FailedMatch : IMatch
    {
        private readonly string text;

        public FailedMatch(string text)
        {
            this.text = text;
        }

        public string RemainingText()
        {
           return text;
        }

        public bool Succes()
        {
            return false;
        }
    }
}
