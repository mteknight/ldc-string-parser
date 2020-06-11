using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace StringParser.Services.Tests.Parser
{
    public class ParserTests
    {
        public ParserTests()
        {
            _parser = new Services.Parser();
        }

        private readonly IParser _parser;

        [Theory]
        [MemberData(nameof(ParserTestData.StringsForTruncateTest), MemberType = typeof(ParserTestData))]
        public void TestParse_WhenStringHasMoreThan15Characters_ExpectTruncatedOutput(string stringToParse)
        {
            // Act
            var result = _parser.Parse(new[] { stringToParse });

            // Assert
            Assert.True(result.All(str => str.Length <= 15));
        }

        [Theory]
        [MemberData(nameof(ParserTestData.StringsForDuplicatesTest), MemberType = typeof(ParserTestData))]
        public void TestParse_WhenStringContainsConsecutiveCaseSensitiveDuplicates_ExpectDuplicatesRemoved(
            string stringToParse,
            string expectedResult)
        {
            // Arrange
            var stringsCollection = new[] { stringToParse };
            var expectedParsedStrings = new[] { expectedResult };

            // Act
            var result = _parser.Parse(stringsCollection);

            // Assert
            Assert.True(result.SequenceEqual(expectedParsedStrings));
        }

        [Theory]
        [MemberData(nameof(ParserTestData.StringsForDollarReplacementTest), MemberType = typeof(ParserTestData))]
        public void TestParser_WhenStringContainsDollarSigns_ExpectDollarSignsReplacedByPoundSigns(
            string stringToParse,
            string expectedResult)
        {
            // Arrange
            var stringsCollection = new[] { stringToParse };
            var expectedParsedStrings = new[] { expectedResult };

            // Act
            var result = _parser.Parse(stringsCollection);

            // Assert
            Assert.True(result.SequenceEqual(expectedParsedStrings));
        }

        [Theory]
        [MemberData(nameof(ParserTestData.StringsForUnwantedCharactersTest), MemberType = typeof(ParserTestData))]
        public void TestParser_WhenStringContainsUnwantedCharacters_ExpectCharactersRemoved(
            string stringToParse,
            string expectedResult)
        {
            // Arrange
            var stringsCollection = new[] { stringToParse };
            var expectedParsedStrings = new[] { expectedResult };

            // Act
            var result = _parser.Parse(stringsCollection);

            // Assert
            Assert.True(result.SequenceEqual(expectedParsedStrings));
        }

        [Theory]
        [MemberData(nameof(ParserTestData.StringsForValidOutputTest), MemberType = typeof(ParserTestData))]
        public void TestParse_WhenCalledWithValidData_ExpectNotNullReturn(
            IEnumerable<string> stringsToParse)
        {
            // Act
            var result = _parser.Parse(stringsToParse);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.All(@string => !string.IsNullOrEmpty(@string)));
        }

        [Fact]
        public void TestParse_WhenStringCollectionIsNull_ExpectArgumentNullException()
        {
            // Arrange
            var stringsToParse = default(IEnumerable<string>);

            // Act
            void SutCall() => _parser.Parse(stringsToParse).ToArray();

            // Assert
            Assert.Throws<ArgumentNullException>(SutCall);
        }
    }
}