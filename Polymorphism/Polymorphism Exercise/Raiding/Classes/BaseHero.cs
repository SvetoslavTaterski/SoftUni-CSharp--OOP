namespace Raiding.Classes
{

    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; protected set; }

        public int Power { get; protected set; }

        public virtual string CastAbility()
        {
            return null;
        }
    }
}
