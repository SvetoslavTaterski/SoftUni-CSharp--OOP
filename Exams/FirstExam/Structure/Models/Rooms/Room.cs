using BookingApp.Models.Rooms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private readonly int bedCapacity;
        private double pricePerNight;

        public Room(int bedCapacity)
        {
            this.bedCapacity = bedCapacity;
            pricePerNight = 0;
        }

        public int BedCapacity => bedCapacity;

        public double PricePerNight
        {
            get
            {
                return pricePerNight;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }

                pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            PricePerNight = price;
        }
    }
}
