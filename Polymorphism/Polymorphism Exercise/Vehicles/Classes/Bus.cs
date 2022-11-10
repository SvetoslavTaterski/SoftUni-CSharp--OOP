namespace Vehicles.Classes
{
    using System;
    
    using Interfaces;
    class Bus : IVehicle
    {
        private const double FUEL_CONSUMPTION_INCREASED = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelConsumption = fuelConsumption + FUEL_CONSUMPTION_INCREASED;

            if (fuelQuantity > tankCapacity)
            {
                FuelQuantity = 0;
            }
            else
            {
                FuelQuantity = fuelQuantity;
            }
        }

        public double TankCapacity { get; private set; }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public string Drive(double distance)
        {
            if (this.FuelQuantity < this.FuelConsumption * distance)
            {
                return "Bus needs refueling";
            }

            this.FuelQuantity -= this.FuelConsumption * distance;
            return $"Bus travelled {distance} km";
        }

        public string DriveEmpty(double distance)
        {
            if (this.FuelQuantity < (this.FuelConsumption - FUEL_CONSUMPTION_INCREASED) * distance)
            {
                return "Bus needs refueling";
            }

            this.FuelQuantity -= (this.FuelConsumption - FUEL_CONSUMPTION_INCREASED) * distance;
            return $"Bus travelled {distance} km";
        }

        public void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            if (fuel + FuelQuantity > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                return;
            }

            FuelQuantity += fuel * 0.95;
        }

        public override string ToString()
        {
            return $"Bus: {FuelQuantity:f2}";
        }
    }
}
