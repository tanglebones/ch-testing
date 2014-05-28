using System.Collections.Generic;
using CH.Testing.T2.Interface;

namespace CH.Testing.T2.Component
{
    internal sealed class BrianDeadLineDiffByLine : ILineDiffAlgo
    {
        public IEnumerable<ILineDiffResult> Diff(IEnumerable<string> a, IEnumerable<string> b)
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

        internal class Add : ILineDiffResult
        {
            public Add(string line)
            {
                AsString = "+|" + line;
            }

            public string AsString { get; private set; }
        }

        internal class Equal : ILineDiffResult
        {
            public Equal(string line)
            {
                AsString = "=|" + line;
            }

            public string AsString { get; private set; }
        }

        internal class Subtraction : ILineDiffResult
        {
            public Subtraction(string line)
            {
                AsString = "-|" + line;
            }

            public string AsString { get; private set; }
        }
    }
}