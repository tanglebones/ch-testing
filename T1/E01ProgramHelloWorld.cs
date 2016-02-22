using System;
using System.Diagnostics.CodeAnalysis;

namespace CH.Testing.T1
{
    public static class E01ProgramHelloWorld
    {
        [ExcludeFromCodeCoverage]
        public static void OriginalMain(string[] args)
        {
            Console.WriteLine("Hello World");
        }
    }
}