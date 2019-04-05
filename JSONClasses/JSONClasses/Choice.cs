﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JSONClasses
{
    public class Choice : IPattern
    {
        private readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns= patterns;
        }

        public IMatch Match(string text)
        {

            foreach(var digit in patterns)
            {
                IMatch match = digit.Match(text);
                if (match.Succes())
                    return match;
            }
            return new FailedMatch(text);
        }

    }
}
