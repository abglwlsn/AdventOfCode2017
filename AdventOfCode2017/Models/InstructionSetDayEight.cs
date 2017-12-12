using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Infrastructure;

namespace AdventOfCode2017.Models
{
    public class InstructionSetDayEight
    {
        public InstructionSetDayEight(string[] input)
        {
            Registers = new List<Register>();
            Instructions = new List<Instruction>();
            HighestEverRegisterValue = 0;

            foreach (var line in input)
            {
                var components = line.SplitBySpaceOrTab().ToArray();
                Registers.Add(new Register(components[0]));
                Instructions.Add(new Instruction(components));
            }
        }

        public List<Instruction> Instructions { get; set; }
        public List<Register> Registers { get; set; }
        public int HighestEverRegisterValue { get; set; }


        public void Run()
        {
            foreach (var instruction in Instructions)
            {
                var target = Registers.FirstOrDefault(i => i.Name == instruction.TargetRegister);
                var comparison = Registers.FirstOrDefault(i => i.Name == instruction.ComparisonRegister);
                instruction.Perform(target, comparison);

                if (target.Value > HighestEverRegisterValue)
                {
                    HighestEverRegisterValue = target.Value;
                }
            }
        }

        public int GetHighestRegisterValue()
        {
            return Registers.Count == 0 ? 0 : Registers.Select(r => r.Value).Max();
        }

        public int GetHighestEverRegisterValue()
        {
            return Registers.Count == 0 ? 0 : HighestEverRegisterValue;
        }
    }
}
