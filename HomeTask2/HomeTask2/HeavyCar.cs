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
        public int gruzopodemnost;

        public HeavyCar(){}

        public HeavyCar(int weight, string name, string tank, int fuelExpense, int totalPrice)
        {
            gruzopodemnost = weight;
            Price = totalPrice;
            Fuel = tank;
            Expense = fuelExpense;
            Model = name;
        }
        //public static List<ICar> GenerateTrucksList()
        //{
        //    var carList = new List<ICar>
        //    {
        //        new HeavyCar(100, "volvo", "petrol", 50, 54000),
        //        new HeavyCar(120, "mercedes", "disel", 40, 30000),
        //        new HeavyCar(150, "cat", "petrol", 45, 41000),
        //        new HeavyCar(70, "maz", "disel", 30, 25000)
        //    };
        //    return carList;
        //}

        public virtual string GetInfo()
        {
            return "Truck - model: " + Model + ", fuel: " + Fuel + ", max weight: " + gruzopodemnost + "t, expense: " + Expense + "l/km, price: " + Price + "$";
        }

        public static void SerializeToXmlFile(HeavyCar truck)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(HeavyCar));
            FileStream fs = new FileStream(@"AddTruck.xml", FileMode.OpenOrCreate);
            serializer.Serialize(fs, truck);
            fs.Close();
        }

        public static List<ICar> DeserializeFromXmlFile()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<HeavyCar>));
            FileStream fs = new FileStream(@"TruckList.xml", FileMode.OpenOrCreate);
            List<HeavyCar> heavyCarList = (List<HeavyCar>)deserializer.Deserialize(fs);
            var truckList = heavyCarList.Cast<ICar>().ToList();
            fs.Close();
            return truckList;
        }

        //public static List<ICar> SerializeList(List<HeavyCar> truck)
        //{
        //    var truckIList = new List<ICar>();
        //    XmlSerializer serializer = new XmlSerializer(typeof(List<HeavyCar> ));
        //    using (FileStream fs = new FileStream(@"TruckList.xml", FileMode.OpenOrCreate))
        //    {
        //        serializer.Serialize(fs, truck);
        //    }

        //    using (FileStream fs = new FileStream(@"TruckList.xml", FileMode.OpenOrCreate))
        //    {
        //        List<HeavyCar> truckList = (List<HeavyCar>)serializer.Deserialize(fs);
        //        foreach (HeavyCar p in truckList)
        //        {
        //            truckIList.Add(p);
        //        }
        //    }
        //    return truckIList;
        //}
    }
}

