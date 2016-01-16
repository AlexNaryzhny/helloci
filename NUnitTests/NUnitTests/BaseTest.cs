using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCalculator;
using NUnit.Framework;

namespace NUnitTests
{
    [SetUpFixture]
    class BaseTest
    {
        public Calculator Calc;

        [SetUp]
        public void SetUpInit()
        {
            Console.WriteLine("Base Init");
            Calc = new Calculator();
        }
        
        [TearDown]
        public void Cleanup()
        {
            Console.WriteLine("Base Cleanup");
            Calc = null;
        }
    }
}
