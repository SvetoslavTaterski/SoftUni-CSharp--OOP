namespace Border_Control.Classes
{

    using Interfaces;

    public class Pet : IBirthable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            BirthDate = birthdate;
        }

        public string Name { get; set; }
        public string BirthDate { get; set; }
    }
}
