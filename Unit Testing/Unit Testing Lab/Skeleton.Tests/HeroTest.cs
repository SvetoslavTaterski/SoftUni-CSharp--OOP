using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTest
    {
        [Test]
        public void GainXPWhenTargetIsDead()
        {
            string name = "Pesho";
            IWeapon fakeAxe = new FakeWeapon();
            ITarget fakeTarget = new FakeTarget();
            Hero hero = new Hero(name, fakeAxe);

            hero.Attack(fakeTarget);
            Assert.That(hero.Experience, Is.EqualTo(20));
        }
    }
}
