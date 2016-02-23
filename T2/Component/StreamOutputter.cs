using System.IO;
using CH.Testing.T2.Interface;

namespace CH.Testing.T2.Component
{
    internal sealed class StreamOutputter : IOutputter
    {
        private readonly TextWriter _stream;

        public StreamOutputter(TextWriter stream)
        {
            _stream = stream;
        }

        void IOutputter.Output(string s)
        {
            _stream.WriteLine(s);
        }
    }
}