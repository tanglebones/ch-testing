using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using CH.Testing.T2.Component;
using CH.Testing.T2.Interface;
using NUnit.Framework;

namespace CH.Testing.T2.Test
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class StreamOutputterFixture
    {
        [Test]
        public void Simple()
        {
            // Arrange
            var sb = new StringBuilder();
            var stw = new StringWriter(sb) as TextWriter;
            var streamOutputter = new StreamOutputter(stw) as IOutputter;

            // Act
            streamOutputter.Output("test");

            // Assert
            Assert.AreEqual("test" + Environment.NewLine, sb.ToString());
        }
    }
}