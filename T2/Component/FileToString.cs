using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using CH.Testing.T2.Interface;

namespace CH.Testing.T2.Component
{
    [ExcludeFromCodeCoverage]
    // System Wrapper
    internal sealed class FileToString : INamedSourceToString
    {
        string INamedSourceToString.ReadFrom(string name)
        {
            try
            {
                return File.ReadAllText(name);
            }
            catch
            {
                throw new Exception("File " + name + " does not exist.");
            }
        }
    }
}