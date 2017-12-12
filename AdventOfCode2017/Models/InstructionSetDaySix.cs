using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Infrastructure;

namespace AdventOfCode2017.Models
{
    public class InstructionSetDaySix
    {
        public InstructionSetDaySix(string[] input)
        {
            Instructions = input.AsIntegerArray();
            TargetIndex = 0;
            ActiveIndex = 0;
            StepsTaken = 0;
        }

        public int TargetIndex { get; set; }
        public int ActiveIndex { get; set; }
        public int StepsTaken { get; set; }
        public int[] Instructions { get; private set; }

        public void PerformInstructionsPartOne()
        {
            while (TargetIndex < Instructions.Length)
            {
                CompleteSingleInstructionPartOne();

                StepsTaken++;
            }
        }

        private void CompleteSingleInstructionPartOne()
        {
            var jumpLength = Instructions[ActiveIndex];
            TargetIndex = ActiveIndex + jumpLength >= 0 ? ActiveIndex + jumpLength : 0;

            Instructions[ActiveIndex]++;
            ActiveIndex = TargetIndex;
        }

        public void PerformInstructionsPartTwo()
        {
            while (TargetIndex < Instructions.Length)
            {
                CompleteSingleInstructionPartTwo();

                StepsTaken++;
            }
        }

        private void CompleteSingleInstructionPartTwo()
        {
            var jumpLength = Instructions[ActiveIndex];
            TargetIndex = ActiveIndex + jumpLength >= 0 ? ActiveIndex + jumpLength : 0;

            if (Instructions[ActiveIndex] >= 3)
                Instructions[ActiveIndex]--;
            else
                Instructions[ActiveIndex]++;

            ActiveIndex = TargetIndex;
        }
    }
}
