using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace transpot
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("transpot matrix");
            Console.WriteLine("-----------------");
            Console.WriteLine("Enter the size for array...");
            Console.WriteLine("X:");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Y:");
            int y = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[x, y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.WriteLine(string.Format("Enter the value [{0}:{1}]...", i, j));
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("Entered array:");
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                    
                    Console.Write("{0} ", matrix[i, j]);

                Console.WriteLine();
            }

            Console.WriteLine("Transpoted array:");
            for (int j = 0; j < y; j++)
            {
                for (int r = 0; r < x; r++)
                    
                    Console.Write("{0} ", matrix[r, j]);

                Console.WriteLine();
            }

            int[,] newArray = new int[y, x];
            for (int j = 0; j < y; j++)
                for (int r = 0; r < x; r++)
                    newArray[j, r] = matrix[r, j];
            
            Console.ReadLine();

        }
    }
}