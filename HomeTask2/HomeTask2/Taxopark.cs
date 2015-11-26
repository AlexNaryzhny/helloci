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
            //List<SimpleCar> carList = new SimpleCar().GenerateCarsList();
            List<BaseCar.ICar> cars = new List<BaseCar.ICar>();
            BaseCar.ICar newCar = null;
            cars = GenerateCars();

            while (true)
            {
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine();
            Console.WriteLine("To add a new car enter 1, to see the total price of taxopark enter 2, to see all cars in Taxopark enter 3, to Exit 4:");
            int ch = Convert.ToInt32(Console.ReadLine());
            
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("What kind of car did you want to add: 1 - simple, 2 - bus, 3 - truck, 4 - exit");
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
                        Console.WriteLine("Total price: "+total);
                        break;
                    case 3:
                        foreach (var car in cars)
                        {
                            Console.WriteLine(car.GetInfo());
                        }
                        break;
                    case 4:
                        return;
                    default:
                       char n = (char)Console.Read();
                       Console.WriteLine("You enter - " + n);
                       break;
                        
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
            return new HeavyCar(hweight, hname, htank, hfuelExpense, htotalPrice);
        }

        public static List<BaseCar.ICar> GenerateCars()
        {
            List<BaseCar.ICar> carsL = new List<BaseCar.ICar>();
            foreach (var truck in HeavyCar.GenerateTrucksList())
            {
                carsL.Add(truck);
            }
            foreach (var car in SimpleCar.GenerateCarsList())
            {
                carsL.Add(car);
            }
            foreach (var bus in Bus.GenerateBusList())
            {
                carsL.Add(bus);
            }

            return carsL;
        }
    }
}

