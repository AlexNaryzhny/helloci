using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
    class HeavyCar : Car
    {
        private int Gruzopodemnost;
        public HeavyCar AddNewTruck(int weight, string name, string tank, int fuelExpense, int totalPrice)
        {
            Gruzopodemnost = weight;
            Price = totalPrice;
            fuel = tank;
            expense = fuelExpense;
            model = name;
            return this;
        }

        public List<HeavyCar> GenerateTrucksList()
        {
            var busList = new List<HeavyCar>
            {
                new HeavyCar().AddNewTruck(100, "volvo", "petrol", 54000, 50),
                new HeavyCar().AddNewTruck(120, "mercedes", "diesel", 30000, 40),
                new HeavyCar().AddNewTruck(150, "cat", "petrol", 41000, 45),
                new HeavyCar().AddNewTruck(70, "maz", "diesel", 25000, 30)
            };
            return busList;
        }

        public virtual string GetInfo()
        {
            return "Truck - model: " + model + ", fuel: " + fuel + ", max weight: " + Gruzopodemnost + "t, expense: " + expense + "l/km, price: " + price + "$";
        }
    }
}
