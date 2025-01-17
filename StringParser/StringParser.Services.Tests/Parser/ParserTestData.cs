﻿using System;
using System.Collections.Generic;

namespace StringParser.Services.Tests.Parser
{
    public class ParserTestData
    {
        public static IEnumerable<object[]> StringsForValidOutputTest =>
            new[]
            {
                new object[] { Array.Empty<string>() },
                new object[] { new[] { default(string) } },
                new object[] { new[] { string.Empty } },
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

        public static IEnumerable<object[]> StringsForDollarReplacementTest =>
            new[]
            {
                new object[] {"abc$de", "abc£de"},
                new object[] {"abc$de$safds$", "abc£de£safds£"},
                new object[] {"abc$de$$safds$$", "abc£de£safds£"},
                new object[] {"abc$de$£safds£$", "abc£de£safds£"},
            };

        public static IEnumerable<object[]> StringsForUnwantedCharactersTest =>
            new[]
            {
                new object[] {"abc4dac", "abcdac"},
                new object[] {"abcd_ac", "abcdac"},
                new object[] {"abc4_dac", "abcdac"},
                new object[] {"abc44d_ac", "abcdac"},
                new object[] {"abc4da__c", "abcdac"},
            };
    }
}