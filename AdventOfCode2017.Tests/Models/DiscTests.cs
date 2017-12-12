using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Models;
using Xunit;

namespace AdventOfCode2017.Tests.Models
{
    public class DiscTests
    {
        [InlineData("pbga (66)")]
        [InlineData("havc (66)")]
        [Theory]
        public void ConstructorShould_PopulatePropertiesWhenNoChildren(string line)
        {
            var disc = new Disc(line);

            Assert.NotNull(disc.Name);
            Assert.NotEqual(0, disc.Weight);
            Assert.False(disc.HasChildren);
            Assert.Null(disc.ChildDiscNames);
        }

        [InlineData("fwft (72) -> ktlj, cntj, xhth")]
        [InlineData("tknk (41) -> ugml, padx, fwft")]
        [Theory]
        public void ConstructorShould_PopulatePropertiesWhenHasChildren(string line)
        {
            var disc = new Disc(line);

            Assert.NotNull(disc.Name);
            Assert.NotEqual(0, disc.Weight);
            Assert.True(disc.HasChildren);
            Assert.NotEmpty(disc.ChildDiscNames);
            Assert.DoesNotContain("->", disc.ChildDiscNames);
            Assert.DoesNotContain(",", disc.ChildDiscNames);
        }
    }
}
