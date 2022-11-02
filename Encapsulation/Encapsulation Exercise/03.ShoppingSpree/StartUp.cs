using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] products = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<Person> listOfPersons = new List<Person>();
            List<Product> listOfProducts = new List<Product>();

            try
            {
                foreach (string person in people)
                {
                    string[] personInfo = person.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string name = personInfo[0];
                    decimal money = decimal.Parse(personInfo[1]);

                    Person newPerson = new Person(name, money);
                    listOfPersons.Add(newPerson);
                }


                foreach (string product in products)
                {
                    string[] productInfo = product.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string name = productInfo[0];
                    decimal cost = decimal.Parse(productInfo[1]);

                    Product newProduct = new Product(name, cost);
                    listOfProducts.Add(newProduct);
                }
                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "END")
                    {
                        break;
                    }

                    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string personName = tokens[0];
                    string productName = tokens[1];

                    Person customer = listOfPersons.Find(p => p.Name == personName);
                    Product productToBuy = listOfProducts.Find(p => p.Name == productName);

                    if (customer.Money < productToBuy.Cost)
                    {
                        Console.WriteLine($"{customer.Name} can't afford {productToBuy.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{customer.Name} bought {productToBuy.Name}");
                        customer.BagOfProducts.Add(productToBuy);
                        customer.Money -= productToBuy.Cost;
                    }
                }

                foreach (Person person in listOfPersons)
                {
                    if (person.BagOfProducts.Any())
                    {
                        Console.WriteLine(person.Name + " - " + String.Join(", ", person.BagOfProducts));
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                }

            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }

        }
    }
}
