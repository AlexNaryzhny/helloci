using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
    public class HeavyCar : BaseCar,BaseCar.ICar
    {
        private int gruzopodemnost;
        public HeavyCar(int weight, string name, string tank, int fuelExpense, int totalPrice)
        {
            gruzopodemnost = weight;
            Price = totalPrice;
            Fuel = tank;
            Expense = fuelExpense;
            Model = name;
        }

      public static List<BaseCar.ICar> GenerateTrucksList()
        {
            var carList = new List<BaseCar.ICar>
            {
                new HeavyCar(100, "volvo", "petrol", 50, 54000),
                new HeavyCar(120, "mercedes", "disel", 40, 30000),
                new HeavyCar(150, "cat", "petrol", 45, 41000),
                new HeavyCar(70, "maz", "disel", 30, 25000)
            };
            return carList;
        }

      public virtual string GetInfo()
        {
            return "Truck - model: " + Model + ", fuel: " + Fuel + ", max weight: " + gruzopodemnost + "t, expense: " + Expense + "l/km, price: " + Price + "$";
        }
    }
}
