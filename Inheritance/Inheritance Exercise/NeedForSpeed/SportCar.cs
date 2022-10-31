using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private double defaultFuelConsumption;
        const double DEFAULT_SPORTCAR_FUEL_CONSUMPTION = 10;

        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
            DefaultFuelConsumption = DEFAULT_SPORTCAR_FUEL_CONSUMPTION;
        }

        public override double DefaultFuelConsumption
        {
            get
            {
                return defaultFuelConsumption;
            }
            set
            {
                defaultFuelConsumption = value;
            }

        }
    }
}
