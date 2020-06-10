using System;
using System.Collections.Generic;

using Xunit;

namespace StringParser.Services.Tests.Parser
{
    public class ParserTests
    {
        [Fact]
        public void TestParse_WhenStringCollectionIsNull_ExpectArgumentNullException()
        {
            // Arrange
            var stringsToParse = default(IEnumerable<string>);
            var parser = new Services.Parser();

            // Act
            void SutCall() => parser.Parse(stringsToParse);

            // Assert
            Assert.Throws<ArgumentNullException>(SutCall);
        }
    }
}