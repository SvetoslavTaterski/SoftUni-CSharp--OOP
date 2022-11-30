namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            Warrior warrior = new Warrior("Kratos", 100, 100);
            string expectedWarriorName = "Kratos";
            int expectedWarriorDamage = 100;
            int expectedWarriorHealth = 100;

            Assert.AreEqual(expectedWarriorName, warrior.Name);
            Assert.AreEqual(expectedWarriorDamage, warrior.Damage);
            Assert.AreEqual(expectedWarriorHealth, warrior.HP);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void NamePropertyShouldThrowExceptionIfNameIsNullEmptyOrWhitespace(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 100, 100);
            });
        }

        [TestCase(0)]
        [TestCase(-69)]
        public void DamagePropertyShouldThrowExceptionIfItIsZeroOrNegative(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Kratos", damage, 100);
            });
        }

        [Test]
        public void HealthPropertyShouldThrowExceptionIfItIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Kratos", 100, -69);
            });
        }

        [Test]
        public void AttackMethodShouldWorkProperly()
        {
            Warrior kratos = new Warrior("Kratos", 100, 100);
            Warrior zeus = new Warrior("Zeus", 90, 200);
            int zeusHealthBeforeAttack = zeus.HP;

            kratos.Attack(zeus);

            int zeusHealthAfterAttack = zeus.HP;

            Assert.AreEqual(zeusHealthBeforeAttack - kratos.Damage, zeusHealthAfterAttack);
        }

        [TestCase(29)]
        [TestCase(30)]
        public void AttackMethodShouldThrowExceptionIfWarriorHealthIsBelowOr30(int health)
        {
            Warrior warrior = new Warrior("Kratos", 100, health);
            Warrior otherWarrior = new Warrior("Zeus", 90, 100);

            Assert.Throws<InvalidOperationException>(() => 
            { 
                warrior.Attack(otherWarrior);
            });
        }

        [TestCase(29)]
        [TestCase(30)]
        public void AttackMethodShouldThrowExceptionIfWarriorAttacksWarriorWhichHealthIsBelowOr30(int health)
        {
            Warrior warrior = new Warrior("Kratos", 100, health);
            Warrior otherWarrior = new Warrior("Zeus", 90, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                otherWarrior.Attack(warrior);
            });
        }

        [Test]
        public void AttackMethodShouldThrowExceptionIfWarriorHealthIsSmallerThenTheAttackOfTheOtherWarrior()
        {
            Warrior warrior = new Warrior("Kratos", 100, 60);
            Warrior otherWarrior = new Warrior("Zeus", 90, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(otherWarrior);
            });
        }

        [Test]
        public void IfWarriorDamageIsGreaterThenOtherWarriorHealthAndAttackHimItShouldReturnZero()
        {
            Warrior kratos = new Warrior("Kratos", 100, 100);
            Warrior zeus = new Warrior("Zeus", 50, 50);
            kratos.Attack(zeus);

            Assert.AreEqual(0, zeus.HP);
        }
    }
}