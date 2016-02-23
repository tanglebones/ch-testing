using System.Diagnostics.CodeAnalysis;
using CH.Testing.T1.Component;
using CH.Testing.T1.Interface;

namespace CH.Testing.T1
{
    public static class E04ProgramCurrentTime
    {
        [ExcludeFromCodeCoverage]
        // Bootstrap code is difficult to test, and since it is in the critical path it makes 
        // little sense to worry about testing it.
        public static void Main(string[] args)
        {
            // Infrastructure Wiring
            var outputter = new ConsoleOutputter();
            var currentDateTimeProvider = new CurrentDateTimeProvider();
            var messageProvider = new CurrentDateTimeMessageProvider(currentDateTimeProvider);
            var app = new MessageApp(messageProvider, outputter) as IApp;

            // Go
            app.Run();
        }
    }
}