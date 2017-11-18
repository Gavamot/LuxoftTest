﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Combinations.Data;

namespace Combinations.Extension
{
    static class CombinationExtension
    {
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
                elements.SelectMany((e, i) =>
                    elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }

        public static List<string> ToListString(this IEnumerable<Combination> elements)
        {
            return elements.Select(x => x.ToString()).ToList();
        }
    }
}