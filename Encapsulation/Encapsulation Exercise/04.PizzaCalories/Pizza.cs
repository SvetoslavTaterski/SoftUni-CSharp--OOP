using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }

        public string Name 
        { 
            get 
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public Dough Dough
        {
            get
            {
                return dough;
            }
            set
            {
                dough = value;
            }
        }

        public int CountOfToppings { get { return toppings.Count; } }

        public double AllCalories 
        {
            get
            {
                return dough.CaloriesPerGram + toppings.Sum(t => t.CaloriesPerGram);
            }
        }

        public void AddTopping(Topping topping)
        {
            toppings.Add(topping);

            if (toppings.Count > 10)
            {
                toppings.Remove(topping);
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }

        public override string ToString()
        {
            return $"{Name} - {AllCalories:f2} Calories.";
        }
    }
}
