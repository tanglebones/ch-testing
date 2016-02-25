using System;
using System.Diagnostics;
using CH.Testing.T2.Interface;

namespace CH.Testing.T2
{
    internal sealed class LineDiffApp : IApp
    {
        private readonly ILineDiffResults _lineDiffResults;
        private readonly IOutputter _outputter;

        public LineDiffApp(IOutputter outputter, ILineDiffResults lineDiffResults)
        {
            _outputter = outputter;
            _lineDiffResults = lineDiffResults;
        }

        void IApp.Run()
        {
            try
            {
                foreach (var dr in _lineDiffResults.Results())
                {
                    _outputter.Output(dr.AsString);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                _outputter.Output(e.Message);
            }
        }
    }
}