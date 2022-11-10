namespace Raiding.Classes
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) : base(name)
        {
            Power = 100;
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
