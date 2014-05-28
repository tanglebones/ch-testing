using System.Diagnostics.CodeAnalysis;
using CH.Testing.T2.Component;
using CH.Testing.T2.Interface;
using NUnit.Framework;

namespace CH.Testing.T2.Test
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class LineParserTestFixture
    {
        [Test]
        [TestCase(new object[] { "a\r\nb", new[] { "a", "b" } }, TestName = "\"a\\r\\nb\" -> [\"a\", \"b\"]")]
        [TestCase(new object[] { "", new[] { "" } }, TestName = "\"\" -> [\"\"]")]
        public void Simple(string input, string[] expected)
        {
            // Arrange
            var lineParser = new LineParser() as ILineParser;

            // Act
            var actual = lineParser.Parse(input);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}