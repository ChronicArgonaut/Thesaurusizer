
using System.Collections.Generic;

namespace WordHolders
{
    public class Noun
    {
        public List<string> syn { get; set; }
    }

    public class Verb
    {
        public List<string> syn { get; set; }
    }

    public class Adjective
    {
        public List<string> syn { get; set; }
    }

    public class Adverb
    {
        public List<string> syn { get; set; }
    }

    public class Conjunction
    {
        public List<string> syn { get; set; }
    }

    public class Pronoun
    {
        public List<string> syn { get; set; }
    }

    public class Preposition
    {
        public List<string> syn { get; set; }
    }
    public class Interjection
    {
        public List<string> syn { get; set; }
    }

    public class RootObject
    {
        public Noun noun { get; set; }
        public Verb verb { get; set; }
        public Adjective adjective { get; set; }
        public Adverb adverb { get; set; }
        public Conjunction conjunction { get; set; }
        public Pronoun pronoun { get; set; }
        public Preposition preposition { get; set; }
        public Interjection interjection { get; set; }
    }
}
