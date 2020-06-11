using System;
using System.Collections.Generic;

namespace StringParser.Services.Tests.Parser
{
    public class ParserTestData
    {
        public static IEnumerable<object[]> StringsToParseWithVanillaOutput =>
            new[]
            {
                new object[] { Array.Empty<string>(), Array.Empty<string>() },
            };

        public static IEnumerable<object[]> StringsForTruncateTest =>
            new[]
            {
                new object[] {""},
                new object[] {" "},
                new object[] {"abcd"},
                new object[] {"abcdefghijklmnopqrstuvwxyz"},
                new object[] {"sd89af79df8asdf787276sdaf536f56dsa54dfs76sdf4a5sdf323f56sad"}
            };

        public static IEnumerable<object[]> StringsForDuplicatesTest =>
            new[]
            {
                new object[] {"abcdd", "abcd"},
                new object[] { "abcdddd", "abcd" },
                new object[] { "abcddDd", "abcdDd" },
                new object[] { "abcddDDdD", "abcdDdD" },
            };
    }
}