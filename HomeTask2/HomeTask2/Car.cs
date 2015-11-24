using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
    public class Car
    {
        public string model;
        public int year;          //год 
        public int expense;       //расход
        public int price;         //стоимость

        public override string ToString()
        {
            return "The car: " + model +", year: "+ year +", expense: "+ expense +" l/km, price: " + price + "$";
        }
    }


}
