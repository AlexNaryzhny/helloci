using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeTask2
{
    class Taxopark
    {
        //	Спроектировать объектную модель для заданной предметной области.
        //    Использовать: классы, наследование, интерфейсы, полиморфизм, инкапсуляция. 
        //    Каждый класс, метод и переменная должны иметь исчерпывающее смысл название и информативный состав.
        //    Необходимо точно продумать, какие классы необходимы для решения задачи. 
        //    Наследование должно применяться только тогда, когда это имеет смысл. 
        //    Классы должны быть грамотно разложены по пакетам. 
        //    Работа с консолью или консольное меню должно быть минимальным 
        //    (только необходимые данные для ввода, выводить только то, что просится в условии задачи). 
        //    Задание представляет собой какую-то предметную область, в которой требуется выделить необходимую иерархию классов 
        //    и реализовать ее с помощью ООП (используя наследование, если необходимо или реализовывая интерфейсы). 
        //    В каждом классе должны быть поля и методы, которые вы посчитаете необходимыми. 
        //    Программа должна создавать объекты различных классов в выделенной предметной области,
        //    объединять их в какой-то набор объектов (использовать коллекции). 
        //    Как правило, задание требует выполнить поиск объектов по заданным критериям.
        //Определить иерархию легковых автомобилей. 
        //Создать таксопарк. 
        //Посчитать стоимость автопарка. 
        //Провести сортировку автомобилей парка по расходу топлива. 
        //Найти автомобиль в компании, соответствующий заданному диапазону параметров.

        private static void Main()
        {
            List<BaseCar.ICar> cars = new List<BaseCar.ICar>();
            BaseCar.ICar newCar = null;
            cars = GenerateCars();
         
            while (true)
            {
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine();
            Console.WriteLine("To add a new car enter 1, to see the total price of taxopark enter 2, to see all cars in Taxopark enter 3, to find some car enterr 4, to Exit 5 (number only):");
            int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        Console.WriteLine(
                            "What kind of car did you want to add: 1 - simple, 2 - bus, 3 - truck, 4 - exit");
                        int nc = Convert.ToInt32(Console.ReadLine());
                        switch (nc)
                        {
                            case 1:
                                newCar = AddNewSimpleCar();
                                Console.WriteLine("Next car will be added: " + newCar.GetInfo());
                                break;
                            case 2:
                                newCar = AddNewBus();
                                Console.WriteLine("Next bus will be added: " + newCar.GetInfo());
                                break;
                            case 3:
                                newCar = AddNewTruck();
                                Console.WriteLine("Next truck will be added: " + newCar.GetInfo());
                                break;
                        }
                        cars.Add(newCar);
                        Console.ReadLine();
                        break;

                    case 2:
                        var total = cars.Sum(x => x.Price);
                        Console.WriteLine("Total price: " + total+"$");
                        break;
                    case 3:
                        foreach (var car in cars)
                        {
                            Console.WriteLine(car.GetInfo());
                        }
                        break;

                    case 4:
                        Console.WriteLine("What did you want to search: 1-model, 2-fuel, 3-price,4-expense, 5-EXIT");
                        int f = Convert.ToInt32(Console.ReadLine());
                        switch (f)
                        {
                            case 1:
                                Console.WriteLine("Enter search criteria: ");
                                FindModel(cars);
                                break;
                            case 2:
                                Console.WriteLine("Enter search criteria: ");
                                FindFuel(cars);
                                break;
                            case 3:
                                Console.WriteLine("Enter search criteria: ");
                                FindPrice(cars);
                                break;
                            case 4:
                                Console.WriteLine("Enter search criteria: ");
                                FindExpense(cars);
                                break;
                            case 5:
                                return;
                        }

                        break;
                    case 5:
                        return;
                }
            }

        }

        public static SimpleCar AddNewSimpleCar()
        {
            Console.WriteLine("Enter parameters for the new Simple Car:");
            Console.WriteLine("model: ");
            string sname = Convert.ToString(Console.ReadLine());
            Console.WriteLine("how many doors: ");
            double sdoors = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("fuel: ");
            string stank = Convert.ToString(Console.ReadLine());
            Console.WriteLine("fuel expense per km: ");
            int sfuelExpense = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("price: ");
            int stotalPrice = Convert.ToInt32(Console.ReadLine());
            SimpleCar.WriteToFile(sdoors, sname, stank, sfuelExpense, stotalPrice);
            return new SimpleCar(sdoors, sname, stank, sfuelExpense, stotalPrice);
        }
        public static Bus AddNewBus()
        {
            Console.WriteLine("Enter parameters for the new Bus:");
            Console.WriteLine("model: ");
            string bname = Convert.ToString(Console.ReadLine());
            Console.WriteLine("how many passenger seats: ");
            int bpassengers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("fuel: ");
            string btank = Convert.ToString(Console.ReadLine());
            Console.WriteLine("fuel expense per km: ");
            int bfuelExpense = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("price: ");
            int btotalPrice = Convert.ToInt32(Console.ReadLine());
            return new Bus(bpassengers, bname, btank, bfuelExpense, btotalPrice);
        }
        public static HeavyCar AddNewTruck()
        {
            Console.WriteLine("Enter parameters for the new Heavy Car:");
            Console.WriteLine("model: ");
            string hname = Convert.ToString(Console.ReadLine());
            Console.WriteLine("for what weight: ");
            int hweight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("fuel: ");
            string htank = Convert.ToString(Console.ReadLine());
            Console.WriteLine("fuel expense per km: ");
            int hfuelExpense = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("price: ");
            int htotalPrice = Convert.ToInt32(Console.ReadLine());
            SimpleCar.WriteToFile(hweight,hname,htank,hfuelExpense,htotalPrice);
            return new HeavyCar(hweight, hname, htank, hfuelExpense, htotalPrice);
        }
        public static List<BaseCar.ICar> GenerateCars()
        {
            List<BaseCar.ICar> carsL = HeavyCar.GenerateTrucksList().ToList();
            carsL.AddRange(SimpleCar.ReadFromFile());
            carsL.AddRange(Bus.GenerateBusList());

            return carsL;
        }

        public static void FindModel(List<BaseCar.ICar> cars)
        {
            string s = Convert.ToString(Console.ReadLine());
            int counter = cars.Count;
            for (int i = 0; i < counter; i++)
            {
                if (cars[i].Model.Contains(s))
                {
                    Console.WriteLine("Result: " + cars[i].GetInfo());
                }
            }
        }
        public static void FindFuel(List<BaseCar.ICar> cars)
        {
            string s = Convert.ToString(Console.ReadLine());
            int counter = cars.Count;
            for (int i = 0; i < counter; i++)
            {
                if (cars[i].Fuel.Contains(s))
                {
                    Console.WriteLine("Result: " + cars[i].GetInfo());
                }
            }
        }
        public static void FindPrice(List<BaseCar.ICar> cars)
        {
            int s = Convert.ToInt32(Console.ReadLine());
            int counter = cars.Count;
            for (int i = 0; i < counter; i++)
            {
                if (cars[i].Price.Equals(s))
                {
                    Console.WriteLine("Result: " + cars[i].GetInfo());
                }
            }
        }
        public static void FindExpense(List<BaseCar.ICar> cars)
        {
            int s = Convert.ToInt32(Console.ReadLine());
            int counter = cars.Count;
            for (int i = 0; i < counter; i++)
            {
                if (cars[i].Expense.Equals(s))
                {
                    Console.WriteLine("Result: " + cars[i].GetInfo());
                }
            }
        }
    }
}

