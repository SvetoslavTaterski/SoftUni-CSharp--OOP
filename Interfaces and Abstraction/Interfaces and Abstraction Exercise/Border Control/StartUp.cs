namespace Border_Control
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Classes;
    using Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<IBuyer> buyers = new HashSet<IBuyer>();

            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (personInfo.Length == 4)
                {
                    string name = personInfo[0];
                    int age = int.Parse(personInfo[1]);
                    string id = personInfo[2];
                    string birthdate = personInfo[3];

                    Citizen newCitizen = new Citizen(name, age, id, birthdate);
                    buyers.Add(newCitizen);
                }
                else
                {
                    string name = personInfo[0];
                    int age = int.Parse(personInfo[1]);
                    string group = personInfo[2];

                    Rebel newRebel = new Rebel(name, age, group);
                    buyers.Add(newRebel);
                }
            }

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "End")
                {
                    break;
                }


                if (buyers.Any(b => b.Name == name))
                {
                    IBuyer currentBuyer = buyers.First(b => b.Name == name);
                    currentBuyer.BuyFood();
                }
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
