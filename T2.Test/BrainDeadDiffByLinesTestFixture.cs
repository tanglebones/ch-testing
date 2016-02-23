using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CH.Testing.T2.Component;
using CH.Testing.T2.Interface;
using NUnit.Framework;

namespace CH.Testing.T2.Test
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class BrainDeadDiffByLinesTestFixture
    {
        [Test]
        [TestCase(new object[] { new[] { "a" }, new[] { "b" }, new[] { "-|a", "+|b" } }, TestName = "[a][b] -> -a,+b")]
        [TestCase(new object[] { new[] { "a" }, new string[] { }, new[] { "-|a" } }, TestName = "[a][] -> -a")]
        [TestCase(new object[] { new string[] { }, new[] { "b" }, new[] { "+|b" } }, TestName = "[][b] -> +b")]
        [TestCase(new object[] { new[] { "a", "c" }, new[] { "b", "c" }, new[] { "-|a", "+|b", "=|c" } }, TestName = "[ac][bc] -> -a,+b,=c")]
        public void Simple(IEnumerable<string> a, IEnumerable<string> b, IEnumerable<string> expected)
        {
            // Arrange
            var differ = new BrainDeadLineDiffByLine() as ILineDiffAlgo;

            // Act
            var actual = differ.Diff(a, b);

            // Assert
            CollectionAssert.AreEqual(expected, actual.Select(x => x.AsString));
        }
    }
}