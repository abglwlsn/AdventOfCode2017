using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Models;
using Xunit;

namespace AdventOfCode2017.Tests.Models
{
    public class ProgramTreeTests
    {
        [Fact]
        public void ConstructorShould_PopulateDiscs()
        {
            var input = new []
            {
                "pbga (66)", "xhth (57)", "ebii (61)", "havc (66)", "ktlj (57)", "fwft (72) -> ktlj, cntj, xhth",
                "qoyq (66)", "padx (45) -> pbga, havc, qoyq", "tknk (41) -> ugml, padx, fwft", "jptl (61)",
                "ugml (68) -> gyxo, ebii, jptl", "gyxo (61)", "cntj (57)"
            };

            var tree = new ProgramTree(input);

            Assert.Equal(13, tree.Discs.Count);
            Assert.Equal("pbga", tree.Discs.First().Name);
            Assert.Equal("cntj", tree.Discs.Last().Name);
        }

        [Fact]
        public void GetBottomDiscShould_ReturnBottomDisc()
        {
            var input = new[]
            {
                "pbga (66)", "xhth (57)", "ebii (61)", "havc (66)", "ktlj (57)", "fwft (72) -> ktlj, cntj, xhth",
                "qoyq (66)", "padx (45) -> pbga, havc, qoyq", "tknk (41) -> ugml, padx, fwft", "jptl (61)",
                "ugml (68) -> gyxo, ebii, jptl", "gyxo (61)", "cntj (57)"
            };

            var tree = new ProgramTree(input);
            var result = tree.GetBottomDisc();

            Assert.Equal("tknk", result.Name);
        }

        [Fact]
        public void BuildTreeShould_PopulateChildren()
        {
            var input = new[]
            {
                "pbga (66)", "xhth (57)", "ebii (61)", "havc (66)", "ktlj (57)", "fwft (72) -> ktlj, cntj, xhth",
                "qoyq (66)", "padx (45) -> pbga, havc, qoyq", "tknk (41) -> ugml, padx, fwft", "jptl (61)",
                "ugml (68) -> gyxo, ebii, jptl", "gyxo (61)", "cntj (57)"
            };
            var tower = new ProgramTree(input);
            var bottomDisc = tower.GetBottomDisc();

            tower.BuildTree(bottomDisc);

            Assert.NotNull(tower.Discs);
            foreach (var disc in tower.Discs.Where(d => d.HasChildren))
            {
                Assert.NotNull(disc.ChildDiscs);
            }
        }
    }
}
