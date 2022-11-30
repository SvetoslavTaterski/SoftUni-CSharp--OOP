namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void ArenaConstructorShouldWorkProperly()
        {
            Arena arena = new Arena();

            Assert.AreEqual(arena.Warriors.Count, 0);
        }

        [Test]
        public void ArenaCountShouldWorkProperly()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Kratos", 100, 100));
            arena.Enroll(new Warrior("Zeus", 90, 100));

            Assert.AreEqual(arena.Count, 2);
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionWhenAddingExistingWarrior()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Kratos", 100, 100));

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(new Warrior("Kratos", 200, 200));
            });
        }

        [Test]
        public void EnrollMethodShouldWorkProperly()
        {
            var arena = new Arena();
            arena.Enroll(new Warrior("Kratos", 100, 100));

            Assert.AreEqual(arena.Count, 1);
        }

        [Test]
        public void FightMethodShouldWorkProperly()
        {
            var arena = new Arena();
            arena.Enroll(new Warrior("Kratos",100,100));
            arena.Enroll(new Warrior("Zeus",50,50));

            arena.Fight("Kratos", "Zeus");

            Assert.AreEqual(arena.Warriors.FirstOrDefault(w => w.Name == "Zeus").HP , 0);
        }

        [Test]
        public void FightMethodShouldThrowExceptionIfThereIsNoFightersWithSuchName()
        {
            var arena = new Arena();
            arena.Enroll(new Warrior("Kratos", 100, 100));
            arena.Enroll(new Warrior("Zeus", 50, 50));

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Kratos", "Hades");
            });
        }
    }
}
