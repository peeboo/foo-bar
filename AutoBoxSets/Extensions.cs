// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="Extensions.cs" company="">
//   
// </copyright>
// <summary>
//   The extensions.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------

namespace AutoBoxSets
{

    using System.Collections.Generic;

    using JetBrains.Annotations;


    /// <summary>The extensions.</summary>
    public static class Extensions
    {
        /// <summary>The get value or default.</summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <typeparam name="T">T</typeparam>
        /// <typeparam name="TU">TU</typeparam>
        /// <returns>The <see cref="TU"/>.</returns>
        public static TU GetValueOrDefault<T, TU>([NotNull] this Dictionary<T, TU> dictionary, [NotNull] T key, TU defaultValue)
        {
            TU u;
            if (!dictionary.TryGetValue(key, out u))
            {
                u = defaultValue;
            }

            return u;
        }
    }

}
