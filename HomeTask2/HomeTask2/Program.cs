using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
    class Taxopark
    {
        //Определить иерархию легковых автомобилей. 
        //Создать таксопарк. 
        //Посчитать стоимость автопарка. 
        //Провести сортировку автомобилей парка по расходу топлива. 
        //Найти автомобиль в компании, соответствующий заданному диапазону параметров.

        static void Main()
        {
            Console.WriteLine("Список автомобилей:\n");

            var auto = new[]
            {
                new Car {model = "LADA", form = "седан", year = 2015, color = "БАКЛАЖАН", expense = 10, price = 5000},
                new Car {model = "BMW", form = "touring", year = 2010, color = "BLACK", expense = 12, price = 15000},
                new Car {model = "VW", form = "автобус", year = 2001, color = "СЕРЕБРО", expense = 8, price = 8000},
                new Car {model = "Ferrari", form = "купе", year = 1990, color = "красный", expense = 20, price = 500000}
            };

            for(var i=0; i < 4;)
            {
                Console.WriteLine(auto[i]);
                Console.WriteLine();
                i++;
            }

            var sumprice = auto.Sum(car => car.price);

            
            Console.WriteLine("Общая стоимость автомобилей: "+ sumprice);
            Console.WriteLine();

            var y = 'y';

            Console.WriteLine("Применить сортировку?   [y] да/[n] нет");
            var x = Convert.ToChar(Console.ReadLine());
            if (x != y) return;

            Console.WriteLine("Выберете поле для сортировки:   [1] модель/[2] кузов/[3] год/[4] цвет/[5] расход/[6] цена");
            var t = Convert.ToString(Console.ReadLine());
            switch (t)
            {
                case "1":

                    IEnumerable<Car> orderCarsByModel = auto.OrderBy(a => a.model);
                    foreach (var a in orderCarsByModel)
                    {
                        Console.WriteLine(a);
                        Console.WriteLine();
                    }
                    break;
                case "2":

                    IEnumerable<Car> orderCarsByForm = auto.OrderBy(a => a.form);
                    foreach (var a in orderCarsByForm)
                    {
                        Console.WriteLine(a);
                        Console.WriteLine();
                    }
                    break;
                case "3":

                    IEnumerable<Car> orderCarsByYear = auto.OrderBy(a => a.year);
                    foreach (var a in orderCarsByYear)
                    {
                        Console.WriteLine(a);
                        Console.WriteLine();
                    }
                    break;
                case "4":

                    IEnumerable<Car> orderCarsByColor = auto.OrderBy(a => a.color);
                    foreach (var a in orderCarsByColor)
                    {
                        Console.WriteLine(a);
                        Console.WriteLine();
                    }
                    break;
                case "5":

                    IEnumerable<Car> orderCarsByExp = auto.OrderBy(a => a.expense);
                    foreach (var a in orderCarsByExp)
                    {
                        Console.WriteLine(a);
                        Console.WriteLine();
                    }
                    break;
                case "6":

                    IEnumerable<Car> orderCarsByPrice = auto.OrderBy(a => a.price);
                    foreach (var a in orderCarsByPrice)
                    {
                        Console.WriteLine(a);
                        Console.WriteLine();
                    }
                    break;
                default:
                    Console.WriteLine("нет такого варивнта!");
                    Console.ReadKey();
                    return;
            }

            Console.ReadKey();

            Console.WriteLine("Применить сортировку?   [y] да/[n] нет");
            var s = Convert.ToChar(Console.ReadLine());
            if (x != y) return;

            
        }
    }
}

