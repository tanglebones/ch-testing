using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using CH.Testing.T2.Component;
using CH.Testing.T2.Interface;

namespace CH.Testing.T2
{
    internal class Program
    {
        [ExcludeFromCodeCoverage]
        public static void Main(string[] args)
        {
            // Infrastructure Wiring
            var outputter = new StreamOutputter(Console.Out) as IOutputter;

            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));

            var argParser = new ArgParser(args) as IArgParser;
            var aFileNameArgMap = new ArgMappingByPosition(argParser, 0) as ISource<string>;
            var bFileNameArgMap = new ArgMappingByPosition(argParser, 1) as ISource<string>;
            var fileReader = new FileToString() as INamedSourceToString;
            var lineParser = new LineParser() as ILineParser;
            var lineDiffAlgo = new BrianDeadLineDiffByLine() as ILineDiffAlgo;
            var aContent = new NamedSourceResolver(fileReader, aFileNameArgMap) as ISource<string>;
            var aLinesSource = new LinesResolver(lineParser, aContent) as ISource<IEnumerable<string>>;
            var bContent = new NamedSourceResolver(fileReader, bFileNameArgMap) as ISource<string>;
            var bLinesSource = new LinesResolver(lineParser, bContent) as ISource<IEnumerable<string>>;
            var lineDiffResults = new LineDiffResults(lineDiffAlgo, aLinesSource, bLinesSource) as ILineDiffResults;
            var app = new LineDiffApp(outputter, lineDiffResults) as IApp;

            // Go
            app.Run();
        }
    }
}