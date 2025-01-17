﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringParser.Services
{
    public class Parser : IParser
    {
        public IEnumerable<string> Parse(IEnumerable<string> stringsToParse)
        {
            if (stringsToParse is null)
            {
                throw new ArgumentNullException(nameof(stringsToParse));
            }

            foreach (var stringToParse in stringsToParse)
            {
                if (string.IsNullOrEmpty(stringToParse))
                {
                    continue;
                }

                var parsedString = Parse(stringToParse);

                yield return parsedString.ToString();
            }
        }

        private static StringBuilder Parse(string stringToParse)
        {
            var parsedString = new StringBuilder(stringToParse);

            ReplaceDollarSigns(parsedString);
            RemoveUnwantedOrDuplicatesCharacters(parsedString);
            TruncateString(parsedString);

            return parsedString;
        }

        private static void ReplaceDollarSigns(StringBuilder parsedString)
        {
            const char dollar = '$';
            const char pound = '£';

            parsedString.Replace(dollar, pound);
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

        private static void TruncateString(StringBuilder stringToTruncate)
        {
            const int maxLength = 15;
            var length = stringToTruncate.Length < maxLength
                ? stringToTruncate.Length
                : maxLength;

            var excessLength = stringToTruncate.Length - length;

            stringToTruncate.Remove(length, excessLength);
        }
    }
}