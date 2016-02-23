using CH.Testing.T2.Interface;

namespace CH.Testing.T2.Component
{
    internal sealed class ArgParser : IArgParser
    {
        private readonly string[] _args;

        public ArgParser(string[] args)
        {
            _args = args;
        }

        string IArgParser.ByOrder(int i)
        {
            return _args[i];
        }
    }
}