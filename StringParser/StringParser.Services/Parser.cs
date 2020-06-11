using System;
using System.Collections.Generic;

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
                var maxLength = stringToParse.Length < 15 ? stringToParse.Length : 15;
                var parsedString = stringToParse.Substring(0, maxLength);

                yield return parsedString;
            }
        }
    }
}