using System.Collections.Generic;
using CH.Testing.T2.Interface;

namespace CH.Testing.T2.Component
{
    internal sealed class BrainDeadLineDiffByLine : ILineDiffAlgo
    {
        IEnumerable<ILineDiffResult> ILineDiffAlgo.Diff(IEnumerable<string> a, IEnumerable<string> b)
        {
            var aLines = a.GetEnumerator();
            var bLines = b.GetEnumerator();

            var aValid = aLines.MoveNext();
            var bValid = bLines.MoveNext();

            while (aValid && bValid)
            {
                if (aLines.Current == bLines.Current)
                {
                    yield return new Equal(bLines.Current);
                }
                else
                {
                    yield return new Subtraction(aLines.Current);
                    yield return new Add(bLines.Current);
                }
                aValid = aLines.MoveNext();
                bValid = bLines.MoveNext();
            }
            while (aValid)
            {
                yield return new Subtraction(aLines.Current);
                aValid = aLines.MoveNext();
            }
            while (bValid)
            {
                yield return new Add(bLines.Current);
                bValid = bLines.MoveNext();
            }
        }

        private sealed class Add : ILineDiffResult
        {
            private readonly string _asString;

            public Add(string line)
            {
                _asString = "+|" + line;
            }

            string ILineDiffResult.AsString { get { return _asString; } }
        }

        private sealed class Equal : ILineDiffResult
        {
            private readonly string _asString;
            public Equal(string line)
            {
                _asString = "=|" + line;
            }

            string ILineDiffResult.AsString { get { return _asString; } }
        }

        private sealed class Subtraction : ILineDiffResult
        {
            private readonly string _asString;

            public Subtraction(string line)
            {
                _asString = "-|" + line;
            }

            string ILineDiffResult.AsString { get { return _asString; } }
        }
    }
}