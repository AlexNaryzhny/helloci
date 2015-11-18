using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
    class Car : Taxopark
    {
        public string model;      //автомобиль
        public string form;       //кузов
        public int year;          //год 
        public string color;      // цвет
        public int expense;       //расход
        public int price;         //стоимость

        public override string ToString()
        {
            return "Автомобиль: " + model + "\n" + "Кузов: " + form + "\n" + "Год выпуска: " + year + "\n" + "Цвет: " + color + "\n" + "Расход: " + expense + "\n" + "Стоимость: " + price;
        }
    }



}
