namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8)]
        [TestCase(1)]
        public void ArrayCapacityMustBe16Integers(params int[] integers)
        {
            Database db = new Database(integers);

            int expectedCount = integers.Length;
            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20)]
        public void ArrayCapacityOver16IntegersShoudThrowException(params int[] integers)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database db = new Database(integers);

            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(1, 2, 3, 4, 5)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8)]
        public void AddMethodShouldAddInteger(params int[] integers)
        {
            Database db = new Database(integers);

            int dbCountBefore = db.Count;

            db.Add(1);

            int dbCountAfter = db.Count;

            Assert.AreEqual(dbCountBefore + 1, dbCountAfter);
        }

        [TestCase(1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16)]
        public void AddMethodShouldThrowExceptionWhenAddingInFullDatabase(params int[] integers)
        {
            Database db = new Database(integers);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(1);

            },"There is no space in the Database!");
        }

        [TestCase(1,2,3,4,5,6)]
        [TestCase(1,2,3,4,5,6,7,8)]
        public void RemoveMethodShouldRemoveInteger(params int[] integers)
        {
            Database db = new Database(integers);

            int dbCountBefore = db.Count;

            db.Remove();

            int dbCountAfter = db.Count;

            Assert.AreEqual(dbCountAfter+ 1, dbCountBefore);
        }

        [TestCase(new int[0])]
        public void RemoveMethodShouldThrowExceptionWhenRemovingFromEmptyDatabase(params int[] integers)
        {
            Database db = new Database(integers);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();

            }, "The collection is empty!");

        }

        [TestCase(1,2,3,4,5,6)]
        [TestCase(1,2,3,4,5,6,7,8)]
        public void FetchMethodShouldReturnElementsAsAnArray(params int[] integers)
        {
            Database db = new Database(integers);

            int actualDbCount = db.Count;

            int[] fetchDb = db.Fetch();
            int fetchedDbCount = fetchDb.Length;

            Assert.AreEqual(actualDbCount, fetchedDbCount);

        }

        [TestCase(1,2,3,4,5,6)]
        [TestCase(1,2,3,4,5,6,7,8,9,10)]
        public void CountShouldWorkProperly(params int[] integers)
        {
           Database db = new Database(integers);

            int expectedCount = integers.Length;
            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(1,2,3,4,5,6)]
        [TestCase(1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16)]
        public void ConstructorShouldAddElementsIntoDataField(params int[] integers)
        {
            Database db = new Database(integers);

            int[] expectedData = integers;
            int[] actualData = db.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }
}
