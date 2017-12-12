using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Models
{
    public class Program
    {
        public Program(string name)
        {
            this.Name = name;
            ConnectedPrograms = new List<Program>();
        }

        public string Name { get; private set; }
        public List<Program> ConnectedPrograms { get; set; }

        public IEnumerable<Program> GetExtendedConnections(Network network)
        {
            network.ExcludedPrograms.Remove(this);
            if (IsIn(network.CurrentConnections))
            {
                network.CurrentConnections.Add(this);
            }

            var includedPrograms = ConnectedPrograms.Where(p => network.CurrentConnections.All(n => n != p)).ToList();
            if (!includedPrograms.Any()) return network.CurrentConnections.Distinct();

            foreach (var program in includedPrograms)
            {
                var programs = program.GetExtendedConnections(network).ToList();
            }

            return network.CurrentConnections.Distinct();
        }

        public bool IsIn(List<Program> collection)
        {
            return collection.All(n => n != this);
        }
    }
}
