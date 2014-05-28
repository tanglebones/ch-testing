using System.Collections.Generic;

namespace CH.Testing.T2.Interface
{
    internal interface ILineDiffResults
    {
        IEnumerable<ILineDiffResult> Results();
    }
}