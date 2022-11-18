using FuncProgramming;
using FuncProgramming.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FuncProgramming
{

    public static class IEnumerableExtension
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            foreach (var e in enumerable)
                if (predicate(e))
                    yield return e;
        }

        public static IEnumerable<TOut> Select<TIn, TOut>
            (this IEnumerable<TIn> enumerable, Func<TIn, TOut> selector)
        {
            foreach (var e in enumerable)
                yield return selector(e);
        }

        public static IEnumerable<R> SelectMany<R, T>(this IEnumerable<T> enumerable, Func<T, IEnumerable<R>> f)
        {
            var list = new List<R>();
            foreach (var e in enumerable)
            {
                list.AddRange(f(e));
            }
            return list;
        }

        public static List<T> ToList<T>(this IEnumerable<T> enumerable)
        {
            var list = new List<T>();
            foreach (var e in enumerable)
                list.Add(e);
            return list;
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> enumerable, Func<T, bool> filter)
        {
            foreach (var e in enumerable)
                if (filter(e))
                    return e;
            return default(T);
        }

        public static IEnumerable<T> Take<T>(this IEnumerable<T> enumerable, int count)
        {
            int counter = 0;
            if (count <= 0) yield break;

            foreach (var e in enumerable)
            {
                yield return e;
                counter++;
                if (counter == count)
                    yield break;
            }
        }
    }

    public class LinqRealizationHelper
    {
        private static readonly List<Student> students = new List<Student>()
        {
            new Student {Surname = "Popov", Group = 4410 },
            new Student {Surname = "Ivanov", Group = 4412 },
            new Student { Surname = "Petrov", Group = 4411 },
            new Student { Surname = "Potapov", Group = 4412 }
        };

        public List<string> TestWhereSelectToList()
        {
            var result = students.Where(x => x.Surname == "Popov").Select(x => x.Surname).ToList();
            return result;
        }

        public Student TestFirstOrDefault()
        {
            var result = students.FirstOrDefault(x => x.Group == 4412);
            return result;
        }

        public List<Student> TestTake()
        {
            var result = students.Take(2).ToList();
            return result;
        }

        public IEnumerable<char> TestSelectMany()
        {
            string[] words = { "ab", "", "c", "de" };
            var letters = words.SelectMany(w => w);
            return letters;
        }
    }
}
