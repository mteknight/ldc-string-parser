using System.Linq;

using Xunit;

namespace StringParser.Services.Tests.Parser
{
    public class ParserAcceptanceTests
    {
        private readonly IParser _parser;

        public ParserAcceptanceTests()
        {
            _parser = new Services.Parser();
        }

        [Theory]
        [InlineData("AAAc91%cWwWkLq$1ci3_848v3d__K", "Ac91%cWwWkLq£1c")]
        public void TestParser_WhenSuccessful_ExpectParsedString(
            string stringToParse,
            string expectedResult)
        {
            // Arrange
            var expectedParsedStrings = new[] { expectedResult };

            // Act
            var result = _parser.Parse(new[] { stringToParse });

            // Assert
            Assert.True(result.SequenceEqual(expectedParsedStrings));
        }
    }
}