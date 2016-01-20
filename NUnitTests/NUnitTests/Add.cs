using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CSharpCalculator;
using NUnit.Framework;

namespace NUnitTests
{
    [TestFixture]
    [Description("Testing ADD method")]

    class Add : BaseTest
    {
        [SetUp]
        public void Init()
        { Console.WriteLine("Test Init"); }

        [TearDown]
        public void Clean()
        { Console.WriteLine("Test cleanup"); }

        [Test]
        public void Test1()
        {
            try
            {
                Assert.That(Calc.Add(1.0, 1.0), Is.EqualTo(2));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid result of operation");
            }
        }

        [TestCase(10, 7, ExpectedResult = 17)]
        public double Test2(double a, double b)
        {
            return Calc.Add(a, b);
        }

        //Negative
        [Test]
        public void Test3()
        {
            try
            {
                Calc.Add("hi", 1.0);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Specified cast is not valid.");
            }
        }

        //Negative
        [Test]
        public void Test4()
        {
            try
            {
                Calc.Add("123.0", 1.0);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Specified cast is not valid.");
            }
        }

        [Test]
        public void Test5()
        {
            try
            {
                Assert.That(Calc.Add(-1.0, 1.0), Is.EqualTo(0));
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
                Assert.That(Calc.Add(-0.0, 1.0), Is.EqualTo(1.0));
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
                Assert.That(Calc.Add(0.0, 1.0), Is.EqualTo(1.0));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid result of operation");
            }
        }

        [Test]
        public void Test8()
        {
            try
            {
                Assert.That(Calc.Add(1.7E+3, 1.2E+3), Is.EqualTo(2900.0));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid result of operation");
            }
        }
    }
}
