using System.Collections.Generic;
using CH.Testing.T3.Interface;

namespace CH.Testing.T3.Component
{
    internal class ResultOutputter : IResultOutputter
    {
        private readonly IOutputter _outputter;
        private readonly ISource<IEnumerable<string>> _resultSource;

        public ResultOutputter(IOutputter outputter, ISource<IEnumerable<string>> resultsSource)
        {
            _outputter = outputter;
            _resultSource = resultsSource;
        }

        public void Output()
        {
            var results = _resultSource.Value;
            foreach (var r in results)
                _outputter.Output(r);
        }
    }
}