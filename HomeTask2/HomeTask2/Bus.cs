using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
    class Bus : Car
    {
        public int passengers;
        public Bus(int passengers_, string name, string tank, int totalPrice, int fuelExpense)
        {
            this.passengers = passengers_;
            this.price = totalPrice;
            this.fuel = tank;
            this.expense = fuelExpense;
            this.model = name;
        }
    }
}
