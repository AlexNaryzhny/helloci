using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
    public class SimpleCar : Car, Car.ICar
    {
        private double Countofdoors;

        public SimpleCar(double doors, string name, string tank, int fuelExpense, int totalPrice)
        {
            Countofdoors = doors;
            price = totalPrice;
            fuel = tank;
            expense = fuelExpense;
            model = name;
        }

        public List<SimpleCar> GenerateCarsList()
        {
            var carList = new List<SimpleCar>
            {
                new SimpleCar(2, "toyota", "petrol", 10000, 5),
                new SimpleCar(4, "mercedes", "diesel", 12000, 12),
                new SimpleCar(4, "bmw", "petrol", 20000, 16),
                new SimpleCar(5, "renault", "gas", 15000, 20)
            };
            return carList;
        }
        
        public void TotalPrice(List<SimpleCar> carlist)
        {
            foreach (var car in carlist)
            {
                
            }
        }

        public virtual string GetInfo()
        {
            return "Car - model: " + model +", fuel: "+fuel+", doors: "+Countofdoors+", expense: "+ expense +" l/km, price: " + price + "$";
        }

    }
}
