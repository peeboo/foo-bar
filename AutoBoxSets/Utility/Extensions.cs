// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="Extensions.cs" company="">
// </copyright>
// <summary>
//   The extensions.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------
namespace AutoBoxSets.Utility
{

    using System;
    using System.Collections.Generic;

    using JetBrains.Annotations;


    /// <summary>The extensions.</summary>
    public static class Extensions
    {
        /// <summary>The distinct by.</summary>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <typeparam name="TSource">TSource</typeparam>
        /// <typeparam name="TKey">TKey</typeparam>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            [NotNull] Func<TSource, TKey> keySelector)
        {
            return source.DistinctBy(keySelector, null);
        }


        /// <summary>The distinct by.</summary>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="comparer">The comparer.</param>
        /// <typeparam name="TSource">TSource</typeparam>
        /// <typeparam name="TKey">TKey</typeparam>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null" />.</exception>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(
            [NotNull] this IEnumerable<TSource> source, 
            [NotNull] Func<TSource, TKey> keySelector, 
            IEqualityComparer<TKey> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }

            return DistinctByImpl(source, keySelector, comparer);
        }


        /// <summary>The distinct by impl.</summary>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="comparer">The comparer.</param>
        /// <typeparam name="TSource">TSource</typeparam>
        /// <typeparam name="TKey">TKey</typeparam>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        private static IEnumerable<TSource> DistinctByImpl<TSource, TKey>(
            [NotNull] IEnumerable<TSource> source, 
            [CanBeNull] Func<TSource, TKey> keySelector, 
            IEqualityComparer<TKey> comparer)
        {
            var knownKeys = new HashSet<TKey>(comparer);

            foreach (var source1 in source)
            {
                if ((keySelector != null) && knownKeys.Add(keySelector(source1)))
                {
                    yield return source1;
                }
            }
        }
    }

}
