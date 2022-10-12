using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueInOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(UniqueInOrder("AAAABBBCCDAABBB"));


            Console.ReadLine();
        }

        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            T prokat = default(T);
            foreach (T item in iterable)
            {
                if (!item.Equals(prokat))
                {
                    prokat = item;
                    yield return item;
                }
            }           
        }

        public static IEnumerable<T> UniqueInOrder1<T>(IEnumerable<T> iterable)
        {
            var retList = new List<T>();
            foreach (var element in iterable) if (!element.Equals(retList.LastOrDefault())) retList.Add(element);
            return retList;
        }

        public static IEnumerable<T> UniqueInOrder2<T>(IEnumerable<T> iterable)
        {
            return iterable.Where((x, i) => i == 0 || !x.Equals(iterable.ToArray()[i - 1]));
        }
    }
}
