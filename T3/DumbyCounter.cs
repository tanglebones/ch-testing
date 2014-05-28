using System.Collections.Generic;
using CH.Testing.T3.Interface;

namespace CH.Testing.T3
{
    internal sealed class DumbyCounter : ISource<IEnumerable<string>>
    {
        private readonly IEnumerable<string> _fakeResults =
            new[]
                {
                    "a", "b", "c", "d", "e",
                    "f", "g", "h", "i", "j"
                };

        public IEnumerable<string> Value
        {
            get { return _fakeResults; }
        }
    }
}