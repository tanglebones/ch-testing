using System.Diagnostics.CodeAnalysis;
using CH.Testing.T1.Interface;
using NUnit.Framework;

namespace CH.Testing.T1.Test
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class MessageAppTestFixture
    {
        private class StubMessageProvider : IMessageProvider
        {
            public StubMessageProvider(string message)
            {
                Message = message;
            }

            public string Message { get; }
        }

        private class StubOutputter : IOutputter
        {
            public string Outputted { get; private set; }

            public void Output(string what)
            {
                Outputted = what;
            }
        }

        [Test]
        public void TestAppOutputsMessageProvided()
        {
            // Arrange
            var messageProvider = new StubMessageProvider("testing");
            var outputter = new StubOutputter();
            var app = new MessageApp(messageProvider, outputter) as IApp;

            // Act
            app.Run();

            // Assert
            Assert.AreEqual(messageProvider.Message, outputter.Outputted);
        }
    }
}