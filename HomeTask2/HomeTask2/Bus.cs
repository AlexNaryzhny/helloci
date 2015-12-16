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
        private readonly int _passengers;

        public Bus(int passengers, string name, string tank, int fuelExpense, int totalPrice)
        {
            _passengers = passengers;
            Price = totalPrice;
            Fuel = tank;
            Expense = fuelExpense;
            Model = name;
        }

        public override string GetInfo()
        {
            return "Bus - model: " + Model + ", fuel: " + Fuel + ", passenger seats: " + _passengers + ", expense: " + Expense + " l/km, price: " + Price + "$";
        }

        public static void BinaryWriteToFile(Bus bus)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("D:\\helloci\\HomeTask2\\HomeTask2\\data\\AddBus.dat", FileMode.OpenOrCreate))
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
            using (FileStream fs = new FileStream("D:\\helloci\\HomeTask2\\HomeTask2\\data\\BusList.dat", FileMode.OpenOrCreate))
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
    }
}
