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
        {Console.WriteLine("Test Init");}

        [TearDown]
        public void Clean()
        {Console.WriteLine("Test cleanup");}

        [Test]
        public void Test1()
        {
            Assert.That(Calc.Add(1.0,1.0), Is.EqualTo(2));
        }

        [TestCase(10, 7, ExpectedResult = 17)]
        public double Test2(double a, double b)
        {
            return Calc.Add(a, b);
        }

        [Test]
        public void Test3()
        {
            var ex = Assert.Throws<InvalidCastException>(() => Calc.Add("hi", 1.0));
            Assert.That(ex.Message, Is.EqualTo("Specified cast is not valid."));
        }

        [Test]
        public void Test4()
        {
            var ex = Assert.Throws<InvalidCastException>(() => Calc.Add("123.0", 1.0));
            Assert.That(ex.Message, Is.EqualTo("Specified cast is not valid."));
        }

        [Test]
        public void Test5()
        {
            Assert.That(Calc.Add(-1.0, 1.0), Is.EqualTo(0));
        }

        [Test]
        public void Test6()
        {
            Assert.That(Calc.Add(-0.0, 1.0), Is.EqualTo(1.0));
        }

        [Test]
        public void Test7()
        {
            Assert.That(Calc.Add(0.0, 1.0), Is.EqualTo(1.0));
        }

        [Test]
        public void Test8()
        {
            Assert.That(Calc.Add(1.7E+3, 1.2E+3), Is.EqualTo(2900.0));
        }
    }
}
