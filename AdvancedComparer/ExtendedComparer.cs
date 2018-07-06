using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AdvancedComparer
{
    public static class ExtendedComparer
    {
        public static bool Compare<T>(T object1, T object2)
        {
            if (typeof(IEnumerable<object>).IsAssignableFrom(typeof(T)) || typeof(ICollection).IsAssignableFrom(typeof(T))) 
            {
                var enumerable1 = ((IEnumerable)object1).Cast<object>().ToList();
                var enumerable2 = ((IEnumerable)object2).Cast<object>().ToList();
                return CompareCollections(enumerable1, enumerable2);
            }
            return CompareObjects(object1, object2);
        }
        private static bool CompareCollections<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            if (collection1.Count() != collection2.Count()) return false;
            for (var i = 0; i < collection1.Count(); i++)
            {
                if (!CompareObjects(collection1.ElementAt(i), collection2.ElementAt(i))) return false;
            }
            return true;
        }

        private static bool CompareObjects<T>(T item1, T item2)
        {
            if (item1 == null && item2 == null) return true;
            if (item1 == null || item2 == null) return false;

            var properties1 = GetPropertyInfo(item1);
            var properties2 = GetPropertyInfo(item2);

            var numberOfProperties = properties1.Count();

            if (numberOfProperties == 0) return item1.Equals(item2);
            for (int i = 0; i < numberOfProperties; i++)
            {
                var property1 = properties1.ElementAt(i);
                var property2 = properties2.ElementAt(i);

                var value1 = property1.GetValue(item1, null);
                var value2 = property2.GetValue(item2, null);
                if (value1 == null && value2 == null)
                {
                    return true;
                }
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
                        var enumerable1 = ((IEnumerable)value1).Cast<object>().ToList();
                        var enumerable2 = ((IEnumerable)value2).Cast<object>().ToList();
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

        private static PropertyInfo[] GetPropertyInfo<T>(T item)
        {
            return item.GetType().GetProperties();
        }
    }
}
