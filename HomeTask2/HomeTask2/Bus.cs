using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
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

        public static List<BaseCar.ICar> GenerateBusList()
        {
            var busList = new List<BaseCar.ICar>
            {
                new Bus(20, "mercedes", "petrol", 10, 17000),
                new Bus(40, "neoplan", "disel", 20, 230000),
                new Bus(15, "vw", "petrol", 8, 29000),
                new Bus(7, "nissan", "gas", 9, 25000)
            };
            return busList;
        }

        public virtual string GetInfo()
        {
            return "Bus - model: " + Model + ", fuel: " + Fuel + ", passenger seats: " + Passengers + ", expense: " + Expense + " l/km, price: " + Price + "$";
        }
    }
}
