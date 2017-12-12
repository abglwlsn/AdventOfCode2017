using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Models
{
    public class Network
    {
        public Network(string[] input)
        {
            Programs = new List<Program>();
            CurrentConnections = new List<Program>();
            ExcludedPrograms = new List<Program>();

            foreach (var line in input)
            {
                var pieces = line.Split(new string[] { "<->" }, StringSplitOptions.None);
                Programs.Add(new Program(pieces[0].Trim()));
            }

            this.SetConnections(input);
            this.ExcludedPrograms.AddRange(Programs);
        }

        public List<Program> Programs { get; set; }
        public List<Program> CurrentConnections { get; set; }
        public List<Program> ExcludedPrograms { get; set; }

        public int GetNumberOfProgramsInGroupBeginningWith(string programName)
        {
            var program = Programs.FirstOrDefault(p => p.Name == programName);
            var connections = program.GetExtendedConnections(this);

            return connections.Count();
        }

        public int GetNumberOfGroups()
        {
            var groups = 0;
            while (ExcludedPrograms.Any())
            {
                var startingProgram = ExcludedPrograms.First();
                var group = startingProgram.GetExtendedConnections(this).ToList();
                CurrentConnections.Clear();
                groups++;
            }
            return groups;
        }

        private void SetConnections(string[] input)
        {
            foreach (var line in input)
            {
                var pieces = line.Split(new[] { "<->" }, StringSplitOptions.None);
                var downstreamNames = pieces[1].Split(new[] { ", " }, StringSplitOptions.None);
                var program = Programs.FirstOrDefault(p => p.Name == pieces[0].Trim());
                foreach (var name in downstreamNames)
                {
                    var downstreamProgram = Programs.FirstOrDefault(d => d.Name == name.Trim());
                    program.ConnectedPrograms.Add(downstreamProgram);
                }
            }
        }
    }
}
