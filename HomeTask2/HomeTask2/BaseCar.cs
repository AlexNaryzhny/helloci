using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace HomeTask2
{
    [Serializable]
    public class BaseCar
    {
        public string Model { get; set; }
        public int Expense { get; set; }
        public int Price { get; set; }
        public string Fuel { get; set; }

        public virtual string GetInfo()
        {
            return "The car: " + Model +", fuel: "+Fuel+", expense: "+ Expense +" l/km, price: " + Price + "$";
        }

        public interface ICar
        {
            string Model { get; }
            int Expense { get; }
            int Price { get; }
            string Fuel { get; }
            string GetInfo();
        }
    }
}
