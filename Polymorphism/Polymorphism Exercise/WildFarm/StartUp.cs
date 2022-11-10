namespace WildFarm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AnimalClasses;
    using FoodClasses;
    using Classes;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            HashSet<Food> food = new HashSet<Food>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] animalInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string[] foodInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string foodType = foodInfo[0];
                int quantity = int.Parse(foodInfo[1]);

                if (foodType == "Fruit")
                {
                    Fruit fruit = new Fruit(quantity);
                    food.Add(fruit);
                }
                else if (foodType == "Meat")
                {
                    Meat meat = new Meat(quantity);
                    food.Add(meat);
                }
                else if (foodType == "Seeds")
                {
                    Seeds seeds = new Seeds(quantity);
                    food.Add(seeds);
                }
                else if(foodType == "Vegetable")
                {
                    Vegetable vegetable = new Vegetable(quantity);
                    food.Add(vegetable);
                }

                string animalType = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                if (animalType == "Owl")
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    Owl owl = new Owl(name, weight, wingSize);
                    Console.WriteLine(owl.ProduceSound());

                    if (food.First().GetType().Name != "Meat")
                    {
                        Console.WriteLine($"{owl.GetType().Name} does not eat {food.First().GetType().Name}!");
                    }
                    else
                    {
                        owl.FoodEaten += food.First().Quantity;
                        owl.Weight += food.First().Quantity * 0.25;
                        food.Remove(food.First());
                    }

                    animals.Add(owl);
                }
                else if (animalType == "Hen")
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    Hen hen = new Hen(name, weight, wingSize);
                    Console.WriteLine(hen.ProduceSound());

                    hen.FoodEaten += food.First().Quantity;
                    hen.Weight += food.First().Quantity * 0.35;
                    food.Remove(food.First());

                    animals.Add(hen);
                }
                else if (animalType == "Mouse")
                {
                    string livingRegion = animalInfo[3];
                    Mouse mouse = new Mouse(name, weight, livingRegion);
                    Console.WriteLine(mouse.ProduceSound());

                    if (food.First().GetType().Name != "Fruit" && food.First().GetType().Name != "Vegetable")
                    {
                        Console.WriteLine($"{mouse.GetType().Name} does not eat {food.First().GetType().Name}!");
                    }
                    else
                    {
                        mouse.FoodEaten += food.First().Quantity;
                        mouse.Weight += food.First().Quantity * 0.10;
                        food.Remove(food.First());
                    }

                    animals.Add(mouse);
                }
                else if (animalType == "Dog")
                {
                    string livingRegion = animalInfo[3];
                    Dog dog = new Dog(name, weight, livingRegion);
                    Console.WriteLine(dog.ProduceSound());

                    if (food.First().GetType().Name != "Meat")
                    {
                        Console.WriteLine($"{dog.GetType().Name} does not eat {food.First().GetType().Name}!");
                    }
                    else
                    {
                        dog.FoodEaten += food.First().Quantity;
                        dog.Weight += food.First().Quantity * 0.40;
                        food.Remove(food.First());
                    }

                    animals.Add(dog);
                }
                else if (animalType == "Cat")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    Cat cat = new Cat(name, weight, livingRegion, breed);
                    Console.WriteLine(cat.ProduceSound());

                    if (food.First().GetType().Name != "Meat" && food.First().GetType().Name != "Vegetable")
                    {
                        Console.WriteLine($"{cat.GetType().Name} does not eat {food.First().GetType().Name}!");
                    }
                    else
                    {
                        cat.FoodEaten += food.First().Quantity;
                        cat.Weight += food.First().Quantity * 0.30;
                        food.Remove(food.First());
                    }

                    animals.Add(cat);
                }
                else if (animalType == "Tiger")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    Tiger tiger = new Tiger(name, weight, livingRegion, breed);
                    Console.WriteLine(tiger.ProduceSound());

                    if (food.First().GetType().Name != "Meat")
                    {
                        Console.WriteLine($"{tiger.GetType().Name} does not eat {food.First().GetType().Name}!");
                    }
                    else
                    {
                        tiger.FoodEaten += food.First().Quantity;
                        tiger.Weight += food.First().Quantity * 1.0;
                        food.Remove(food.First());
                    }

                    animals.Add(tiger);
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
