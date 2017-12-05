using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Interfaces
{
    public interface IValidate
    {
        int GetNumberOfValidPassphrases(string[] phrases);
        int GetNumberOfValidPassphrasesWithoutAnagrams(string[] phrases);
    }
}
