using CH.Testing.T1.Interface;

namespace CH.Testing.T1.Component
{
    internal sealed class HelloMessageProvider : IMessageProvider
    {
        public string Message
        {
            get { return "Hello World"; }
        }
    }
}