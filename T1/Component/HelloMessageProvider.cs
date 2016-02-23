using CH.Testing.T1.Interface;

namespace CH.Testing.T1.Component
{
    internal sealed class HelloMessageProvider : IMessageProvider
    {
        string IMessageProvider.Message
        {
            get { return "Hello World"; }
        }
    }
}