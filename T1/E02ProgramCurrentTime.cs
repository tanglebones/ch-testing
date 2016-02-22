using System;
using System.Diagnostics.CodeAnalysis;

namespace CH.Testing.T1
{
    public static class E02ProgramCurrentTime
    {
        [ExcludeFromCodeCoverage]
        public static void OriginalMainWithDate(string[] args)
        {
            System.Console.WriteLine("The current time is: " + DateTime.Now);
        }
    }
}