using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestingGrounds
{
    public class TestObject
    {
        public string Name { get; set; }
        public SubObject1 Obj1 { get; set; }
        public IList<string> ListOfStrings { get; set; }
        public IEnumerable<SubObject2> Obj2 { get; set; }
        public List<int> ListOfInts { get; set; }

        public TestObject()
        {
            Name = "Eduard";
            Obj1 = new SubObject1();
            ListOfStrings = new List<string>(){ "ONE", "TWO", "THREE"};
            Obj2 = new List<SubObject2>()
            {
                new SubObject2(), new SubObject2()
            };
            ListOfInts = new List<int>() { 1, 2, 3 };
        }
    }

    public class SubObject1
    {
        public string Text { get; set; }
        public SubObject3 Obj3 { get; set; }

        public SubObject1()
        {
            Text = "RANDOM TEXT";
            Obj3 = new SubObject3();
        }
    }
    public class SubObject2
    {
        public int Number { get; set; }

        public SubObject2()
        {
            Number = 66;
        }
    }
    public class SubObject3
    {
        public int Salary { get; set; }
        public int SuperTestInt { get; set; }

        public SubObject3()
        {
            Salary = 10000;
            SuperTestInt = -40000;
        }
    }
}
