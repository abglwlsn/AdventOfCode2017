using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Models
{
    public class Register
    {
        public Register(string name)
        {
            Name = name;
            Value = 0;
        }

        public string Name { get; private set; }
        public int Value { get; set; }
    }
}
