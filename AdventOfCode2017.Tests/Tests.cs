using System;
using System.IO;
using System.Linq;
using AdventOfCode2017.Infrastructure;
using AdventOfCode2017.Models;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Tests
    {
        private static string inputsPrefix => "../../Inputs/";

        [Fact]
        public void DayOne_PartOne_ReturnsSumOfLikeNeighbors()
        {
            var calculator = new Calculator();
            var input = File.ReadAllLines($"{inputsPrefix}Day1.txt");
            var expected = 1203;

            var result = calculator.SumLikeNeighbors(input[0]);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DayOne_PartTwo_ReturnsSumOfLikeOpposites()

        {
            var calculator = new Calculator();
            var input = File.ReadAllLines($"{inputsPrefix}Day1.txt");
            var expected = 1146;

            var result = calculator.SumLikeOpposites(input[0]);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DayTwo_PartOne_ReturnsChecksumFromDifferences()
        {
            var calculator = new Calculator();
            var input = File.ReadAllLines($"{inputsPrefix}Day2.txt");
            var expected = 37923;

            var result = calculator.DetermineChecksumOfRowDifferences(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DayTwo_PartTwo_ReturnsChecksumFromQuotients()
        {
            var calculator = new Calculator();
            var input = File.ReadAllLines($"{inputsPrefix}Day2.txt");
            var expected = 263;

            var result = calculator.DetermineChecksumOfRowQuotients(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DayThree_PartOne_ReturnsTravelDistance()
        {
            //challenge not yet attempted
        }

        [Fact]
        public void DayFour_PartOne_ReturnsValidPassphraseCount()
        {
            var validator = new Validator();
            var input = File.ReadAllLines($"{inputsPrefix}Day4.txt");
            var expected = 451;

            var result = validator.GetNumberOfValidPassphrases(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DayFour_PartTwo_ReturnsValidPassphraseCountWithoutAnagrams()
        {
            var validator = new Validator();
            var input = File.ReadAllLines($"{inputsPrefix}Day4.txt");
            var expected = 223;

            var result = validator.GetNumberOfValidPassphrasesWithoutAnagrams(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DayFive_PartOne_ReturnsNumberOfSteps()
        {
            var input = File.ReadAllLines($"{inputsPrefix}Day5.txt");
            var collection = new InstructionSet(input);
            collection.PerformInstructionsPartOne();

            Assert.Equal(343364, collection.StepsTaken);
        }

        [Fact]
        public void DayFive_PartTwo_ReturnsNumberOfStepsWithPossibleDecreaseInOffset()
        {
            var input = File.ReadAllLines($"{inputsPrefix}Day5.txt");
            var collection = new InstructionSet(input);
            collection.PerformInstructionsPartTwo();

            Assert.Equal(25071947, collection.StepsTaken);
        }

        [Fact]
        public void DaySix_PartOne_ReturnsNumberOfRedistributionCycles()
        {
            var input = File.ReadAllLines($"{inputsPrefix}Day6.txt");
            var allocation = new MemoryAllocation(input.First());
            var result = allocation.GetTotalCyclesBeforeLoopRestart();
            
            Assert.Equal(7864, result);
        }

        [Fact]
        public void DaySix_PartTwo_ReturnsNumberOfRedistributionCyclesInOneLoop()
        {
            var input = File.ReadAllLines($"{inputsPrefix}Day6.txt");
            var allocation = new MemoryAllocation(input.First());
            var result = allocation.GetCyclesForCompleteLoop();

            Assert.Equal(1695, result);
        }
    }
}