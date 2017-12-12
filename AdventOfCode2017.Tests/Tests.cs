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
            var collection = new InstructionSetDaySix(input);
            collection.PerformInstructionsPartOne();

            Assert.Equal(343364, collection.StepsTaken);
        }

        [Fact]
        public void DayFive_PartTwo_ReturnsNumberOfStepsWithPossibleDecreaseInOffset()
        {
            var input = File.ReadAllLines($"{inputsPrefix}Day5.txt");
            var collection = new InstructionSetDaySix(input);
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

        [Fact]
        public void DaySeven_PartOne_ReturnsBottomDisc()
        {
            var input = File.ReadAllLines($"{inputsPrefix}Day7.txt");
            var tower = new ProgramTree(input);

            var result = tower.GetBottomDisc();

            Assert.NotNull(result);
            Assert.Equal("uownj", result.Name);
        }

        [Fact]
        public void DaySeven_PartTwo_ReturnsWeightDifference()
        {
            var input = File.ReadAllLines($"{inputsPrefix}Day7.txt");
            var tower = new ProgramTree(input);

            var bottomDisc = tower.GetBottomDisc();
            tower.BuildTree(bottomDisc);

            var result = tower.DetermineOptimalWeightOfUnbalancedDisc();
            
            Assert.Equal(596, result);
        }

        [Fact]
        public void DayEight_PartOne_ReturnsLargestRegisterValue()
        {
            var input = File.ReadAllLines($"{inputsPrefix}Day8.txt");
            var instructions = new InstructionSetDayEight(input);
            instructions.Run();

            var highest = instructions.GetHighestRegisterValue();
            Assert.Equal(8022, highest);
        }

        [Fact]
        public void DayEight_PartTwo_ReturnsLargestEverRegisterValue()
        {
            var input = File.ReadAllLines($"{inputsPrefix}Day8.txt");
            var instructions = new InstructionSetDayEight(input);
            instructions.Run();

            var highest = instructions.GetHighestEverRegisterValue();
            Assert.Equal(9819, highest);
        }

        [Fact]
        public void DayNine_PartOne_Returns()
        {
            //challenge not yet attempted
        }

        [Fact]
        public void DayTen_PartOne_Returns()
        {
            //challenge not yet attempted
        }

        [Fact]
        public void DayEleven_PartOne_Returns()
        {
            //challenge not yet attempted
        }

        [Fact]
        public void DayTwelve_PartOne_ReturnsPipesInGroup()
        {
            var input = File.ReadAllLines($"{inputsPrefix}Day12.txt");
            var network = new Network(input);
            var numberInGroup = network.GetNumberOfProgramsInGroupBeginningWith("0");

            Assert.Equal(134, numberInGroup);
        }

        [Fact]
        public void DayTwelve_PartTwo_ReturnsNumberOfGroups()
        {
            var input = File.ReadAllLines($"{inputsPrefix}Day12.txt");
            var network = new Network(input);
            var numberOfGroups = network.GetNumberOfGroups();

            Assert.Equal(193, numberOfGroups);
        }
    }
}