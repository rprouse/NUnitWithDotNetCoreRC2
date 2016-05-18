using NUnit.Common;
using NUnitLite;
using NUnitWithDotNetCoreRC2.Test;
using System;
using System.Reflection;

namespace NUnitWithDotNetCoreRC2.Runner
{
    public class Program
    {
        public static int Main(string[] args)
        {
            return new AutoRun(typeof(CalculatorTests).GetTypeInfo().Assembly)
                .Execute(args, new ExtendedTextWrapper(Console.Out), Console.In);
        }
    }
}
