using CH.Testing.T1.Interface;

namespace CH.Testing.T1
{
    internal sealed class MessageApp : IApp
    {
        private readonly IMessageProvider _messageProvider;
        private readonly IOutputter _outputter;

        public MessageApp(IMessageProvider messageProvider, IOutputter outputter)
        {
            _messageProvider = messageProvider;
            _outputter = outputter;
        }

        void IApp.Run()
        {
            _outputter.Output(_messageProvider.Message);
        }
    }
}