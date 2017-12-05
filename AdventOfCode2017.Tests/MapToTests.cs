using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Infrastructure;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class MapToTests
    {
        [Fact]
        public void IntegerArrayShould_ConvertStringArrayToSignedIntArray()
        {
            var input = new [] {"1", "2", "-3", "-4"};
            var result = input.AsIntegerArray();

            Assert.IsType<int[]>(result);
            Assert.Equal(input.Length, result.Length);
        }
    }
}
