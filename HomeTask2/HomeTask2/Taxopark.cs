using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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
            Console.WriteLine("To add a new car enter 1, to order a car enter 2, to see all cars in Taxopark enter 3:");
            int ch = Convert.ToInt32(Console.ReadLine());
            List<Car> carList = new List<Car>();

            switch (ch)
            {
                case 1:
                    Console.WriteLine("What kind of car did you want to add: 1 - simple, 2 - bus, 3 - truck");
                    int nc = Convert.ToInt32(Console.ReadLine());
                    switch (nc)
                    {
                        case 1:
                            Console.WriteLine("Enter parameters for the new Simple Car:");
                            Console.WriteLine("model: ");
                            string Sname = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("how many doors: ");
                            double Sdoors = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("fuel: ");
                            string Stank = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("fuel expense per km: ");
                            int SfuelExpense = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("price: ");
                            int StotalPrice = Convert.ToInt32(Console.ReadLine());
                            //carList.Add(SimpleCar.AddNewCar(Sname, Stank, StotalPrice, SfuelExpense));

                            SimpleCar sc = new SimpleCar(Sdoors, Sname, Stank, SfuelExpense, StotalPrice);
                            carList.Add(sc);
                            break;
                        case 2:
                            Console.WriteLine("Enter parameters for the new Bus:");
                            Console.WriteLine("model: ");
                            string Bname = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("how many passenger seats: ");
                            int Bpassengers = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("fuel: ");
                            string Btank = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("fuel expense per km: ");
                            int BfuelExpense = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("price: ");
                            int BtotalPrice = Convert.ToInt32(Console.ReadLine());
                            //carList.Add(SimpleCar.AddNewCar(name, tank, totalPrice, fuelExpense));

                            Bus bc = new Bus(Bpassengers,Bname,Btank,BtotalPrice,BfuelExpense);
                            carList.Add(bc);
                            break;
                        case 3:
                            Console.WriteLine("Enter parameters for the new Heavy Car:");
                            Console.WriteLine("model: ");
                            string Hname = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("for what weight: ");
                            int Hweight = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("fuel: ");
                            string Htank = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("fuel expense per km: ");
                            int HfuelExpense = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("price: ");
                            int HtotalPrice = Convert.ToInt32(Console.ReadLine());
                            //carList.Add(SimpleCar.AddNewCar(name, tank, totalPrice, fuelExpense));

                            HeavyCar hc = new HeavyCar(Hweight, Hname,Htank,HtotalPrice,HfuelExpense);
                            carList.Add(hc);
                            break;
                        default:
                           break;
                    }
                    Console.WriteLine(carList);
                    Console.ReadLine();
                    break;

                case 2:
                    OrderCar();
                    //carList.Add();
                    break;
                case 3:
                    SimpleCar.GetAllCars();
                    break;
                default:
                    break;
            }
            //var sedan = new SimpleCar().CreateNewCar();

            
            

            ////var taxi = new List<Car> {coupe1, sedan, lt, maz};
            //foreach (var car in taxi)
            //{
            //    Console.WriteLine(car+" ");
            //}
            //Console.ReadKey();
        }


    }

}

