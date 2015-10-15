using System;
using System.Collections.Generic;
using System.Linq;

namespace Tsubaki.CoreLib.Extensions
{
    /// <summary>
    /// IEnumerableインターフェイスの拡張クラス。
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// System.Collections.Generic.IEnumerable<T> の各要素に対して、指定された処理を実行します。
        /// </summary>
        /// <typeparam name="TSource">リスト内の要素の型。</typeparam>
        /// <param name="source">実行対象の System.Collections.Generic.IEnumerable<T>。</param>
        /// <param name="action">System.Collections.Generic.IEnumerable<T> の各要素に対して実行する System.Action<T> デリゲート。</param>
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            foreach (var item in source) action(item);
        }

        public static IEnumerable<TSource> Merge<TSource>(this IEnumerable<TSource> source1, IEnumerable<TSource> source2)
        {
            var result = new List<TSource>(source1);
            result.AddRange(source2);
            return result;
        }

        /// <summary>
        /// シーケンスの要素をキーに従って降順に並べ替え、先頭から指定した件数の要素を返します。
        /// </summary>
        /// <typeparam name="TSource">source の要素の型。</typeparam>
        /// <typeparam name="TKey">keySelector によって返されるキーの型。</typeparam>
        /// <param name="source">順序付ける値のシーケンス。</param>
        /// <param name="count">シーケンスの先頭から取得する件数。</param>
        /// <param name="keySelectors">要素からキーを抽出する関数。</param>
        /// <returns>並べ替えたシーケンスの先頭から指定した件数の要素。</returns>
        public static IEnumerable<TSource> Top<TSource, TKey>(this IEnumerable<TSource> source, int count, params Func<TSource, TKey>[] keySelectors)
        {
            IOrderedEnumerable<TSource> orderedSource = null;
            for (var i = 0; i < keySelectors.Length; i++)
            {
                if (i == 0)
                {
                    orderedSource = source.OrderByDescending(keySelectors[i]);
                }
                else if (orderedSource != null)
                {
                    orderedSource = orderedSource.ThenByDescending(keySelectors[i]);
                }
            }
            return orderedSource == null ? source.Take(count) : orderedSource.Take(count);
        }
    }
}
