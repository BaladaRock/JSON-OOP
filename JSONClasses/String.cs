using System;

namespace JSONClasses
{
    public class String : IPattern
    {
       private readonly IPattern pattern;

        public String()
        {

            var quotationMarks = new Character('\"');

            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Many(hex, 4, 4)
            );

            var escape = new Choice(
                new Character('\"'),
                new Character('\\'),
                new Character('/'),
                new Character('b'),
                new Character('n'),
                new Character('r'),
                new Character('t'),
                hexSeq
            );


            var acceptedCharacters = new Many(
                new Choice(
                new Range('\u0020', '\u0021'),
                new Range('\u0023', '\u005b'),
                new Range('\u005d', (char)ushort.MaxValue),
                new Sequence(new Character('\\'), escape)
                )
            );

            pattern = new Sequence(quotationMarks, acceptedCharacters, quotationMarks);
        }
       

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
