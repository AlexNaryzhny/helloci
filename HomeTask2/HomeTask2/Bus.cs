using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
    [Serializable]
    public class Bus : BaseCar, BaseCar.ICar
    {
        private int Passengers;

        public Bus(int passengers, string name, string tank, int fuelExpense, int totalPrice)
        {
            Passengers = passengers;
            Price = totalPrice;
            Fuel = tank;
            Expense = fuelExpense;
            Model = name;
        }

        //public static List<ICar> GenerateBusList()
        //{
        //    var busList = new List<ICar>
        //    {
        //        new Bus(20, "mercedes", "petrol", 10, 17000),
        //        new Bus(40, "neoplan", "disel", 20, 230000),
        //        new Bus(15, "vw", "petrol", 8, 29000),
        //        new Bus(7, "nissan", "gas", 9, 25000)
        //    };
        //    return busList;
        //}

        public virtual string GetInfo()
        {
            return "Bus - model: " + Model + ", fuel: " + Fuel + ", passenger seats: " + Passengers + ", expense: " + Expense + " l/km, price: " + Price + "$";
        }

        public static void BinaryWriteToFile(Bus bus)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("AddBus.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, bus);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }
                
                Console.WriteLine("Object serialized");
            }
        }

        public static List<ICar> BinaryReadFromFile()
        {
            using (FileStream fs = new FileStream("BusList.dat", FileMode.OpenOrCreate))
            {
                List<ICar> deserilizeBusList = null;
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    deserilizeBusList = (List<ICar>)formatter.Deserialize(fs);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                    throw;  
                }

                Console.WriteLine("Object deserialized");
                return deserilizeBusList;
            }

        }

        //public static void BinaryWriteListToFile()
        //{
        //    var busList = new List<ICar>()
        //    {
        //        new Bus(20, "mercedes", "petrol", 10, 17000),
        //        new Bus(40, "neoplan", "disel", 20, 230000),
        //        new Bus(15, "vw", "petrol", 8, 29000),
        //        new Bus(7, "nissan", "gas", 9, 25000)
        //    };
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    using (FileStream fs = new FileStream("BusList.dat", FileMode.OpenOrCreate))
        //    {
        //        try
        //        {
        //            formatter.Serialize(fs, busList);
        //        }
        //        catch (SerializationException e)
        //        {
        //            Console.WriteLine("Failed to serialize. Reason: " + e.Message);
        //            throw;
        //        }
        //        finally
        //        {
        //            fs.Close();
        //        }

        //        Console.WriteLine("Object serialized");
        //    }
        //}

    }
}
