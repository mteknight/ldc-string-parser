using System;
using System.Collections.Generic;

namespace StringParser.Services.Tests.Parser
{
    public class ParserTestData
    {
        public static IEnumerable<object[]> StringsToParse =>
            new[]
            {
                new object[] { Array.Empty<string>(), Array.Empty<string>() },
            };
    }
}