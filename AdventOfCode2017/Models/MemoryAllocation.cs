using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Infrastructure;

namespace AdventOfCode2017.Models
{
    public class MemoryAllocation
    {
        public MemoryAllocation(string input)
        {
            MemoryBanks = input.SplitBySpaceOrTab().Select(i => Convert.ToInt32(i)).ToArray();
            MemoryBankHistory = new List<int[]>();
        }

        public int[] MemoryBanks { get; set; }
        public List<int[]> MemoryBankHistory { get; set; }
     

        public int DetermineIndexOfHighestLoad()
        {
            var maxValue = MemoryBanks.Max();
            return Array.IndexOf(MemoryBanks, maxValue);
        }

        public void DistributeMemory(int targetIndex)
        {
            MemoryBankHistory.Add(MemoryBanks);

            var redistributed = MemoryBanks.ToArray();
            var blocks = redistributed[targetIndex];
            redistributed[targetIndex++] = 0;

            while (blocks > 0)
            {
                if (targetIndex >= redistributed.Length)
                {
                    targetIndex = 0;
                }

                redistributed[targetIndex++]++;
                blocks--;
            }
            
            //var fullCycles = blocks / MemoryBanks.Length;
            //var additionalSteps = blocks % MemoryBanks.Length;

            //var redistributed = MemoryBanks.Select(b => b + fullCycles).ToArray();
            //redistributed[targetIndex] = fullCycles;

            //for (var i = 1; i <= additionalSteps; i++)
            //{
            //    if (targetIndex + i >= MemoryBanks.Length)
            //    {
            //        var adjustedIndex = targetIndex - MemoryBanks.Length + i;
            //        redistributed[adjustedIndex]++;
            //    }
            //    else
            //    {
            //        redistributed[targetIndex + i]++;
            //    }
            //}

            MemoryBanks = redistributed;
        }

        public int GetTotalCyclesBeforeLoopRestart()
        {
            while (!MemoryBankHistory.Any(h => h.SequenceEqual(MemoryBanks)))
            {
                var highest = DetermineIndexOfHighestLoad();
                DistributeMemory(highest);
            }

            return MemoryBankHistory.Count();
        }

        public int GetCyclesForCompleteLoop()
        {
            while (!MemoryBankHistory.Any(h => h.SequenceEqual(MemoryBanks)))
            {
                var highest = DetermineIndexOfHighestLoad();
                DistributeMemory(highest);
            }

            var initial = MemoryBankHistory.IndexOf(MemoryBankHistory.FirstOrDefault(h => h.SequenceEqual(MemoryBanks)));

            return MemoryBankHistory.Count - initial;
        }
    }
}
