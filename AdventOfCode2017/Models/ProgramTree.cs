using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Infrastructure;

namespace AdventOfCode2017.Models
{
    public class ProgramTree
    {
        public ProgramTree(string[] input)
        {
            Discs = new List<Disc>();
            Array.ForEach(input, line => Discs.Add(new Disc(line)));
        }

        public Disc InitialDisc { get; set; }
        public List<Disc> Discs { get; set; }

        public Disc GetBottomDisc()
        {
            var withChildren = Discs.Where(d => d.HasChildren).ToList();
            foreach (var disc in withChildren)
            {
                if (withChildren.Any(w => w.ChildDiscNames.Contains(disc.Name))) continue;

                InitialDisc = disc;
                return disc;
            }
            
            //shouldn't get here
            return new Disc();
        }

        public void BuildTree(Disc rootDisk)
        {
            rootDisk.SetChildDiscs(Discs);
        }

        public int DetermineOptimalWeightOfUnbalancedDisc()
        {
            if (InitialDisc == null)
            {
                var bottomDisc = GetBottomDisc();
                this.BuildTree(bottomDisc);
            }
            
            this.InitialDisc.SetStackWeights();
            var highestUnbalanced = GetTipOfUnbalancedBranch();
            var improperChild = highestUnbalanced.GetChildWithImproperWeight();
            var difference = highestUnbalanced.GetWeightDifferenceOfImproperChild();
            
            return improperChild.Weight - difference;
        }


        private Disc GetTipOfUnbalancedBranch()
        {
            var unbalancedStacks = Discs.Where(d => d.HasUnbalancedStacks);
            return unbalancedStacks.FirstOrDefault(d => !d.ChildDiscs.Any(c => c.HasUnbalancedStacks));
        }
    }
}
