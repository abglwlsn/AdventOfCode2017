using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Models;
using Xunit;

namespace AdventOfCode2017.Tests.Models
{
    public class InstructionSetTests
    {
        private string[] input => new[] {"1", "-2", "3"};
        private string[] inputTwo => new[] {"1", "1", "-2", "-4", "-4"};

        [Fact]
        public void ConstructorShould_ReturnInstructionSetWithPopulatedIntArray()
        {
            var collection = new InstructionSet(input);

            Assert.Equal(0, collection.TargetIndex);
            Assert.Equal(0, collection.ActiveIndex);
            Assert.Equal(0, collection.StepsTaken);
            Assert.IsType<int[]>(collection.Instructions);
            Assert.Equal(input.Length, collection.Instructions.Length);
        }

        [Fact]
        public void PerformInstructionsPartOneShould_CountSteps()
        {
            var collection = new InstructionSet(input);
            collection.PerformInstructionsPartOne();

            Assert.Equal(4, collection.StepsTaken);
            Assert.NotEqual(0, collection.TargetIndex);
            Assert.NotEqual(0, collection.ActiveIndex);
        }

        [Fact]
        public void PerformInstructionsPartTwoShould_CountStepsWithDecrementIfOffsetOverThree()
        {
            var collection = new InstructionSet(inputTwo);
            collection.PerformInstructionsPartTwo();

            Assert.Equal(24, collection.StepsTaken);

            var oneCollection = new InstructionSet(inputTwo);
            oneCollection.PerformInstructionsPartOne();
            Assert.Equal(12, oneCollection.StepsTaken);
        }
    }
}
