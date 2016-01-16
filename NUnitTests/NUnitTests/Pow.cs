using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnitTests
{
    class Pow :BaseTest
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
            Assert.That(Calc.Add(3.0, 2.0), Is.EqualTo(9.0));
        }

        [TestCase(2, 3, ExpectedResult = 16)]
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
            Assert.That(Calc.Add(-3.0, 1.0), Is.EqualTo(-3.0));
        }

        [Test]
        public void Test6()
        {
            Assert.That(Calc.Add(-3.0, 2.0), Is.EqualTo(9.0));
        }

        [Test]
        public void Test7()
        {
            Assert.That(Calc.Add(3.0, 0.0), Is.EqualTo(1.0));
        }
    }
}
