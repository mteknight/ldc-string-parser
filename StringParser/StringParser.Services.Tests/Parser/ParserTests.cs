using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace StringParser.Services.Tests.Parser
{
    public class ParserTests
    {
        [Theory]
        [MemberData(nameof(ParserTestData.StringsToParseWithVanillaOutput), MemberType = typeof(ParserTestData))]
        public void TestParse_WhenValidDataProvided_ExpectParsedCollection(
            IEnumerable<string> stringsToParse,
            IEnumerable<string> expectedParsedStrings)
        {
            // Arrange
            var parser = new Services.Parser();

            // Act
            var result = parser.Parse(stringsToParse);

            // Assert
            Assert.NotNull(result);
            Assert.True(expectedParsedStrings.SequenceEqual(result));
        }

        [Theory]
        [MemberData(nameof(ParserTestData.StringsForTruncateTest), MemberType = typeof(ParserTestData))]
        public void TestParse_WhenStringHasMoreThan15Characters_ExpectTruncatedOutput(string stringToParse)
        {
            // Arrange
            var parser = new Services.Parser();

            // Act
            var result = parser.Parse(new[] { stringToParse });

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
            var parser = new Services.Parser();
            var expectedParsedStrings = new[] { expectedResult };

            // Act
            var result = parser.Parse(new[] { stringToParse });

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
            var parser = new Services.Parser();
            var expectedParsedStrings = new[] { expectedResult };

            // Act
            var result = parser.Parse(new[] { stringToParse });

            // Assert
            Assert.True(result.SequenceEqual(expectedParsedStrings));
        }

        [Fact]
        public void TestParse_WhenStringCollectionIsNull_ExpectArgumentNullException()
        {
            // Arrange
            var stringsToParse = default(IEnumerable<string>);
            var parser = new Services.Parser();

            // Act
            void SutCall() => parser.Parse(stringsToParse).ToArray();

            // Assert
            Assert.Throws<ArgumentNullException>(SutCall);
        }
    }
}