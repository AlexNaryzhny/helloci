using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnitTests
{
    [TestFixture]
    [Description("Testing ADD method")]
    class Sub : BaseTest
    {
        //[SetUp]
        //public void Init()
        //{Console.WriteLine("Test Init");}

        //[TearDown]
        //public void Clean()
        //{Console.WriteLine("Test cleanup");}

        [Test]
        public void Test1()
        {
            try
            {
                Assert.That(Calc.Sub(1.0,1.0), Is.EqualTo(0));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid result of operation");
            }
        }

        [TestCase(10, 7, ExpectedResult = 3.0)]
        public double Test2(double a, double b)
        {
            return Calc.Sub(a, b);
        }

        //Negative
        [Test]
        public void Test3()
        {
            try
            {
                Calc.Sub("hi", 1.0);
            }
            catch (NotFiniteNumberException)
            {
                Console.WriteLine("Wrong input");
            }
        }

        //Negative
        [Test]
        public void Test4()
        {
            try
            {
                Calc.Sub("123.0", 1.0);
            }
            catch (NotFiniteNumberException)
            {
                Console.WriteLine("Wrong input");
            }
        }

        [Test]
        public void Test5()
        {
            try
            {
                Assert.That(Calc.Sub(-1.0, 1.0), Is.EqualTo(-2.0));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid result of operation");
            }
        }

        [Test]
        public void Test6()
        {
            try
            {
                Assert.That(Calc.Sub(0.0, 1.0), Is.EqualTo(-1.0));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid result of operation");
            }
        }

        [Test]
        public void Test7()
        {
            try
            {
                Assert.That(Calc.Sub(1.7E+3, 1.2E+3), Is.EqualTo(500.0));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid result of operation");
            }
            
        }
    }
}

