using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Infrastructure;
using Xunit;

namespace AdventOfCode2017
{
    public class Tests
    {
        [Fact]
        public void DayOne_ReturnsCorrectSum()
        {
            var calculator = new Calculator();
            var input = "1111";
            var expected = 4;

            var result = calculator.SumLikeNeighbors(input);

            Assert.Equal(expected, result);
        }
    }
}
