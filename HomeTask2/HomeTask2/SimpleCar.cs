using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
    class SimpleCar : Car
    {
        public double Countofdoors;

        public SimpleCar(double doors_, string name, string tank, int totalPrice, int fuelExpense)
        {
            this.Countofdoors = doors_;
            this.price = totalPrice;
            this.fuel = tank;
            this.expense = fuelExpense;
            this.model = name;
        }

        public SimpleCar Sc1 = new SimpleCar(2, "toyota", "petrol", 10000, 5);

        //public static List<Car> SimpleCarsList = new List<Car>
        //{
        //    SimpleCarsList.Add(Sc1)
        //};

        public static Car GetAllCars()
        {
            return ;
        }

        public override string ToString()
        {
            return "The car: " + model +", fuel: "+fuel+", doors: "+Countofdoors+", expense: "+ expense +" l/km, price: " + price + "$";
        }

    }
}
