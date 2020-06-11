using System;
using System.Collections.Generic;
using System.Linq;

namespace StringParser.Services
{
    public class Parser
    {
        public IEnumerable<string> Parse(IEnumerable<string> stringsToParse)
        {
            if (stringsToParse is null)
            {
                throw new ArgumentNullException(nameof(stringsToParse));
            }

            foreach (var stringToParse in stringsToParse)
            {
                var parsedString = stringToParse;

                var characters = parsedString.ToCharArray();
                var results = new List<char>();

                foreach (var character in characters)
                {
                    if (results.Count == 0 || results.Last() != character)
                        results.Add(character);
                }

                parsedString = string.Join(string.Empty, results);
                parsedString = TruncateString(parsedString);

                yield return parsedString;
            }
        }

        private static string TruncateString(string stringToParse)
        {
            var maxLength = stringToParse.Length < 15
                ? stringToParse.Length
                : 15;

            return stringToParse.Substring(0, maxLength);
        }
    }
}