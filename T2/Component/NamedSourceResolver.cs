using CH.Testing.T2.Interface;

namespace CH.Testing.T2.Component
{
    internal sealed class NamedSourceResolver : ISource<string>
    {
        private readonly ISource<string> _fileNameSource;
        private readonly INamedSourceToString _fileReader;

        public NamedSourceResolver(INamedSourceToString fileReader, ISource<string> fileNameSource)
        {
            _fileReader = fileReader;
            _fileNameSource = fileNameSource;
        }

        string ISource<string>.Value
        {
            get { return _fileReader.ReadFrom(_fileNameSource.Value); }
        }
    }
}