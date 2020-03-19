namespace JSONClasses
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var digit = new Range('0', '9');
            var digits = new Many(digit, 1);
            var zeroChar = new Character('0');

            var minus = new Character('-');
            var natural = new Choice(zeroChar, digits);
            var integer = new Sequence(new Optional(minus), natural);

            var point = new Character('.');
            var frac = new Sequence(integer, new Optional(new Sequence(point, digits)));

            var symbol = new Optional(new Any("+-"));
            var e = new Any("eE");
            var exp = new Sequence(e, symbol, digits);

            pattern = new Sequence(frac, new Optional(exp));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}