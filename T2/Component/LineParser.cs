using System;
using System.Collections.Generic;
using CH.Testing.T2.Interface;

namespace CH.Testing.T2.Component
{
    internal sealed class LineParser : ILineParser
    {
        private static readonly string[] Separator = new[] {Environment.NewLine};

        public IEnumerable<string> Parse(string s)
        {
            return s.Split(Separator, int.MaxValue, StringSplitOptions.None);
        }
    }
}