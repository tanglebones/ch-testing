using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CH.Testing.T2.Component;
using CH.Testing.T2.Interface;
using FakeItEasy;
using NUnit.Framework;

namespace CH.Testing.T2.Test
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class LinesResolverTestFixture
    {
        [Test]
        public void Simple()
        {
            // Arrange
            var lineParser = A.Fake<ILineParser>();
            var contentSource = A.Fake<ISource<string>>();
            const string content = "";
            var expected = new[] {""};
            var lineParserParseCall = A.CallTo(() => lineParser.Parse(content));
            lineParserParseCall.Returns(expected);
            var contentSourceValueCall = A.CallTo(() => contentSource.Value);
            contentSourceValueCall.Returns(content);
            var linesResolver = new LinesResolver(lineParser, contentSource) as ISource<IEnumerable<string>>;

            // Act
            var actual = linesResolver.Value;

            // Assert
            lineParserParseCall.MustHaveHappened();
            contentSourceValueCall.MustHaveHappened();
            Assert.AreEqual(expected, actual);
        }
    }
}