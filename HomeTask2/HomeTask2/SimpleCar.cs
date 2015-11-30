using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
    public class SimpleCar : BaseCar, BaseCar.ICar
    {
        private double Countofdoors;

        public SimpleCar(double doors, string name, string tank, int fuelExpense, int totalPrice)
        {
            Countofdoors = doors;
            Price = totalPrice;
            Fuel = tank;
            Expense = fuelExpense;
            Model = name;
        }

        public static List<ICar> GenerateCarsList()
        {
            var carList = new List<ICar>
            {
                new SimpleCar(2, "toyota", "petrol", 5, 10000),
                new SimpleCar(4, "mercedes", "disel", 12, 12000),
                new SimpleCar(4, "bmw", "petrol", 16, 20000),
                new SimpleCar(5, "renault", "gas", 20, 15000)
            };
            return carList;
        }

        public static List<ICar> ReadFromFile()
        {
            const string dirName = @"D:\";
            const string fileName = dirName + "Cars.txt";
            DirectoryInfo dir = new DirectoryInfo(dirName);
            List<ICar> carList = new List<ICar>();
            if (!dir.Exists) dir.Create();
            StreamReader r = new StreamReader(fileName);
            while (true)
            {
                string S = r.ReadLine();
                if (S == null) break;
                string[] s = S.Split('\t');
                string name = s[0];
                string fuel = s[1];
                double doors = Convert.ToDouble(s[2]);
                int expence = Convert.ToInt32(s[3]);
                int price = Convert.ToInt32(s[4]);
                carList.Add(new SimpleCar(doors, name, fuel, expence, price));
            }
            r.Close();
            return carList;
        }

        public static void WriteToFile(double doors, string name, string tank, int fuelExpense, int totalPrice)
        {
            const string dirName = @"D:\";
            const string fileName = dirName + "AddCars.txt";
            DirectoryInfo dir = new DirectoryInfo(dirName);
            if (!dir.Exists) dir.Create();
            StreamWriter w = new StreamWriter(fileName, true);	// Открыть файл для записи с дополнением
            w.WriteLine(name + "\t" + tank + "\t" + fuelExpense + "\t" + totalPrice + "\t" + doors); // \t - табуляция, такая запись даже Excell - ом прочтется
            w.Close();
        }

        public virtual string GetInfo()
        {
            return "Car - model: " + Model + ", fuel: " + Fuel + ", doors: " + Countofdoors + ", expense: " + Expense + " l/km, price: " + Price + "$";
        }
    }
}
