using System.Collections.Generic;

namespace CH.Testing.T2.Interface
{
    internal interface ILineParser
    {
        IEnumerable<string> Parse(string s);
    }
}