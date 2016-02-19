using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CH.Testing.T3.Component;
using CH.Testing.T3.Interface;

namespace CH.Testing.T3
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Wiring
            var outputter = new ConsoleOutputter() as IOutputter;
            var results = new DumbyCounter() as ISource<IEnumerable<string>>;
            var resultOutputter = new ResultOutputter(outputter, results) as IResultOutputter;
            
            // App
            resultOutputter.Output();
        }
    }
}
