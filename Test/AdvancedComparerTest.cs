using System.Collections.Generic;
using ConsoleTestingGrounds;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class AdvancedComparerTest
    {
        [TestInitialize]
        public void Init()
        {

        }

        [TestMethod]
        public void TestMethod1()
        {
            var collection1 = new List<TestObject> { new TestObject(), new TestObject() };
            var collection2 = new List<TestObject> { new TestObject(), new TestObject() };
            Assert.IsTrue(AdvancedComparer.AdvancedComparer.CompareCollections(collection1, collection2));
        }
        [TestMethod]
        public void TestMethod2()
        {
            var collection1 = new List<TestObject> { new TestObject()};
            var collection2 = new List<TestObject> { new TestObject()};
            Assert.IsTrue(AdvancedComparer.AdvancedComparer.CompareCollections(collection1, collection2));
        }
        [TestMethod]
        public void TestMethod3()
        {
            var collection1 = new List<TestObject> { new TestObject(), new TestObject() };
            var collection2 = new List<TestObject> { new TestObject(), new TestObject(){ ListOfStrings = {"a","b","c"}} };
            Assert.IsFalse(AdvancedComparer.AdvancedComparer.CompareCollections(collection1, collection2));
        }
    }
}
