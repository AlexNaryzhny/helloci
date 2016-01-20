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
            try
            {
                Assert.That(Calc.Add(3.0, 2.0), Is.EqualTo(9.0));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid result of operation");
            }
            
        }

        [Test]
        public void Test2()
        {
            try
            {
                Assert.That(Calc.Add(3.0, 2.0), Is.EqualTo(9.0));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid result of operation");
            }
            
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
                Assert.That(Calc.Add(-3.0, 1.0), Is.EqualTo(-3.0));
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
                Assert.That(Calc.Add(-3.0, 2.0), Is.EqualTo(9.0));
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
                Assert.That(Calc.Add(3.0, 0.0), Is.EqualTo(1.0));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid result of operation");
            }
            
        }
    }
}
