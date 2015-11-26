using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
    class Bus : Car
    {
        private int Passengers;

        public Bus AddNewBus(int passengers, string name, string tank, int fuelExpense, int totalPrice)
        {
            Passengers = passengers;
            price = totalPrice;
            fuel = tank;
            expense = fuelExpense;
            model = name;
            return this;
        }

        public List<Bus> GenerateBusList()
        {
            var busList = new List<Bus>
            {
                new Bus().AddNewBus(20, "mercedes", "petrol", 17000, 10),
                new Bus().AddNewBus(40, "neoplan", "diesel", 230000, 20),
                new Bus().AddNewBus(15, "vw", "petrol", 29000, 8),
                new Bus().AddNewBus(7, "nissan", "gas", 25000, 9)
            };
            return busList;
        }

        public virtual string GetInfo()
        {
            return "Bus - model: " + model + ", fuel: " + fuel + ", passenger seats: " + Passengers + ", expense: " + expense + " l/km, price: " + price + "$";
        }
    }
}
