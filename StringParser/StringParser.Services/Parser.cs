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

            return default(IEnumerable<string>);
        }
    }
}