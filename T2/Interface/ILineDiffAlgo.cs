using System.Collections.Generic;

namespace CH.Testing.T2.Interface
{
    internal interface ILineDiffAlgo
    {
        IEnumerable<ILineDiffResult> Diff(IEnumerable<string> a, IEnumerable<string> b);
    }
}