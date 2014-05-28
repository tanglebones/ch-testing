using System;
using System.Diagnostics.CodeAnalysis;
using CH.Testing.T1.Interface;

namespace CH.Testing.T1.Component
{
    internal sealed class ConsoleOutputter : IOutputter
    {
        // System Wrapper, verified by system test.
        [ExcludeFromCodeCoverage]
        public void Output(string what)
        {
            Console.Out.WriteLine(what);
        }
    }
}