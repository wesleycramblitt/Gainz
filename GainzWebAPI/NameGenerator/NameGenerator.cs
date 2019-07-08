using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.NameGenerator
{
    public static class NameGenerator
    {
        public static string getName()
        {
            var adjectives = File.ReadAllLines("NameGenerator/2syllableadjectives.txt");
            var nouns = File.ReadAllLines("NameGenerator/2syllablenouns.txt");

            Random r = new Random();

            var adjective = adjectives[r.Next(0, adjectives.Count())];

            var noun = nouns[r.Next(0, nouns.Count())];

            //uppercase first letter
            adjective = char.ToUpper(adjective[0]) + adjective.Substring(1);
            noun = char.ToUpper(noun[0]) + noun.Substring(1);

            return adjective + " " + noun;
        }

    }
}
