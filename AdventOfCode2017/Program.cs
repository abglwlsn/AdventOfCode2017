using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Infrastructure;

namespace AdventOfCode2017
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            var validator = new Validator();
            var input = File.ReadAllLines("c:\\users\\aww\\documents\\visual studio 2015\\Projects\\AdventOfCode2017\\AdventOfCode2017\\Input.txt");

            /*Day Four*/    //Console.WriteLine(validator.GetNumberOfValidPassphrases(input));
            /*Day Two*/     //Console.WriteLine(calculator.DetermineChecksumOfRowDifferences(input));
                            Console.WriteLine(calculator.DetermineChecksumOfRowDivision(input));
            /*Day One */    //Console.WriteLine(calculator.SumLikeOpposites(args[0]));

            Console.ReadLine();
        }
    }
}
