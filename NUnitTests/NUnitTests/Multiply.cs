using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnitTests
{
    class Multiply : BaseTest
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
                Assert.That(Calc.Multiply(1.0, 1.0), Is.EqualTo(1));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid result of operation");
            }
        }

        [TestCase(10, 7, ExpectedResult = 70)]
        public double Test2(double a, double b)
        {
            return Calc.Multiply(a, b);
        }

        [Test]
        public void Test3()
        {
            try
            {
                Assert.That(Calc.Multiply(-1.0, 1.0), Is.EqualTo(-1.0));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid result of operation");
            }
        }

        [Test]
        public void Test4()
        {
            try
            {
                Assert.That(Calc.Multiply(-0.0, 1.0), Is.EqualTo(0.0));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid result of operation");
            }
        }

        [Test]
        public void Test5()
        {
            try
            {
                Assert.That(Calc.Multiply(0.0, 1.0), Is.EqualTo(0.0));
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
                Assert.That(Calc.Multiply(1.7E+3, 1.2E+3), Is.EqualTo(2040000.0));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid result of operation");
            }
        }
    }
}
