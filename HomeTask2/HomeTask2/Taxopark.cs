using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace HomeTask2
{
    internal class Taxopark
    {
        private static void Main()
        {

            List<BaseCar.ICar> cars = new List<BaseCar.ICar>();
            BaseCar.ICar newCar = null;
            cars = GenerateCars();

            while (true)
            {
                int ch = 0;
                Console.WriteLine(
                    "*************************************************************************************************");
                Console.WriteLine();
                Console.WriteLine("To add a new car enter 1, " +
                                  "to see the total price of taxopark enter 2, " +
                                  "to see all cars in Taxopark enter 3, " +
                                  "to find some car enter 4, " +
                                  "to Sort all cars by expense enter 5, " +
                                  "to compare Collections enter 6, " +
                                  "to work with JSON file enter 7, " +
                                  "to Exit 0 (number only):");
                try
                {
                    ch = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter numbers only.");
                    Console.ReadKey();
                }

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
                        Console.WriteLine("Total price: " + total + "$");
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
                        SortByExpense(cars);
                        break;
                    case 6:
                        Console.WriteLine(
                            "Select collection pairs: 1- 'ArrayList vs LinkedList', 2-'Stack vs Queue', 3-'HashTable vs Dictionary', 0 - EXIT");
                        int c = Convert.ToInt32(Console.ReadLine());
                        switch (c)
                        {
                            case 1:
                                TestListsCollection();
                                break;
                            case 2:
                                TestStackQueneCollection();
                                break;
                            case 3:
                                TestHashTableDictionaryCollection();
                                break;
                            case 0:
                                return;
                        }
                        break;
                    case 7:
                        Console.WriteLine(
                            "If you want to print info from JSON file press 1, if you want to add a new record to JSON file press 2, to EXIT press 0");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                ReadFromJsonFile();
                                break;
                            case 2:
                                AddJsonFile();
                                break;
                            case 0:
                                return;
                        }
                        break;
                    case 0:
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
            var newCar = new SimpleCar(sdoors, sname, stank, sfuelExpense, stotalPrice);
            SimpleCar.WriteToTxtFile(newCar);
            return newCar;
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
            var newBus = new Bus(bpassengers, bname, btank, bfuelExpense, btotalPrice);
            Bus.BinaryWriteToFile(newBus);
            return newBus;
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
            HeavyCar newTruck = new HeavyCar(hweight, hname, htank, hfuelExpense, htotalPrice);
            HeavyCar.SerializeToXmlFile(newTruck);
            return newTruck;
        }

        public static List<BaseCar.ICar> GenerateCars()
        {
            List<BaseCar.ICar> carsL = HeavyCar.DeserializeFromXmlFile();
            carsL.AddRange(SimpleCar.ReadFromTxtFile());
            carsL.AddRange(Bus.BinaryReadFromFile());

            return carsL;
        }

        public static void FindModel(List<BaseCar.ICar> cars)
        {
            string s = Convert.ToString(Console.ReadLine());
            int counter = cars.Count;
            try
            {
                for (int i = 0; i < counter; i++)
                {
                    if (cars[i].Model.Contains(s))
                    {
                        Console.WriteLine("Result: " + cars[i].GetInfo());
                    }
                }
            }
            catch (ModelNotFoundException ex)
            {
                Console.WriteLine((string) "Model not found: {0}", (object) ex);
                throw;
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

        public static void SortByExpense(List<BaseCar.ICar> cars)
        {
            Console.WriteLine("All cars sorted by expense: ");
            var orderedCars = from i in cars
                orderby i.Expense
                select i;
            foreach (BaseCar.ICar i in orderedCars)
                Console.WriteLine(i.GetInfo());
        }

        private static void TestListsCollection()
        {
            Random rand = new Random();
            Stopwatch sw = new Stopwatch();
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            LinkedList<int> linkedlist1 = new LinkedList<int>();
            LinkedList<int> linkedlist2 = new LinkedList<int>();
            int el;

            sw.Reset();
            Console.Write("Add to List at the front...");
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                list1.Insert(0, rand.Next());
            }
            sw.Stop();
            Console.WriteLine("  Time used: " + sw.ElapsedTicks + " ticks");
            sw.Reset();

            Console.Write("Search in List...");
            sw.Start();
            var res = list1.BinarySearch(50000);
            sw.Stop();
            Console.WriteLine("  Time used: " + sw.ElapsedTicks + " ticks");
            sw.Reset();

            Console.Write("RemoveAt from List at the front...");
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                el = list1[0];
                list1.RemoveAt(0);
                el++;
            }
            sw.Stop();
            Console.WriteLine("  Time used: " + sw.ElapsedTicks + " ticks\n");

            //LinkedList
            sw.Reset();
            Console.Write("AddFirst to LinkedList...");
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                linkedlist1.AddFirst(rand.Next());
            }
            sw.Stop();
            Console.WriteLine("  Time used: " + sw.ElapsedTicks + " ticks");
            sw.Reset();

            Console.Write("Search in LinkedList...");
            sw.Start();
            var resLl = linkedlist1.Contains(50000);
            sw.Stop();
            Console.WriteLine("  Time used: " + sw.ElapsedTicks + " ticks");
            sw.Reset();

            Console.Write("RemoveFirst from LinkedList...");
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                el = linkedlist1.First.Value;
                linkedlist1.RemoveFirst();
                el++;
            }
            sw.Stop();
            Console.WriteLine("  Time used: " + sw.ElapsedTicks + " ticks\n");
        }

        private static void TestStackQueneCollection()
        {
            Random rand = new Random();
            Stopwatch sw = new Stopwatch();
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            int el;

            //Stack
            sw.Reset();
            Console.Write("Adding to Stack...");
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                stack.Push(i);
            }
            sw.Stop();
            Console.WriteLine("  Time used: " + sw.ElapsedTicks + " ticks");

            sw.Reset();
            Console.Write("Search in Stack...");
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                var index = stack.Contains(50000);
            }
            sw.Stop();
            Console.WriteLine("  Time used: " + sw.ElapsedTicks + " ticks");

            sw.Reset();
            Console.Write("Removing from Stack...");
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                el = stack.Pop();
                el++;
            }
            sw.Stop();
            Console.WriteLine("  Time used: " + sw.ElapsedTicks + " ticks\n");
            sw.Reset();

            //Queue
            Console.Write("Add to Queue...");
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                queue.Enqueue(i);
            }
            sw.Stop();
            Console.WriteLine("  Time used: " + sw.ElapsedTicks + " ticks");

            sw.Reset();
            Console.Write("Search in Queue...");
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                queue.Contains(50000);
            }
            sw.Stop();
            Console.WriteLine("  Time used: " + sw.ElapsedTicks + " ticks");

            sw.Reset();
            Console.Write("Removing from Queue...");
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                el = queue.Dequeue();
                el++;
            }
            sw.Stop();
            Console.WriteLine("  Time used: " + sw.ElapsedTicks + " ticks\n");
        }

        private static void TestHashTableDictionaryCollection()
        {
            Stopwatch sw = new Stopwatch();
            Hashtable hash = new Hashtable();
            Dictionary<int, string> dict = new Dictionary<int, string>();

            //HashTable
            sw.Reset();
            Console.Write("Add to Hashtable...");
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                hash.Add(i, "test");
            }
            sw.Stop();
            Console.WriteLine("  Time used: " + sw.ElapsedTicks + " ticks");

            sw.Reset();
            Console.Write("Search in Hashtable...");
            sw.Start();
            hash.ContainsValue(50000);
            sw.Stop();
            Console.WriteLine("  Time used: " + sw.ElapsedTicks + " ticks");

            sw.Reset();
            Console.Write("Remove from Hashtable...");
            sw.Start();
            for (Int64 i = 0; i < hash.Count; i++)
            {
                hash.Remove(i);
            }
            sw.Stop();
            Console.WriteLine("  Time used: " + sw.ElapsedTicks + " ticks\n");

            //Dictionary
            sw.Reset();
            Console.Write("Add to Dictionary...");
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                dict.Add(i, "test" + i);
            }
            sw.Stop();
            Console.WriteLine("  Time used: " + sw.ElapsedTicks + " ticks");

            sw.Reset();
            Console.Write("Search in Hashtable...");
            sw.Start();
            var res = dict.ContainsValue("test50000");
            sw.Stop();
            Console.WriteLine("  Time used: " + sw.ElapsedTicks + " ticks");

            sw.Reset();
            Console.Write("Remove from Dictionary...");
            sw.Start();
            for (int i = 0; i < dict.Count; i++)
            {
                dict.Remove(i);
            }
            sw.Stop();
            Console.WriteLine("  Time used: " + sw.ElapsedTicks + " ticks\n");
        }

        private static void AddJsonFile()
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
            var newCar = new SimpleCar(sdoors, sname, stank, sfuelExpense, stotalPrice);
            WriteJsonFile(newCar);
        }

        private static void WriteJsonFile(SimpleCar car)
        {
            //Serialize Car object to Json
            string jsonCar = JsonConvert.SerializeObject(car);

            using (StreamWriter f = File.CreateText("D:\\helloci\\HomeTask2\\HomeTask2\\data\\AddJsonCar.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(f, jsonCar);
            }
            Console.WriteLine(jsonCar);
        }

        private static void ReadFromJsonFile()
        {
            using (StreamReader r = new StreamReader("D:\\helloci\\HomeTask2\\HomeTask2\\data\\car.json"))
            {
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);

                //Display deserialized cars
                Console.WriteLine(array);
            }
        }

    }

    internal class ModelNotFoundException : Exception
    {
        
    }
}

