using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryApp
{
    public static class EnumerableExtensions
    {
        public static int FilterAndCount<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            var filtered = items.Where(predicate).ToList();
            return filtered.Count;
        }

        public static int FilterAndCountImpl<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return items.Count(predicate); //Убираем лишнее создание списка
        }
    }
}
