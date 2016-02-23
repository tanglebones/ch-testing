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
    internal sealed class LineDiffResultsTestFixture
    {
        [Test]
        public void Simple()
        {
            // Arrange
            var lineDiffAlgo = A.Fake<ILineDiffAlgo>();
            var aLinesSource = A.Fake<ISource<IEnumerable<string>>>();
            var bLinesSource = A.Fake<ISource<IEnumerable<string>>>();
            var aLines = new[] {"a"};
            var bLines = new[] {"b"};
            var aLinesValueCall = A.CallTo(() => aLinesSource.Value);
            aLinesValueCall.Returns(aLines);
            var bLinesValueCall = A.CallTo(() => bLinesSource.Value);
            bLinesValueCall.Returns(bLines);
            var lineDiffAlgoDiffCall = A.CallTo(() => lineDiffAlgo.Diff(aLines,bLines));
            var expected = new[] {A.Fake<ILineDiffResult>()};
            lineDiffAlgoDiffCall.Returns(expected);
            var ld = new LineDiffResults(lineDiffAlgo, aLinesSource, bLinesSource) as ILineDiffResults;

            // Act
            var actual = ld.Results();

            // Assert
            aLinesValueCall.MustHaveHappened();
            bLinesValueCall.MustHaveHappened();
            lineDiffAlgoDiffCall.MustHaveHappened();
            Assert.AreEqual(actual,expected);
        }
    }
}