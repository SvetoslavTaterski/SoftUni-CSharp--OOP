namespace Raiding.Classes
{

    public class Druid : BaseHero
    {
        public Druid(string name) : base(name)
        {
            Power = 80;
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
