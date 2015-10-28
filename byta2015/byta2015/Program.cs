using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace byta2015
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("simple calculator");
            Console.WriteLine("-----------------");
            Console.WriteLine("enter first number:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("select operator(+ - * /):");
            string oper = Console.ReadLine();
            Console.WriteLine("enter second number:");
            int b = Convert.ToInt32(Console.ReadLine());

            if (oper=="+")
            {
                Add(a,b);
            }
            if (oper == "-")
            {
                sub(a, b);
            }
            if (oper == "*")
            {
                mult(a, b);
            }
            if (oper == "/")
            {
                div(a, b);
            }
            else
            {
                
            }

            Console.ReadKey(true);
        }

        public static void Add(int a, int b)
        {
            Console.WriteLine("result:");
            Console.WriteLine(a+b);
        }

        public static void sub(int a, int b)
        {
            Console.WriteLine("result:");
            Console.WriteLine(a - b);
        }

        public static void mult(int a, int b)
        {
            Console.WriteLine("result:");
            Console.WriteLine(a * b);
        }

        public static void div(int a, int b)
        {
            if (b <= 0)
            {
                Console.WriteLine("devide by zero!");
            }
            else
            {
                Console.WriteLine("result:");
                Console.WriteLine(Convert.ToDecimal(a / b));
            }
        }
    }
}
