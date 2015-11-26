using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
    public class BaseCar
    {
        public string model;
        public int expense;       //расход
        public int Price { get; set; }         //стоимость
        public string fuel;

        public virtual string GetInfo()
        {
            return "The car: " + model +", fuel: "+fuel+", expense: "+ expense +" l/km, price: " + Price + "$";
        }

        public interface ICar
        {
            int Price { get; }
            string GetInfo();
        }
    }
}
