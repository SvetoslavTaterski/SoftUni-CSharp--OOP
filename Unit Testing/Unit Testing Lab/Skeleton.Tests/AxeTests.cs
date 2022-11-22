using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void IsWeaponLosingDurability()
        {
            Axe axe = new Axe(5, 10);
            Dummy dummy = new Dummy(10, 10);
            int axeDurabilityBefore = axe.DurabilityPoints;

            axe.Attack(dummy);

            int axeDurabilityAfter = axe.DurabilityPoints;

            Assert.AreEqual(axeDurabilityBefore - 1, axeDurabilityAfter);
        }

        [Test]
        public void AttackingWithBrokenAxeShouldThrowException()
        {
            Axe axe = new Axe(5, 0);
            Dummy dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            }, "Axe is broken.");
        }
    }
}