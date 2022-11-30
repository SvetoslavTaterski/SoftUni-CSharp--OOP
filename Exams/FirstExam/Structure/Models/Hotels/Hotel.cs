using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private double turnover;
        private IRepository<IRoom> rooms;
        private IRepository<IBooking> bookings;

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            rooms = new RoomRepository();
            bookings = new BookingRepository();
        }

        public string FullName
        {
            get
            {
                return fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hotel name cannot be null or empty!");
                }

                fullName = value;
            }
        }

        public int Category
        {
            get
            {
                return category;
            }
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Category should be between 1 and 5 stars!");
                }

                category = value;
            }
        }

        public double Turnover
        {
            get
            {
                double turnover = 0;

                foreach (var item in bookings.All())
                {
                    turnover += item.ResidenceDuration * item.Room.PricePerNight;
                }

                return turnover;
            }
        }

        public IRepository<IRoom> Rooms => rooms;

        public IRepository<IBooking> Bookings => bookings;
    }
}
