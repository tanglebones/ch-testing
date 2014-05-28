using System.Diagnostics.CodeAnalysis;
using CH.Testing.T1.Component;
using CH.Testing.T1.Interface;
using NUnit.Framework;

namespace CH.Testing.T1.Test
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class HelloMessageProviderTestFixture
    {
        [Test]
        public void HelloMessageIsCorrect()
        {
            // Arrange
            var messageProvider = new HelloMessageProvider() as IMessageProvider;

            // Act
            var message = messageProvider.Message;

            // Assert
            StringAssert.Contains("hello", message.ToLowerInvariant());
        }
    }
}