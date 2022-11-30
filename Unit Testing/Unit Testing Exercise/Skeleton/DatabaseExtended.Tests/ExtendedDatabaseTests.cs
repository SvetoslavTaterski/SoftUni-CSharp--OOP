namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void DatabaseShouldInitializeProperly()
        {
            Person[] people = new Person[2];
            people[0] = new Person(1234, "kilmi29");
            people[1] = new Person(4321, "axeltoo");

            Database db = new Database(people);
            int actualCount = people.Length;
            int expectedCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenPersonWithSameIdIsAdded()
        {
            Person[] people = new Person[2];
            people[0] = new Person(1234, "kilmi29");
            people[1] = new Person(4321, "kilers29");

            Database db = new Database(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(1234, "axeltoo"));

            }, "There is already user with this Id!");
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenPersonWithSameUsernameIsAdded()
        {
            Person[] people = new Person[2];
            people[0] = new Person(1234, "kilmi29");
            people[1] = new Person(3421, "kilers29");

            Database db = new Database(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(4321, "kilmi29"));

            }, "There is already user with this username!");
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenAddingInAFullCollection()
        {
            Person[] people = new Person[16];
            people[0] = new Person(1234, "kilmi29");
            people[1] = new Person(12345, "k");
            people[2] = new Person(123456, "ki");
            people[3] = new Person(123478, "kil");
            people[4] = new Person(12349, "kilm");
            people[5] = new Person(123432, "kilmi");
            people[6] = new Person(1234009, "kilmi2");
            people[7] = new Person(1234876, "kak");
            people[8] = new Person(1234235, "kbo");
            people[9] = new Person(1234654, "rosa");
            people[10] = new Person(1234111, "dosa");
            people[11] = new Person(123422, "sosa");
            people[12] = new Person(1234333, "mosa");
            people[13] = new Person(1234444, "losa");
            people[14] = new Person(1234555, "qsa");
            people[15] = new Person(1234666, "dasa");

            Database db = new Database(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(0000, "XxVodxX"));

            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void RemoveMethodShouldRemoveElementFromDatabase()
        {
            Person[] people = new Person[2];
            people[0] = new Person(1234, "kilmi29");
            people[1] = new Person(4321, "kilers29");

            Database db = new Database(people);
            db.Remove();

            Assert.AreEqual(people.Length -1 , db.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenRemovingFromEmptyDatabase()
        {
            Person[] people = new Person[0];
            Database db = new Database(people);
            
            Assert.Throws<InvalidOperationException>( () => 
            {

                db.Remove();

            });
            
        }

        [Test]
        public void AddByRangeShouldThrowExceptionWhenAddingElementsGreaterThan16()
        {
            Person[] people = new Person[17];
            people[0] = new Person(1234, "kilmi29");
            people[1] = new Person(12345, "k");
            people[2] = new Person(123456, "ki");
            people[3] = new Person(123478, "kil");
            people[4] = new Person(12349, "kilm");
            people[5] = new Person(123432, "kilmi");
            people[6] = new Person(1234009, "kilmi2");
            people[7] = new Person(1234876, "kak");
            people[8] = new Person(1234235, "kbo");
            people[9] = new Person(1234654, "rosa");
            people[10] = new Person(1234111, "dosa");
            people[11] = new Person(123422, "sosa");
            people[12] = new Person(1234333, "mosa");
            people[13] = new Person(1234444, "losa");
            people[14] = new Person(1234555, "qsa");
            people[15] = new Person(1234666, "dasa");
            people[16] = new Person(234156, "ssa");

            Assert.Throws<ArgumentException>(() =>
            {
                Database db = new Database(people);
            }, "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void FindByUsernameShouldWorkProperly()
        {
            Person[] people = new Person[2];
            people[0] = new Person(1, "kilmi29");
            people[1] = new Person(2, "Fox");

            Database db = new Database(people);

            Person expectedPerson = people[1];
            Person actualPerson = db.FindByUsername("Fox");

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWhenThereIsNoSuchUser()
        {
            Person[] people = new Person[2];
            people[0] = new Person(1, "kilmi29");
            people[1] = new Person(2, "Fox");

            Database db = new Database(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername("svetli");

            }, "No user is present by this username!");
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWhenGivenUsernameIsNull()
        {
            Person[] people = new Person[2];
            people[0] = new Person(1, "kilmi29");
            people[1] = new Person(2, "Fox");

            Database db = new Database(people);

            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername(null);
            });
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWhenGivenUsernameIsEmpty()
        {
            Person[] people = new Person[2];
            people[0] = new Person(1, "kilmi29");
            people[1] = new Person(2, "Fox");

            Database db = new Database(people);

            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername(string.Empty);
            });
        }

        [Test]
        public void FindByIdShouldWorkProperly()
        {
            Person[] people = new Person[2];
            people[0] = new Person(1, "kilmi29");
            people[1] = new Person(2, "Fox");

            Database db = new Database(people);

            Person expectedPerson = people[1];
            Person actualPerson = db.FindById(2);

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        public void FindByIdShouldThrowExceptionWhenThereIsNoSuchPersonWithThisId()
        {
            Person[] people = new Person[2];
            people[0] = new Person(1, "kilmi29");
            people[1] = new Person(2, "Fox");

            Database db = new Database(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindById(8);
            }, "No user is present by this ID!");
        }

        [Test]
        public void FindByIdShouldThrowExceptionWhenTheIdIsNegativeNumber()
        {
            Person[] people = new Person[2];
            people[0] = new Person(1, "kilmi29");
            people[1] = new Person(2, "Fox");

            Database db = new Database(people);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                db.FindById(-9);
            }, "Id should be a positive number!");
        }
    }
}