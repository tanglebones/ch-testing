using System;
using System.Diagnostics.CodeAnalysis;
using CH.Testing.T2.Component;
using CH.Testing.T2.Interface;
using NUnit.Framework;

namespace CH.Testing.T2.Test
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class ArgParserTestFixture
    {
        [Test]
        [TestCase(new object[] { new[] { "a", "b", "c" }, -1 }, TestName = "[a, b, c] -1")]
        [TestCase(new object[] { new[] { "a", "b", "c" }, 3 }, TestName = "[a, b, c] 3")]
        [TestCase(new object[] { new string[] { }, 0 }, TestName = "[] 0")]
        [ExpectedException(typeof (IndexOutOfRangeException))]
        public void OutOfBounds(string[] args, int pos)
        {
            // Arrange
            var argParser = new ArgParser(args) as IArgParser;

            // Act
            argParser.ByOrder(pos);
        }

        [Test]
        [TestCase(new object[] { new[] { "a", "b", "c" }, 0, "a" }, TestName = "[a, b, c] 0 -> a")]
        [TestCase(new object[] { new[] { "a", "b", "c" }, 1, "b" }, TestName = "[a, b, c] 1 -> b")]
        [TestCase(new object[] { new[] { "a", "b", "c" }, 2, "c" }, TestName = "[a, b, c] 2 -> c")]
        public void Simple(string[] args, int pos, string expected)
        {
            // Arrange
            var argParser = new ArgParser(args) as IArgParser;

            // Act
            var actual = argParser.ByOrder(pos);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}