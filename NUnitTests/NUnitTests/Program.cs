using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace NUnitTests
{
    [TestFixture]
    class Program
    {
        static void Main(string[] args)
        {}

        [Test]
        public static void MyTestFunc()
        {
            //2 переменные-аргумента
            UInt32 a = 2, b = 3;
            //проверяем на неотрицательный результат (Condition)
            Assert.IsTrue(Summa(a, b) >= 0);
            //проверяем результат на принадлежность к целочисленному типу (Type)
            Assert.IsInstanceOf(typeof(UInt32), Summa(a, b));
            //результат-действительно сумма? (Equality)
            Assert.AreEqual(a + b, Summa(a, b));
        }

        static UInt32 Summa(UInt32 a, UInt32 b)
        {
            return a + b;
        }


    }
}
