using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Models
{
    public class Instruction
    {
        public Instruction(string[] components)
        {
            TargetRegister = components[0];
            IsIncrease = DetermineValueChange(components[1]);
            IncrementValue = Convert.ToInt32(components[2]);
            ComparisonRegister = components[4];
            Operation = GetComparison(components[5]);
            ComparisonNumber = Convert.ToInt32(components[6]);
        }
        public string TargetRegister { get; set; }
        public bool IsIncrease { get; set; }
        public int IncrementValue { get; set; }
        public string ComparisonRegister { get; set; }
        public ICompare Operation { get; set; }
        public int ComparisonNumber { get; set; }

        public void Perform(Register target, Register compared)
        {
            var validCondition = Operation.Complete(compared.Value, ComparisonNumber);

            if (validCondition && IsIncrease)
            {
                target.Value += IncrementValue;
            }

            if (validCondition && !IsIncrease)
            {
                target.Value -= IncrementValue;
            }
        }

        private bool DetermineValueChange(string increment)
        {
            if (increment == "inc")
                return true;
            if (increment == "dec")
                return false;

            throw new InvalidOperationException("Invalid increment argument.");
        }

        private ICompare GetComparison(string operation)
        {
            switch (operation)
            {
                case "==":
                    return new EqualTo();
                case ">":
                    return new GreaterThan();
                case "<":
                    return new LessThan();
                case ">=":
                    return new GreaterThanOrEqualTo();
                case "<=":
                    return new LessThanOrEqualTo();
                case "!=":
                    return new NotEqualTo();
                default:
                    throw new ArgumentException("Invalid command string.");
            }
        }
    }


    public interface ICompare
    {
        bool Complete(int target, int comparison);
    }

    #region ICompare implementations
    public class GreaterThan : ICompare
    {
        public bool Complete(int target, int comparison)
        {
            return target > comparison;
        }
    }

    public class LessThan : ICompare
    {
        public bool Complete(int target, int comparison)
        {
            return target < comparison;
        }
    }

    public class EqualTo : ICompare
    {
        public bool Complete(int target, int comparison)
        {
            return target == comparison;
        }
    }

    public class GreaterThanOrEqualTo : ICompare
    {
        public bool Complete(int target, int comparison)
        {
            return target >= comparison;
        }
    }

    public class LessThanOrEqualTo : ICompare
    {
        public bool Complete(int target, int comparison)
        {
            return target <= comparison;
        }
    }

    public class NotEqualTo : ICompare
    {
        public bool Complete(int target, int comparison)
        {
            return target != comparison;
        }
    }
    #endregion
}
