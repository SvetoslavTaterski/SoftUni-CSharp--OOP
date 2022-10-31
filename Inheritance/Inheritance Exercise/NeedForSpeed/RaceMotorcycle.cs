using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private double defaultFuelConsumption;
        const double DEFAULT_RACEMOTORCYCLE_FUEL_CONSUMPTION = 8;

        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
            DefaultFuelConsumption = DEFAULT_RACEMOTORCYCLE_FUEL_CONSUMPTION;
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
