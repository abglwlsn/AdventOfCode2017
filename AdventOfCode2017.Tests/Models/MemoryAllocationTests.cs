using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Models;
using Xunit;

namespace AdventOfCode2017.Tests.Models
{
    public class MemoryAllocationTests
    {
        private string input = "1   2   7   0" ;
        private string inputTwo = "1  2   7   7   0" ;

        [Fact]
        public void ConstructorShould_PopulateProperties()
        {
            var allocation = new MemoryAllocation(input);

            Assert.NotNull(allocation.MemoryBanks);
            Assert.Equal(4, allocation.MemoryBanks.Length);
            Assert.NotNull(allocation.MemoryBankHistory);
        }

        [Fact]
        public void DetermineIndexOfHighestLoadShould_ReturnBankWithMostBlocks()
        {
            var allocation = new MemoryAllocation(input);
            var highest = allocation.DetermineIndexOfHighestLoad();

            Assert.Equal(2, highest);

            allocation = new MemoryAllocation(inputTwo);
            highest = allocation.DetermineIndexOfHighestLoad();

            Assert.Equal(2, highest);
        }

        [Fact]
        public void DistributeMemoryShould_DistributeMemoryToOtherBanksAndSaveHistory()
        {
            var allocation = new MemoryAllocation(input);
            var original = allocation.MemoryBanks;

            var highest = allocation.DetermineIndexOfHighestLoad();
            var originalValue = allocation.MemoryBanks[highest];
            allocation.DistributeMemory(highest);

            Assert.Single(allocation.MemoryBankHistory);
            Assert.True(originalValue > allocation.MemoryBanks[highest]);
            for (var i = 0; i < allocation.MemoryBanks.Length; i++)
            {
                if (i == highest) continue;

                Assert.True(original[i] < allocation.MemoryBanks[i]);
            }
        }
    }
}
