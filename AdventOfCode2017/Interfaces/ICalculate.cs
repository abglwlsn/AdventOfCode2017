﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Interfaces
{
    public interface ICalculate
    {
        int SumLikeNeighbors(string input);
        int SumLikeOpposites(string input);
    }
}
