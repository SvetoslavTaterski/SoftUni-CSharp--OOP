using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            BagOfProducts = new List<Product>();
            Money = money;
            Name = name;
        }

        public List<Product> BagOfProducts { get; set; }

        public string Name 
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public decimal Money 
        {
            get
            {
                return money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        
    }
}
