﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JSONClasses
{
    public class Sequence : IPattern
    {
        private readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var digit in patterns)
            {
                IMatch match = digit.Match(text);
                if (match.Succes())
                    text = match.RemainingText();
                else
                    return new FailedMatch(text);
            }
            return new SuccessMatch(text);
        }

    }
}
