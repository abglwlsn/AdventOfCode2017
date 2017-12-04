using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Interfaces;

namespace AdventOfCode2017.Infrastructure
{
    public class Calculator : ICalculate
    {
        public int SumLikeNeighbors(string input)
        {
            var sum = 0;
            var digits = SeparateInputStringIntoDigits(input);
            for (var i = 0; i < digits.Length; i++)
            {
                var compare = i == digits.Length - 1 ? digits[0] : digits[i + 1];
                if (digits[i] == compare)
                {
                    sum = sum + digits[i];
                }
            }
            return sum;
        }

        public int SumLikeOpposites(string input)
        {
            var sum = 0;
            var digits = SeparateInputStringIntoDigits(input);

            for (var i = 0; i < digits.Length; i++)
            {
                var pair = GetPairHalfwayAroundArray(digits, i);
                var compare = digits[pair];
                if (digits[i] == compare)
                {
                    sum = sum + digits[i];
                }
            }
            return sum;
        }

        private int[] SeparateInputStringIntoDigits(string number)
        {
            var characters = number.ToArray().Select(n => n.ToString()).ToArray();
            return Array.ConvertAll(characters, Convert.ToInt32);
        }

        private int GetPairHalfwayAroundArray(int[] digits, int index)
        {
            var half = digits.Length / 2;
            if (IsInSecondHalfOfInput(digits, index))
            {
                return half - (digits.Length - index);
            }

            return index + half;
        }

        private bool IsInSecondHalfOfInput(int[] digits, int index)
        {
            return index >= (digits.Length / 2);
        }

        public int DetermineChecksumOfRowDifferences(string[] rows)
        {
            var checksum = 0;
            foreach (var row in rows)
            {
                var entries = row.SplitBySpaceOrTab();
                var high = DetermineHighValue(entries);
                var low = DetermineLowValue(entries);

                checksum += (high - low);
            }

            return checksum;
        }

        public int DetermineChecksumOfRowDivision(string[] rows)
        {
            var checksum = 0;
            foreach (var row in rows)
            {
                var entries = row.SplitBySpaceOrTab().ToArray();
                var numbers = entries.Select(Convert.ToDecimal).ToList();

                for (var i = 0; i < numbers.Count(); i++)
                {
                    var quotient = FindWholeQuotient(i, numbers);
                    checksum += quotient;
                }
            }
            return checksum;
        }

        private int DetermineHighValue(IEnumerable<string> row)
        {
            var high = 0;
            foreach (var expression in row)
            {
                var number = Convert.ToInt32(expression);
                if (number > high)
                { high = number; }
            }

            return high;
        }

        private int DetermineLowValue(IEnumerable<string> row)
        {
            var low = Int32.MaxValue;
            foreach (var expression in row)
            {
                var number = Convert.ToInt32(expression);
                if (number < low)
                { low = number; }
            }

            return low;
        }

        private int FindWholeQuotient(int index, List<decimal> numbers)
        {
            //return numbers.Where((t, i) => i != index).Select(t => index / t).FirstOrDefault(quotient => !IsNegativeOrNotWhole(quotient));
            for (var i = 0; i < numbers.Count; i++)
            {
                if (i == index) continue;

                var quotient = numbers[index] / numbers[i];
                if (IsNegativeOrNotWhole(quotient))
                    continue;

                return Convert.ToInt32(quotient);
            }
            return 0;
        }

        private bool IsNegativeOrNotWhole(decimal difference)
        {
            return difference < 0 || (Math.Abs(difference % 1) != 0);
        }
    }
}
