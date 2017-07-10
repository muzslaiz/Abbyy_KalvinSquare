using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalvinSquare_Abbyy.Helpers
{
    public static class Extensions
    {
        public static List<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}
