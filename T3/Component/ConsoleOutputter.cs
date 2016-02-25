﻿using System;
using CH.Testing.T3.Interface;

namespace CH.Testing.T3.Component
{
    internal sealed class ConsoleOutputter : IOutputter
    {
        public void Output(string what)
        {
            Console.WriteLine(what);
        }
    }
}