using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Infrastructure
{
    public static class MapTo
    {
        public static int[] AsIntegerArray(this string[] input)
        {
            var integers = input.Select(i => Convert.ToInt32(i)).ToArray();
            return integers;
        }
    }
}
