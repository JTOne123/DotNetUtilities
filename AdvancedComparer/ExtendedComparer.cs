using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedComparer
{
    public static class ExtendedComparer
    {
        public static bool CompareCollections<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            
            if (collection1.Count() != collection2.Count()) return false;

            for (var i = 0; i < collection1.Count(); i++)
            {
                var itemsAreEqual = CompareObjects(collection1.ElementAt(i), collection2.ElementAt(i));
                if (!itemsAreEqual) return false;
            }
            return true;
        }

        public static bool CompareObjects<T>(T item1, T item2)
        {
            if (item1 == null && item2 == null) return true;
            if (item1 == null || item2 == null) return false;

            var properties1 = item1.GetType().GetProperties();
            var properties2 = item1.GetType().GetProperties();

            var numberOfProperties = properties1.Count();
            for (int i = 0; i < numberOfProperties; i++)
            {
                var property1 = properties1.ElementAt(i);
                var property2 = properties2.ElementAt(i);

                var value1 = property1.GetValue(item1, null);
                var value2 = property2.GetValue(item2, null);

                if (value1 == null || value2 == null) return false;

                var baset = property1.PropertyType.BaseType;

                if (property1.PropertyType.BaseType == typeof(Object) &&
                    !property1.PropertyType.FullName.Contains("System"))
                {
                    if (!CompareObjects(value1, value2)) return false;
                }
                else if (property1.PropertyType.FullName.Contains("System.Collections.Generic"))
                {
                    var list1 = new List<object>();
                    var list2 = new List<object>();
                    try
                    {
                        var enumerable1 = (IEnumerable<object>) value1;
                        var enumerable2 = (IEnumerable<object>) value2;
                        list1 = new List<object>(enumerable1);
                        list2 = new List<object>(enumerable2);
                    }
                    catch
                    {
                        IList enumerable1 = (IList) value1;
                        IList enumerable2 = (IList) value2;
                        if (enumerable1.Count != enumerable2.Count) return false;
                        for (int j = 0; j < enumerable1.Count; j++)
                        {
                            if (!enumerable1[j].Equals(enumerable2[j])) return false;
                        }
                        break;
                    }
                    for (int j = 0; j < list1.Count; j++)
                    {
                        if (list1.ElementAt(j).GetType().BaseType == typeof(Object) &&
                            !list1.ElementAt(j).GetType().FullName.Contains("System"))
                        {
                            if (!CompareCollections(list1, list2)) return false;
                            break;
                        }

                        if (!list1.ElementAt(j).Equals(list2.ElementAt(j)))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if (!value1.Equals(value2))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
