using CH.Testing.T1.Interface;

namespace CH.Testing.T1.Component
{
    internal sealed class CurrentDateTimeMessageProvider : IMessageProvider
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public CurrentDateTimeMessageProvider(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        string IMessageProvider.Message
        {
            get { return "The current time is: " + _dateTimeProvider.Value; }
        }
    }
}