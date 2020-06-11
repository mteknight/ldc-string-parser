using System.Linq;

using Xunit;

namespace StringParser.Services.Tests.Parser
{
    public class ParserAcceptanceTests
    {
        [Theory]
        [InlineData("AAAc91%cWwWkLq$1ci3_848v3d__K", "Ac91%cWwWkLq£1c")]
        public void TestParser_WhenSuccessful_ExpectParsedString(
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
    }
}