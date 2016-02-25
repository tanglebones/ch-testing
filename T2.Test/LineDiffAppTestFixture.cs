using System;
using System.Diagnostics.CodeAnalysis;
using CH.Testing.T2.Interface;
using FakeItEasy;
using NUnit.Framework;

namespace CH.Testing.T2.Test
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class LineDiffAppTestFixture
    {
        [Test]
        public void Exception()
        {
            // Arrange
            var outputter = A.Fake<IOutputter>();
            const string exceptionMessage = "a";
            var outputterOutputCall = A.CallTo(() => outputter.Output(exceptionMessage));
            var lineDiffResults = A.Fake<ILineDiffResults>();
            var lineDiffResultsResultsCall = A.CallTo(() => lineDiffResults.Results());
            lineDiffResultsResultsCall.Throws(_ => new Exception(exceptionMessage));
            var lineDiffApp = new LineDiffApp(outputter, lineDiffResults) as IApp;

            // Act
            lineDiffApp.Run();

            // Assert
            outputterOutputCall.MustHaveHappened();
            lineDiffResultsResultsCall.MustHaveHappened();
        }

        [Test]
        public void Simple()
        {
            // Arrange
            var outputter = A.Fake<IOutputter>();
            const string lineDiffAsString = "a";
            var outputterOutputCall = A.CallTo(() => outputter.Output(lineDiffAsString));
            var lineDiffResults = A.Fake<ILineDiffResults>();
            var lineDiffResultsResultsCall = A.CallTo(() => lineDiffResults.Results());
            var lineDiffResult = A.Fake<ILineDiffResult>();
            var lineDiffResultAsStringCall = A.CallTo(() => lineDiffResult.AsString);
            lineDiffResultAsStringCall.Returns(lineDiffAsString);
            var results = new[] {lineDiffResult};
            lineDiffResultsResultsCall.Returns(results);
            var lineDiffApp = new LineDiffApp(outputter, lineDiffResults) as IApp;

            // Act
            lineDiffApp.Run();

            // Assert
            outputterOutputCall.MustHaveHappened();
            lineDiffResultsResultsCall.MustHaveHappened();
            lineDiffResultAsStringCall.MustHaveHappened();
        }
    }
}