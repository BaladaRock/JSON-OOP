namespace JSONClasses
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var value = new Choice(
                new String(),
                new Number(),
                new Text("true"),
                new Text("false"),
                new Text("null")
            );

            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(','), whitespace);
            var element = new Sequence(whitespace, value, whitespace);

            var array = new Sequence(whitespace,
                new Character('['),
                new List(element, separator),
                new Character(']')
            );

            var objectSeparator = new Sequence(whitespace, new Character(':'), whitespace);
            var objectString = new Sequence(whitespace, new String(), whitespace);
            var members = new Sequence(objectString, objectSeparator, element);

            var jsonObject = new Sequence(whitespace,
               new Character('{'),
               new List(members, separator),
               new Character('}')
           );

            value.Add(array);
            value.Add(jsonObject);

            pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}