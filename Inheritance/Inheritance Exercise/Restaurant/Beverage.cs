using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double mililiters) : base(name, price)
        {
            Mililiters = mililiters;
        }

        public double Mililiters { get; set; }
        public override string Name { get => base.Name; set => base.Name = value; }
        public override decimal Price { get => base.Price; set => base.Price = value; }
    }
}
