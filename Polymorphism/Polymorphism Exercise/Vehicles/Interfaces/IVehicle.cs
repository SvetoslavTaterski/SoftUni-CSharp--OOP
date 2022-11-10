namespace Vehicles.Interfaces
{
    public interface IVehicle
    {
        public double TankCapacity { get; }

        public double FuelQuantity { get; }

        public double FuelConsumption { get; }

        public string Drive(double distance);

        public void Refuel(double fuel);
    }
}
