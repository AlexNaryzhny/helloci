using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        public static List<BaseCar.ICar> GenerateCarsList()
        {
            var carList = new List<BaseCar.ICar>
            {
                new SimpleCar(2, "toyota", "petrol", 5, 10000),
                new SimpleCar(4, "mercedes", "disel", 12, 12000),
                new SimpleCar(4, "bmw", "petrol", 16, 20000),
                new SimpleCar(5, "renault", "gas", 20, 15000)
            };
            return carList;
        }

       
        public virtual string GetInfo()
        {
            return "Car - model: " + Model + ", fuel: " + Fuel + ", doors: " + Countofdoors + ", expense: " + Expense + " l/km, price: " + Price + "$";
        }

    }
}
