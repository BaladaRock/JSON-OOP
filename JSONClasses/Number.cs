using System;
using System.Collections.Generic;
using System.Text;

namespace JSONClasses
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var oneNine = new Range('1', '9');
            var digit = new Choice(new Character('0'), oneNine);
            var digits = new Choice(digit, new Sequence(digit));
            var emptyText = new Text("");
            var minus = new Character('-');
            var plus = new Character('+');
            var point = new Character('.');
            var negative = new Sequence(minus, digit);
            var oneNineDigits = new Sequence(oneNine, digits);
            var negativeOneNineDigits = new Sequence(minus, oneNine, digits);
            //integer and other internal components

            var sign = new Choice(emptyText, plus, minus);
            var smallExponent = new Sequence(new Character('e'), sign, digits);
            var bigExponent = new Sequence(new Character('E'), sign, digits);
            var seqForE = new Sequence(bigExponent, sign, digits);
            var eSequence = new Sequence(smallExponent, sign, digits);
            //exp components

            var integer = new Choice(digit, oneNineDigits, negative, negativeOneNineDigits);
            var frac = new Choice(emptyText, new Sequence(point, digits));//frac part
            var exp = new Choice(emptyText, seqForE,eSequence);
            //number components

            pattern =new Sequence(integer,frac,exp);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
