using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private double defaultFuelConsumption;
        const double DEFAULT_VEHICLE_FUEL_CONSUMPTION = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
            DefaultFuelConsumption = DEFAULT_VEHICLE_FUEL_CONSUMPTION;
        }

        public virtual double DefaultFuelConsumption 
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
        public virtual double FuelConsumption { get; set; }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * DefaultFuelConsumption;
        }
    }
}
