using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
    public class SimpleCar : BaseCar, BaseCar.ICar
    {
        private readonly double _countofdoors;

        public SimpleCar(double doors, string name, string tank, int fuelExpense, int totalPrice)
        {
            _countofdoors = doors;
            Price = totalPrice;
            Fuel = tank;
            Expense = fuelExpense;
            Model = name;
        }

        public static List<ICar> ReadFromTxtFile()
        {
            const string filePath = "@//..//..//..//data//CarsList.txt";
            List<ICar> carList = new List<ICar>();
            StreamReader r = new StreamReader(filePath);
            try
            {
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
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine("File not found: {0}", exception);
                throw;
            }
            finally
            {
                r.Close();
            }
            
            return carList;
        }

        public static void WriteToTxtFile(SimpleCar car)
        {
            const string filePath = "@//..//..//..//data//AddCars.txt";
            StreamWriter w = new StreamWriter(filePath, true);
            w.WriteLine(car.Model + "\t" + car.Fuel + "\t" + car.Expense + "\t" + car.Price + "\t" + car._countofdoors);
            w.Close();
        }

        public override string GetInfo()
        {
            return "Car - model: " + Model + ", fuel: " + Fuel + ", doors: " + _countofdoors + ", expense: " + Expense + " l/km, price: " + Price + "$";
        }
    }
}
