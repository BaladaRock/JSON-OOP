<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JSONClasses
{
    public class Sequance : IPattern
    {
        private readonly IPattern[] patterns;

        public Sequance(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            string original = text;
            foreach (var digit in patterns)
            {
                IMatch match = digit.Match(text);
                if (!match.Success())
                    return new FailedMatch(original);
                text = match.RemainingText();
            }
            return new SuccessMatch(text);
        }

    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JSONClasses
{
    public class Sequance : IPattern
    {
        private readonly IPattern[] patterns;

        public Sequance(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            string result = text;
            foreach (var digit in patterns)
            {
                IMatch match = digit.Match(text);
                if (match.Succes())
                    text = match.RemainingText();
                else
                    return new FailedMatch(result);
            }
            return new SuccessMatch(text);
        }

    }
}
>>>>>>> 764f4bc9b0c35cf25bf7c1b373157c347afda57b
