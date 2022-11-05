namespace Border_Control.Classes
{
    using Border_Control.Interfaces;

    public class Rebel : IPerson,IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            Group = group;
            Age = age;
            Name = name;
        }

        public string Group { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
