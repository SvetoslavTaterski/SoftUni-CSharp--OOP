using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RoomConstructorShouldWorkProperly()
        {
            Room room = new Room(2, 10);

            int expectedRoomBedCapacity = 2;
            int expectedRoomPricePerNight = 10;

            Assert.AreEqual(expectedRoomBedCapacity, room.BedCapacity);
            Assert.AreEqual(expectedRoomPricePerNight, room.PricePerNight);

        }

        [TestCase(0)]
        [TestCase(-20)]
        public void BedCapacityPropertyShouldThrowExceptionIfItIsZeroOrNegative(int bedCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Room room = new Room(bedCapacity, 10);
            });
        }

        [TestCase(0)]
        [TestCase(-20)]
        public void RoomPricePropertyShouldThrowExceptionIfItIsZeroOrNegative(double pricePerNight)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Room room = new Room(2, pricePerNight);
            });
        }

        [Test]
        public void BookingConstructorShouldWorkProperly()
        {
            Booking booking = new Booking(2, new Room(2, 10), 7);
            int expectedBookingNumber = 2;
            Room expectedRoom = booking.Room;
            int expectedResidenceDuration = 7;

            Assert.AreEqual(expectedBookingNumber, booking.BookingNumber);
            Assert.AreEqual(expectedRoom, booking.Room);
            Assert.AreEqual(expectedResidenceDuration, booking.ResidenceDuration);
        }

        [Test]
        public void HotelConstructorShouldWorkProperly()
        {
            Hotel hotel = new Hotel("Vegas", 5);
            string expectedName = "Vegas";
            int expectedCategory = 5;

            Assert.AreEqual(expectedName, hotel.FullName);
            Assert.AreEqual(expectedCategory, hotel.Category);
            Assert.IsTrue(hotel.Bookings != null);
            Assert.IsTrue(hotel.Rooms != null);
        }

        [TestCase(null)]
        [TestCase(" ")]
        public void FullNamePropertyShouldThrowExceptionIfItIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel hotel = new Hotel(name, 5);
            });
        }

        [TestCase(0)]
        [TestCase(6)]
        public void CategoryPropertyShouldThrowExceptionIfCategoryIsSmallerThenOneAndBiggerThanFive(int category)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel("Vegas", category);
            });
        }

        [Test]
        public void TurnoverPropertyShouldWorkProperly()
        {
            Hotel hotel = new Hotel("Vegas", 5);
            double expectedTurnover = 0;
            double actualTurnover = hotel.Turnover;

            Assert.AreEqual(expectedTurnover, actualTurnover);
        }

        [Test]
        public void AddRoomIncreasesCountOfCollection()
        {
            Hotel hotel = new Hotel("Vegas", 5);
            hotel.AddRoom(new Room(2, 5));

            Assert.AreEqual(hotel.Rooms.Count, 1);
        }

        [Test]
        public void RoomsPropertyShouldBeWorkingProperly()
        {
            Hotel hotel = new Hotel("Vegas", 5);
            int expectedRooms = 0;
            int actualRooms = hotel.Rooms.Count;

            Assert.AreEqual(expectedRooms, actualRooms);
        }

        [Test]
        public void BookingPropertyShouldBeWorkingProperly()
        {
            Hotel hotel = new Hotel("Vegas", 5);
            int expectedBookings = 0;
            int actualBookings = hotel.Bookings.Count;

            Assert.AreEqual(expectedBookings,actualBookings);
        }

        [Test]
        public void AddRoomMehtodShouldBeWorkingProperly()
        {
            Hotel hotel = new Hotel("Vegas", 5);
            hotel.AddRoom(new Room(2, 5));

            int expectedRooms = 1;
            int actualRooms = hotel.Rooms.Count;

            Assert.AreEqual(expectedRooms,actualRooms);
        }

        [Test]
        public void BookRoomMethodShouldBeWorkingProperly()
        {
            Hotel hotel = new Hotel("Vegas", 5);
            hotel.AddRoom(new Room(5, 10));
            hotel.BookRoom(2, 1, 4, 50);

            int expectedBookings = 1;
            int actualBookings = hotel.Bookings.Count;

            Assert.AreEqual(expectedBookings,actualBookings);
        }

        [TestCase(0)]
        [TestCase(-20)]
        public void BookRoomMehtodShouldThrowExceptionIfAdultsAreZeroOrNegative(int adults)
        {
            Hotel hotel = new Hotel("Vegas", 5);
            hotel.AddRoom(new Room(5, 10));

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(adults, 1, 4, 50);
            });
        }

        [TestCase(-20)]
        public void BookRoomMehtodShouldThrowExceptionIfChildernAreNegative(int children)
        {
            Hotel hotel = new Hotel("Vegas", 5);
            hotel.AddRoom(new Room(5, 10));

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(2, children, 4, 50);
            });
        }

        [TestCase(0)]
        [TestCase(-20)]
        public void BookRoomMehtodShouldThrowExceptionIfResidenceDurationIsSmallerThanOne(int residenceDuration)
        {
            Hotel hotel = new Hotel("Vegas", 5);
            hotel.AddRoom(new Room(5, 10));

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(2, 1, residenceDuration, 50);
            });
        }

        [Test]
        public void Hotel_BookRoom_DoesntBookIfBedCapacityIsLowerThanBedsNeeded()
        {
            Hotel hotel = new Hotel("Vegas", 5);
            hotel.AddRoom(new Room(2,10));
            hotel.BookRoom(2, 1, 7, 200);

            Assert.AreEqual(hotel.Bookings.Count, 0);
        }

        [Test]
        public void Hotel_BookRoom_ProperlyGeneratesTurnover()
        {
            Hotel hotel = new Hotel("Vegas", 5);
            hotel.AddRoom(new Room(2, 10));

            int residenceDuration = 4;
            double pricePerNight = 10;
            double expectedTurnover = residenceDuration * pricePerNight;

            hotel.BookRoom(1, 1, residenceDuration, 200.0);
            Assert.AreEqual(expectedTurnover, hotel.Turnover);
        }
    }
}