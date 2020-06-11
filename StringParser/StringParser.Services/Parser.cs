using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                var parsedString = new StringBuilder(stringToParse);

                parsedString.Replace('$', '£');

                RemoveUnwantedOrDuplicatesCharacters(parsedString);
                parsedString = TruncateString(parsedString);

                yield return parsedString.ToString();
            }
        }

        private static void RemoveUnwantedOrDuplicatesCharacters(StringBuilder parsedString)
        {
            var unwantedCharacters = new[] { '4', '_' };

            for (var i = 1; i < parsedString.Length; i++)
            {
                var character = parsedString[i];
                var previousCharacter = parsedString[i - 1];

                if (unwantedCharacters.Contains(character) || character == previousCharacter)
                {
                    parsedString.Remove(i, 1);
                    i--;
                }
            }
        }

        private static StringBuilder TruncateString(StringBuilder stringToTruncate)
        {
            var maxLength = stringToTruncate.Length < 15
                ? stringToTruncate.Length
                : 15;

            var excessLength = stringToTruncate.Length - maxLength;

            return stringToTruncate.Remove(maxLength, excessLength);
        }
    }
}