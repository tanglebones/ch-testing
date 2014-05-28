using System.Collections.Generic;
using CH.Testing.T2.Interface;

namespace CH.Testing.T2.Component
{
    internal sealed class LinesResolver : ISource<IEnumerable<string>>
    {
        private readonly ILineParser _lineParser;
        private readonly ISource<string> _source;

        public LinesResolver(ILineParser lineParser, ISource<string> source)
        {
            _lineParser = lineParser;
            _source = source;
        }

        public IEnumerable<string> Value { get { return _lineParser.Parse(_source.Value); } }
    }
}