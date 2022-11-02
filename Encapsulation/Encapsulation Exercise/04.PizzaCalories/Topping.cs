using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private string type;
        private double grams;

        public Topping(string type, double grams)
        {
            Type = type;
            Grams = grams;
        }

        protected double Grams
        {
            get
            {
                return grams;
            }
            private set
            {
                if (value <= 0 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }
                grams = value;
            }
        }


        protected string Type
        {
            get
            {
                return type;
            }
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" & value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                type = value;
            }
        }

        public double CaloriesPerGram
        {
            get
            {
                double modifier = 0;

                if (type.ToLower() == "meat")
                {
                    modifier = 1.2;
                }
                else if (type.ToLower() == "veggies")
                {
                    modifier = 0.8;
                }
                else if (type.ToLower() == "cheese")
                {
                    modifier = 1.1;
                }
                else if (type.ToLower() == "sauce")
                {
                    modifier = 0.9;
                }

                return Grams * modifier * 2;
            }
        }
    }
}
