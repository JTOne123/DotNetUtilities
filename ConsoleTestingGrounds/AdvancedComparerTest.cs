using System.Collections.Generic;
using System.Linq;
using ConsoleTestingGrounds;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    [Category("ExtendedComparer")]
    public class AdvancedComparerTest
    {
        [SetUp]
        public void Init()
        {

        }

        [Test]
        public void CollectionEquals1()
        {
            var collection1 = new List<TestObject> { new TestObject(), new TestObject() };
            var collection2 = new List<TestObject> { new TestObject(), new TestObject() };
            Assert.IsTrue(AdvancedComparer.ExtendedComparer.CompareCollections(collection1, collection2));
        }
        [Test]
        public void CollectionEquals2()
        {
            var collection1 = new List<TestObject>();
            var collection2 = new List<TestObject>();
            for (int i = 0; i < 10000; i++)
            {
                collection1.Add(new TestObject());
                collection2.Add(new TestObject());
            }
            Assert.IsTrue(AdvancedComparer.ExtendedComparer.CompareCollections(collection1, collection2));
        }
        [Test]
        public void CollectionEquals3()
        {
            var collection1 = new List<TestObject> {};
            var collection2 = new List<TestObject> {};
            Assert.IsTrue(AdvancedComparer.ExtendedComparer.CompareCollections(collection1, collection2));
        }
        [Test]
        public void CollectionEquals4()
        {
            var collection1 = new List<TestObject> { null, null};
            var collection2 = new List<TestObject> { null, null};
            Assert.IsTrue(AdvancedComparer.ExtendedComparer.CompareCollections(collection1, collection2));
        }
        

        [Test]
        public void CollectionNotEquals1()
        {
            var collection1 = new List<TestObject> { new TestObject()};
            var collection2 = new List<TestObject> { new TestObject()};
            Assert.IsTrue(AdvancedComparer.ExtendedComparer.CompareCollections(collection1, collection2));
        }
        [Test]
        public void CollectionNotEquals2()
        {
            var collection1 = new List<TestObject> { new TestObject(), new TestObject() };
            var collection2 = new List<TestObject> { new TestObject(), new TestObject() };
            collection2[0].ListOfStrings = new List<string>(){"a","b","c"};
            Assert.IsFalse(AdvancedComparer.ExtendedComparer.CompareCollections(collection1, collection2));
        }
        [Test]
        public void CollectionNotEquals3()
        {
            var collection1 = new List<TestObject> { new TestObject(), new TestObject() };
            var collection2 = new List<TestObject> { new TestObject(), new TestObject(), new TestObject() };
            Assert.IsFalse(AdvancedComparer.ExtendedComparer.CompareCollections(collection1, collection2));
        }
        [Test]
        public void CollectionNotEquals4()
        {
            var collection1 = new List<TestObject> { new TestObject() };
            var collection2 = new List<TestObject> { new TestObject()  };
            collection2[0].Obj2.First().Number = 1;
            Assert.IsFalse(AdvancedComparer.ExtendedComparer.CompareCollections(collection1, collection2));
        }
        [Test]
        public void CollectionNotEquals5()
        {
            var collection1 = new List<TestObject> { new TestObject(), new TestObject() };
            var collection2 = new List<TestObject> { new TestObject(), new TestObject() };
            collection2[0].ListOfStrings = null;
            Assert.IsFalse(AdvancedComparer.ExtendedComparer.CompareCollections(collection1, collection2));
        }
        [Test]
        public void CollectionNotEquals6()
        {
            var collection1 = new List<TestObject> { new TestObject(), new TestObject() };
            var collection2 = new List<TestObject> { new TestObject(), new TestObject() };
            collection2[0].ListOfInts = new List<int>() {5,3,1,2,45,5,2,100};
            Assert.IsFalse(AdvancedComparer.ExtendedComparer.CompareCollections(collection1, collection2));
        }
        [Test]
        public void CollectionNotEquals7()
        {
            var collection1 = new List<TestObject> { new TestObject(), new TestObject() };
            var collection2 = new List<TestObject> { new TestObject(), new TestObject() };
            collection2[0].Obj1.Obj3.SuperTestInt = 0;
            Assert.IsFalse(AdvancedComparer.ExtendedComparer.CompareCollections(collection1, collection2));
        }

        [Test]
        public void CollectionNotEquals8()
        {
            var collection1 = new List<TestObject> { new TestObject() };
            var collection2 = new List<TestObject> { null };
            Assert.IsFalse(AdvancedComparer.ExtendedComparer.CompareCollections(collection1, collection2));
        }
    }
}
