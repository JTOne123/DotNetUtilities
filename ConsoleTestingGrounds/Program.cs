using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedComparer;

namespace ConsoleTestingGrounds
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection1 = new List<TestObject> {new TestObject(), new TestObject()};
            var collection2 = new List<TestObject> {new TestObject(), new TestObject()};
            var broken = new List<TestObject>(collection2);
            var broken1 = new List<TestObject>(collection2);

            var result = ExtendedComparer.CompareCollections(collection1, collection2);
            Console.WriteLine(result);

            broken.First().Obj2.First().Number = 99000;
            result = ExtendedComparer.CompareCollections(collection1, broken);
            Console.WriteLine(result);

            broken.First().ListOfStrings[1] = "a";
            result = ExtendedComparer.CompareCollections(collection1, collection2);
            Console.WriteLine(result);



            Console.ReadKey();
        }
    }
}
