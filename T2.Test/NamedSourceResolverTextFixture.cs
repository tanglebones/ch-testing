using System.Diagnostics.CodeAnalysis;
using CH.Testing.T2.Component;
using CH.Testing.T2.Interface;
using FakeItEasy;
using NUnit.Framework;

namespace CH.Testing.T2.Test
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class NamedSourceResolverTextFixture
    {
        [Test]
        public void Simple()
        {
            // Arrange
            var namedSourceToString = A.Fake<INamedSourceToString>();
            var nameSource = A.Fake<ISource<string>>();
            const string name = "n";
            var nameSourceValueCall = A.CallTo(() => nameSource.Value);
            nameSourceValueCall.Returns(name);
            const string expected = "e";
            var namedSourceToStringReadFromCall = A.CallTo(() => namedSourceToString.ReadFrom(name));
            namedSourceToStringReadFromCall.Returns(expected);
            var namedSourceResolver = new NamedSourceResolver(namedSourceToString, nameSource) as ISource<string>;

            // Act
            var actual = namedSourceResolver.Value;

            // Assert
            nameSourceValueCall.MustHaveHappened();
            namedSourceToStringReadFromCall.MustHaveHappened();
            Assert.AreEqual(expected, actual);
        }
    }
}