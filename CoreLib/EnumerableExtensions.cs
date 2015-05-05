using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsubaki.CoreLib
{
    public static class EnumerableExtensions
    {
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            foreach (var item in source) { action(item); }
        }

        public static IEnumerable<TSource> Merge<TSource>(this IEnumerable<TSource> source1, IEnumerable<TSource> source2)
        {
            var result = new List<TSource>(source1);
            result.AddRange(source2);
            return result;
        }

        public static IEnumerable<TSource> Top<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, int count)
        {
            return source.OrderByDescending(keySelector).Take(count);
        }
    }
}
