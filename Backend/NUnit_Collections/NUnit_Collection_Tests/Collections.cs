using Collections;

namespace NUnit_Collection_Tests
{
    public class Collections
    {
        int i = 0;


        [SetUp]
        public void StartCallMethods()
        {
            i = i + 1;

            Console.WriteLine("Test call: " + i);
        }

        [Test]
        public void Test_Collection_EmptyCollection()
        {
            var collection = new Collection<int>();

            var actual = collection.ToString();
            var expected = "[]";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collection_Add()
        {
            var collection = new Collection<int>(21, 5, 8);
            collection.Add(1);
            var actual = collection.ToString();
            var expected = "[21, 5, 8, 1]";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collection_SingleItem()
        {
            var collection = new Collection<int>(5);
            var actual = collection.ToString();
            var expected = "[5]";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collection_MultipleItems()
        {
            var collection = new Collection<int>(24, 8);
            var actual = collection.ToString();
            var expected = "[24, 8]";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            var collection = new Collection<int>(8, 6);
            var actual = collection.Count.ToString();
            var expected = "2";
            Assert.AreEqual(expected, actual);
            Assert.That(collection.Capacity, Is.GreaterThan(collection.Count));

        }

        [Test]
        public void Test_Collection_AddRange()
        {
            var collection = new Collection<int>(58, 6);
            collection.AddRange(0, 5);
            var actual = collection.ToString();
            var expected = "[58, 6, 0, 5]";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collection_InsertAt()
        {
            var collection = new Collection<int>(4, 8, 6);
            collection.InsertAt(1, 5);
            var actual = collection.ToString();
            var expected = "[4, 5, 8, 6]";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collection_Exchange()
        {
            var collection = new Collection<int>(8, 6, 3, 10);
            collection.Exchange(1, 2);
            var actual = collection.ToString();
            var expected = "[8, 3, 6, 10]";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collection_GrowCapacity()
        {
            var collection = new Collection<int>(1, 2, 3, 54, 6, 5, 8, 2, 10, 15, 65, 85, 47, 14, 19, 16);
            for (int i = 1; i <= 20; i++)
                collection.Add(i);
            var actual = collection.ToString();
            var expected = "[1, 2, 3, 54, 6, 5, 8, 2, 10, 15, 65, 85, 47, 14, 19, 16, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20]";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collection_Remove()
        {
            var collection = new Collection<string>("Apple", "Pear", "Pineapple");
            collection.RemoveAt(1);
            var actual = collection.ToString();
            var expected = "[Apple, Pineapple]";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collection_RemoveInvalidIndex()
        {
            var collection = new Collection<string>("Apple", "Pear", "Pineapple");


            Assert.That(() => { var actual = collection[-3]; }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            var collection = new Collection<int>(4, 5, 6, 8);
            var actual = collection[2].ToString();
            var expected = "6";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collection_GetByIndexString()
        {
            var collection = new Collection<string>("Green", "Blue", "White");
            var actual = collection[2].ToString();
            var expected = "White";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collections_GetByInvaldIndex()
        {
            var collection = new Collection<int>(7, 6);

            Assert.That(() => { var actual = collection[3]; }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void Test_Collections_GetByInvaldNegativeIndex()
        {
            var collection = new Collection<int>(7, 6);

            Assert.That(() => { var actual = collection[-3]; }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collections_SetByIndex()
        {
            var collection = new Collection<int>(5, 85, 100);
            collection[0] = 45;
            collection[1] = 5;
            var actual = collection.ToString();
            var expected = "[45, 5, 100]";
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Test_Collection_Clean()
        {
            var collection = new Collection<int>(45, 8, 9);
            collection.Clear();
            var actual = collection.ToString();
            var expected = "[]";
            Assert.AreEqual(expected, actual);
        }


    }
}