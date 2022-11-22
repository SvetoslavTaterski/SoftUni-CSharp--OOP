using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthWhenAttacked()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(20, 10);

            int dummyHealthBefore = dummy.Health;

            dummy.TakeAttack(axe.AttackPoints);

            int dummyHealthAfter = dummy.Health;

            Assert.AreEqual(dummyHealthBefore - axe.AttackPoints, dummyHealthAfter);
        }

        [Test]
        public void DeadDummyThrowsExceptionWhenAttacked()
        {
            Dummy dummy = new Dummy(0, 10);
            Axe axe = new Axe(10, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(axe.AttackPoints);

            }, "Dummy is dead.");
        }

        [Test]
        public void DeadDummyCanGiveExperience()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(axe.AttackPoints);

            int experienceGiven = dummy.GiveExperience();

            Assert.AreEqual(10,experienceGiven);
        }

        [Test]
        public void AliveDummyCantGiveExperience()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(100, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();

            }, "Target is not dead.");
        }
    }
}