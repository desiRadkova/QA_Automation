
using System.Collections.ObjectModel;

namespace TownsTests
{
    public class TownsCollectionTests
    {

        [Test]
        public void Test_EmptyConstructorCollection()
        {
            var collection = new TownsCollection();
            var expected = "";
            var actual = collection.ToString();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_AddOneCityInCollection()
        {
            var collection = new TownsCollection();
            //collection.Add("Smolyan");
            Assert.True(collection.Add("Smolyan"));
        }
        [Test]
        public void Test_AddOneCityInCollectionFalse()
        {
            var collection = new TownsCollection();
            collection.Add("Smolyan");
            Assert.False(collection.Add("Smolyan"));
        }

        [Test]
        public void Test_AddCityInCollection()
        {
            var collection = new TownsCollection();
            collection.Towns.Add("Sofia");
            collection.Towns.Add("Varna");
            var actual = collection.ToString();
            var expected = "Sofia, Varna";
            Assert.AreEqual(expected, actual);

        }
        [Test]
        public void Test_AddCityInCollectionDouble()
        {
            var collection = new TownsCollection("Sofia");
            collection.Add("Sofia");
            collection.Add("Sofia");
            var actual = collection.ToString();
            var expected = "Sofia";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_Add_EmptyTown()
        {
            var collection = new TownsCollection("Sofia");
            collection.Add("");
            Assert.That(collection.Towns.Count, Is.EqualTo(1));
            Assert.That(collection.ToString(), Is.EqualTo("Sofia"));
        }
        [Test]
        public void Test_RemoveItemByIntex()
        {
            var collection = new TownsCollection("Plovdiv, Ruse, Trun, Vratsa");
            collection.RemoveAt(1);
            var actual = collection.ToString();
            var expected = "Plovdiv, Trun, Vratsa";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_RemoveInvalidIndex()
        {
            var collection = new TownsCollection("Plovdiv, Ruse, Trun, Vratsa");


            Assert.That(() => { collection.RemoveAt(5); }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void Test_ReverseItemsInCollection()
        {
            var collection = new TownsCollection("Plovdiv, Ruse, Tran, Vratsa");
            collection.Reverse();
            var actual = collection.ToString();
            var expected = "Vratsa, Tran, Ruse, Plovdiv";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_ReverseItemsInCollectionInvalid()
        {
            var collection = new TownsCollection();

            Assert.That(() => { collection.Reverse(); }, Throws.InstanceOf<InvalidOperationException>());
        }
        //[Test]
        //public void Test_ReverseItemsInCollectionInvalidNull()
        //{
        //    var collection = new TownsCollection();
        //    collection.RemoveAt(0);

        //    Assert.That(() => { collection.Reverse(); }, Throws.InstanceOf<ArgumentNullException>());
        //}

        [Test]
        public void Test_Reverse_ZeroTown()
        {
            var townCollection = new TownsCollection();
            townCollection.Towns = null;
            Assert.That(() => townCollection.Reverse(), Throws.InstanceOf<ArgumentNullException>());
        }

    }
}
