using CH.Testing.T2.Interface;

namespace CH.Testing.T2.Component
{
    internal sealed class ArgMappingByPosition : ISource<string>
    {
        private readonly IArgParser _argParser;
        private readonly int _pos;

        public ArgMappingByPosition(IArgParser argParser, int pos)
        {
            _argParser = argParser;
            _pos = pos;
        }

        public string Value
        {
            get { return _argParser.ByOrder(_pos); }
        }
    }
}