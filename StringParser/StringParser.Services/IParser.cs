using System.Collections.Generic;

namespace StringParser.Services
{
    public interface IParser
    {
        IEnumerable<string> Parse(IEnumerable<string> stringsToParse);
    }
}
