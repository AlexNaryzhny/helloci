using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
    class HeavyCar : Car
    {
        public int Gruzopodemnost;
        public HeavyCar(int weight_, string name, string tank, int totalPrice, int fuelExpense)
        {
            this.Gruzopodemnost = weight_;
            this.price = totalPrice;
            this.fuel = tank;
            this.expense = fuelExpense;
            this.model = name;
        }
    }
}
