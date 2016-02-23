using System.Diagnostics.CodeAnalysis;
using CH.Testing.T2.Component;
using CH.Testing.T2.Interface;
using FakeItEasy;
using NUnit.Framework;

namespace CH.Testing.T2.Test
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class ArgMappingByPositionTestFixture
    {
        [Test]
        public void Simple()
        {
            // Arrange
            var argParser = A.Fake<IArgParser>();
            const string expected = "foo";
            const int pos = 0;

            var byOrderCall = A.CallTo(() => argParser.ByOrder(pos));
            byOrderCall.Returns(expected);

            var argMapper = new ArgMappingByPosition(argParser, pos) as ISource<string>;

            // Act
            var actual = argMapper.Value;

            // Assert
            byOrderCall.MustHaveHappened();
            Assert.AreEqual(expected, actual);
        }
    }
}