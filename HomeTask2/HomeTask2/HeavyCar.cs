using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HomeTask2
{
    [Serializable]
    public class HeavyCar : BaseCar,BaseCar.ICar
    {
        public int Gruzopodemnost;

        public HeavyCar(){}

        public HeavyCar(int weight, string name, string tank, int fuelExpense, int totalPrice)
        {
            Gruzopodemnost = weight;
            Price = totalPrice;
            Fuel = tank;
            Expense = fuelExpense;
            Model = name;
        }

        public override string GetInfo()
        {
            return "Truck - model: " + Model + ", fuel: " + Fuel + ", max weight: " + Gruzopodemnost + "t, expense: " + Expense + "l/km, price: " + Price + "$";
        }

        public static void SerializeToXmlFile(HeavyCar truck)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(HeavyCar));
            FileStream fs = new FileStream(@"D:\helloci\HomeTask2\HomeTask2\data\AddTruck.xml", FileMode.OpenOrCreate);
            serializer.Serialize(fs, truck);
            fs.Close();
        }

        public static List<ICar> DeserializeFromXmlFile()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<HeavyCar>));
            FileStream fs = new FileStream(@"D:\helloci\HomeTask2\HomeTask2\data\TruckList.xml", FileMode.OpenOrCreate);
            List<HeavyCar> heavyCarList = (List<HeavyCar>)deserializer.Deserialize(fs);
            var truckList = heavyCarList.Cast<ICar>().ToList();
            fs.Close();
            return truckList;
        }

    }
}

