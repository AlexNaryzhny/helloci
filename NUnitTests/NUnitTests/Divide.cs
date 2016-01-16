using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnitTests
{
    class Divide : BaseTest
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
            Assert.That(Calc.Divide(1.0, 1.0), Is.EqualTo(1.0));
        }

        [TestCase(10, 7, ExpectedResult = 1.4285714285714286)]
        public double Test2(double a, double b)
        {
            return Calc.Divide(a, b);
        }

        [Test]
        public void Test3()
        {
            Assert.That(Calc.Divide(-1.0, 1.0), Is.EqualTo(-1.0));
        }

        [Test]
        public void Test4()
        {
            Assert.That(Calc.Divide(-0.0, 1.0), Is.EqualTo(-0.0));
        }

        [Test]
        public void Test5()
        {
            Assert.That(Calc.Divide(0.0, 1.0), Is.EqualTo(0.0));
        }

        [Test]
        public void Test6()
        {
            Assert.That(Calc.Divide(1.7E+3, 1.2E+3), Is.EqualTo(1.4166666666666667));
        }

        [Test]
        public void Test7()
        {
            Assert.That(Calc.Divide(1.0, 0.0), Is.EqualTo(Double.PositiveInfinity));
        }
    }
}
