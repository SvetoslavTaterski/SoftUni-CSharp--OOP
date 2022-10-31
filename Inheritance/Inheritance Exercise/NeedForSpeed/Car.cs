using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private double defaultFuelConsumption;
        const double DEFAULT_CAR_FUEL_CONSUMPTION = 3;

        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
            DefaultFuelConsumption = DEFAULT_CAR_FUEL_CONSUMPTION;
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
