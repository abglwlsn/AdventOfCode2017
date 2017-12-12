using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Infrastructure;

namespace AdventOfCode2017.Models
{
    public class Disc
    {
        public Disc() { }

        public Disc(string input)
        {
            var properties = input.Replace("->", "").SplitBySpaceOrTab().ToArray();
            Name = properties[0];
            Weight = Convert.ToInt32(properties[1].Replace("(", string.Empty).Replace(")", string.Empty));

            if (properties.Length <= 2) return;

            HasChildren = true;
            ChildDiscNames = string.Join(" ", properties.Skip(2)).Replace(",", string.Empty);
        }

        public string Name { get; set; }
        public int Weight { get; set; }
        public int StackWeight { get; set; }
        public Disc ParentDisc { get; set; }
        public bool HasChildren { get; set; }
        public string ChildDiscNames { get; set; }
        public IEnumerable<Disc> ChildDiscs { get; set; }
        public bool HasUnbalancedStacks { get; set; }

        public int InclusiveStackWeight()
        {
            return StackWeight + Weight;
        }

        public void SetChildDiscs(List<Disc> allDiscs)
        {
            if (!this.HasChildren)
                return;

            ChildDiscs = allDiscs.Where(d => this.ChildDiscNames.Contains(d.Name));
            foreach (var child in this.ChildDiscs)
            {
                child.ParentDisc = this;
                child.SetChildDiscs(allDiscs);
            }
        }

        public void SetStackWeights()
        {
            if (!this.HasChildren)
                return;

            var childWeights = SetChildWeights();

            var distribution = childWeights.GroupBy(x => x.Value);
            if (distribution.Count() > 1)
            {
                this.HasUnbalancedStacks = true;
            }

            StackWeight = childWeights.Sum(w => w.Value);
        }

        private Dictionary<string, int> SetChildWeights()
        {
            var childWeights = new Dictionary<string, int>();
            foreach (var child in this.ChildDiscs)
            {
                child.SetStackWeights();
                var stackWeight = child.StackWeight;
                childWeights.Add(child.Name, stackWeight + child.Weight);
            }

            return childWeights;
        }

        public int GetWeightDifferenceOfImproperChild()
        {
            var improperChild = GetChildWithImproperWeight();
            var properChild = this.GetChildThatIsNot(improperChild);
            return improperChild.InclusiveStackWeight() - properChild.InclusiveStackWeight();
        }

        public Disc GetChildWithImproperWeight()
        {
            var improperChild = new Disc();
            foreach (var child in this.ChildDiscs)
            {
                if (this.ChildDiscs.Any(d => d.Name != child.Name && d.InclusiveStackWeight() == child.InclusiveStackWeight()))
                    continue;

                return child;
            }
            return improperChild;
        }

        private Disc GetChildThatIsNot(Disc improperChild)
        {
            return this.ChildDiscs.FirstOrDefault(d => d.Name != improperChild.Name);
        }
    }
}
