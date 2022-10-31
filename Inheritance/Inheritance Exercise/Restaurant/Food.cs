using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Food : Product
    {
        public Food(string name, decimal price, double grams) : base(name, price)
        {
            Grams = grams;
        }

        public virtual double Grams { get; set; }
        public override string Name { get => base.Name; set => base.Name = value; }
        public override decimal Price { get => base.Price; set => base.Price = value; }
    }
}
