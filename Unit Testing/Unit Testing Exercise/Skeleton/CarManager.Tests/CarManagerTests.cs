namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Runtime.ConstrainedExecution;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void CarConstructorShouldWorkProperly()
        {
            Car car = new Car("BMW", "3", 7.0, 64.0);

            string carMake = "BMW";
            string actualMake = car.Make;

            string carModel = "3";
            string actualModel = car.Model;

            double carFuelConsumption = 7.0;
            double actualFuelConsumption = car.FuelConsumption;

            double carFuelCapacity = 64.0;
            double actualFuelCapacity = car.FuelCapacity;

            double carFuelAmount = 0;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(carMake, actualMake);
            Assert.AreEqual(carModel, actualModel);
            Assert.AreEqual(carFuelConsumption, actualFuelConsumption);
            Assert.AreEqual(carFuelCapacity, actualFuelCapacity);
            Assert.AreEqual(carFuelAmount, actualFuelAmount);
        }

        [Test]
        public void MakePropertyShouldThrowExceptionIfItIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(null, "3", 7.0, 64.0);
            }, "Make cannot be null or empty!");
        }

        [Test]
        public void MakePropertyShouldThrowExceptionIfItIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("", "3", 7.0, 64.0);
            }, "Make cannot be null or empty!");
        }

        [Test]
        public void ModelPropertyShouldWorkProperly()
        {
            Car car = new Car("BMW", "3", 7.0, 64.0);

            string expectedModel = "3";
            string actualModel = car.Model;

            Assert.AreEqual(expectedModel, actualModel);
        }

        [Test]
        public void ModelPropertyShouldThrowExceptionIfModelIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", null, 7.0, 64.0);
            }, "Model cannot be null or empty!");
        }

        [Test]
        public void ModelPropertyShouldThrowExceptionIfModelIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "", 7.0, 64.0);
            }, "Model cannot be null or empty!");
        }

        [Test]
        public void FuelConsumptionPropertyShouldWorkProperly()
        {
            Car car = new Car("BMW", "3", 7.0, 64.0);

            double expectedFuelConsumption = 7.0;
            double actualFuelConsumption = car.FuelConsumption;

            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
        }

        [Test]
        public void FuelConsumptionShouldThrowExceptionIfItIsZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "3", 0, 64.0);
            });
        }

        [Test]
        public void FuelConsumptionShouldThrowExceptionIfItIsNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "3", -69, 64.0);
            });
        }

        [Test]
        public void FuelAmountPropertyShouldWorkProperly()
        {
            Car car = new Car("BMW", "3", 7.0, 64.0);

            double carExpectedFuelAmount = 0;
            double carActualFuelAmount = car.FuelAmount;

            Assert.AreEqual(carExpectedFuelAmount, carActualFuelAmount);
        }

        [Test]
        public void FuelCapacityPropertyShouldBeWorkingProperly()
        {
            Car car = new Car("BMW", "3", 7.0, 64.0);

            double carExpectedFuelCapacity = 64.0;
            double carActualFuelCapacity = car.FuelCapacity;

            Assert.AreEqual(carExpectedFuelCapacity, carActualFuelCapacity);
        }

        [Test]
        public void FuelCapacityShouldThrowExceptionIfItIsZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "3", 7.0, 0);
            });
        }

        [Test]
        public void FuelCapacityShouldThrowExceptionIfItIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "3", 7.0, -69);
            });
        }

        [Test]
        public void RefuelMethodShouldWorkProperly()
        {
            Car car = new Car("BMW", "3", 7.0, 64.0);
            car.Refuel(60);

            double carExpectedFuel = 60;
            double carActualFuel = car.FuelAmount;

            Assert.AreEqual(carExpectedFuel, carActualFuel);
        }

        [Test]
        public void RefuelMethodShouldThrowExceptionIfFuelIsNegativeNumber()
        {
            Car car = new Car("BMW", "3", 7.0, 64.0);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(-20);
            });
        }

        [Test]
        public void RefuelMethodShouldThrowExceptionIfFuelIsZero()
        {
            Car car = new Car("BMW", "3", 7.0, 64.0);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            });
        }

        [Test]
        public void RefuelMethodShouldAddOnlyUntilCarCapacityIsFull()
        {
            Car car = new Car("BMW", "3", 7.0, 64.0);
            car.Refuel(64.0);
            car.Refuel(20);

            double carExpectedFuel = 64.0;
            double carActualFuel = car.FuelAmount;

            Assert.AreEqual(carExpectedFuel, carActualFuel);
        }

        [Test]
        public void DriveMethodShouldWorkProperly()
        {
            Car car = new Car("BMW", "3", 7.0, 64.0);
            car.Refuel(64.0);
            double carFuelBeforeDrive = car.FuelAmount;
            car.Drive(20);
            double carFuelAfterDrive = car.FuelAmount;

            Assert.AreEqual(carFuelBeforeDrive - 1.4, carFuelAfterDrive);
        }

        [Test]
        public void IfFuelNeededIsBiggerThanFuelAmountWeShouldThrowException()
        {
            Car car = new Car("BMW", "3", 7.0, 64.0);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(20);
            });
        }

        [Test]
        public void PropertyFuelAmount_CantBeNegative()
        {
            Car car = new Car("BMW", "3", 7.0, 64.0);

            TestDelegate action = () => car.Drive(20);
            Assert.Throws<InvalidOperationException>(action);
        }
    }
}