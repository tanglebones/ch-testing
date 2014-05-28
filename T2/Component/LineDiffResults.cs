using System.Collections.Generic;
using CH.Testing.T2.Interface;

namespace CH.Testing.T2.Component
{
    internal sealed class LineDiffResults : ILineDiffResults
    {
        public LineDiffResults(ILineDiffAlgo lineDiffAlgo, ISource<IEnumerable<string>> aLinesSource, ISource<IEnumerable<string>> bLinesSource)
        {
            _lineDiffAlgo = lineDiffAlgo;
            _aLinesSource = aLinesSource;
            _bLinesSource = bLinesSource;
        }

        private readonly ISource<IEnumerable<string>> _aLinesSource;
        private readonly ISource<IEnumerable<string>> _bLinesSource;
        private readonly ILineDiffAlgo _lineDiffAlgo;

        public IEnumerable<ILineDiffResult> Results()
        {
            return _lineDiffAlgo.Diff(_aLinesSource.Value, _bLinesSource.Value);
        }
    }
}