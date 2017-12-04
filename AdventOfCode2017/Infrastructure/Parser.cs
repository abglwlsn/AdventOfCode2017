using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Infrastructure
{
    public static class Parser
    {
        public static IEnumerable<string> SplitByNewLine(this string input)
        {
            var array = input.Split('\r', '\n').Select(i => i.Trim()).Where(i => !string.IsNullOrEmpty(i));
            return array.AsEnumerable();
        }

        public static IEnumerable<string> SplitBySpaceOrTab(this string input)
        {
            var array = input.Split(' ', '\t').Select(i => i.Trim()).Where(i => !string.IsNullOrEmpty(i));
            return array.AsEnumerable();
        }
        
        public static bool LooselyMatchesElements(this char[] active, char[] comparison)
        {
            if (active.Count() != comparison.Count())
                return false;

            for (var i = 0; i < active.Count(); i++)
            {
                if (!comparison.Contains(active[i]))
                    return false;
            }
            return true;
        }
    }
}
