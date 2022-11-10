namespace Raiding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Classes;
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int numberOfHeroes = int.Parse(Console.ReadLine());

            while (heroes.Count != numberOfHeroes)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                if (type == "Druid")
                {
                    Druid druid = new Druid(name);
                    heroes.Add(druid);
                }
                else if(type == "Paladin")
                {
                    Paladin paladin = new Paladin(name);
                    heroes.Add(paladin);
                }
                else if(type == "Rogue")
                {
                    Rogue rogue = new Rogue(name);
                    heroes.Add(rogue);
                }
                else if(type == "Warrior")
                {
                    Warrior warrior = new Warrior(name);
                    heroes.Add(warrior);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (BaseHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            if (heroes.Sum(h => h.Power) < bossPower)
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }
        }
    }
}
