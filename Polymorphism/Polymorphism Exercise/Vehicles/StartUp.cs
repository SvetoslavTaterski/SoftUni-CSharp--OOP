namespace Vehicles
{
    using System;
    using System.Linq;

    using Classes;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]),double.Parse(carInfo[3]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string action = commands[0];
                string vehicle = commands[1];
                double distanceOrLiters = double.Parse(commands[2]);

                if (action == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        Console.WriteLine(car.Drive(distanceOrLiters));
                    }
                    else if (vehicle == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distanceOrLiters));
                    }
                    else if (vehicle == "Bus")
                    {
                        Console.WriteLine(bus.Drive(distanceOrLiters));
                    }
                }
                else if (action == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        car.Refuel(distanceOrLiters);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(distanceOrLiters);
                    }
                    else if(vehicle == "Bus")
                    {
                        bus.Refuel(distanceOrLiters);
                    }
                }
                else if (action == "DriveEmpty")
                {
                    Console.WriteLine(bus.DriveEmpty(distanceOrLiters));
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
