using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal COFFEE_PRICE = 3.5m;
        private const double COFFEE_MILILITERS = 50;

        public Coffee(string name, double caffeine) : base(name, COFFEE_PRICE, COFFEE_MILILITERS)
        {
            Caffeine = caffeine;
        }
        public double Caffeine { get; set; }
    }
}
