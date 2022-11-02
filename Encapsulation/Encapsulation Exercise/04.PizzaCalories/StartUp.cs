using System;
using System.Linq;

namespace _04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string pizzaName = Console.ReadLine().Split(" ")[1];
                string[] doughInfo = Console.ReadLine().Split(" ").Skip(1).ToArray();
                Dough dough = new Dough(doughInfo[0], doughInfo[1], double.Parse(doughInfo[2]));
                Pizza pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "END")
                    {
                        break;
                    }

                    string[] toppingInfo = command.Split(" ").Skip(1).ToArray();
                    Topping topping = new Topping(toppingInfo[0], double.Parse(toppingInfo[1]));
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);

            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

        }
    }
}
