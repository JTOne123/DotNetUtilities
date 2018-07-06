# AdvancedComparer
This NuGet package will compare 2 complex objects or 2 collections of objects. Using reflection, the comparer checks if each and every object is identical in both collections and returns true if so. Your class can contain all kinds of IEnumerables, custom objects... anything.

# How to use it

Use 2 objects of the same type
```
var collection1 = new List<TestObject> {new TestObject(), new TestObject()};
var collection2 = new List<TestObject> {new TestObject(), new TestObject()};
var result = ExtendedComparer.Compare(collection1, collection2);
```

Result will be true if everything matches.
Result will be false if something is different.

**Use at your own risk, it passed my tests and use cases but I haven't checked all possible inputs.**

# Upcoming
Code works, but it is pretty disgusting to look at. I'll spend some time cleaning it soon.
