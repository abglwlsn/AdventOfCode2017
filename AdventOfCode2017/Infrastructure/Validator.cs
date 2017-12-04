using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Interfaces;

namespace AdventOfCode2017.Infrastructure
{
    public class Validator : IValidate
    {
        public int GetNumberOfValidPassphrases(string[] phrases)
        {
            var numberOfValidPhrases = 0;
            foreach (var phrase in phrases)
            {
                var sections = phrase.SplitBySpaceOrTab().ToList();
                if (DistinctEntriesMatchTotalEntries(sections) && NoEntryHasAnAnagram(sections))
                {
                    numberOfValidPhrases++;
                }
            }

            return numberOfValidPhrases;
        }

        private bool DistinctEntriesMatchTotalEntries(List<string> sections)
        {
            return sections.Distinct().Count() == sections.Count;
        }

        private bool NoEntryHasAnAnagram(List<string> sections)
        {
            var characterCollections = sections.Select(section => section.ToCharArray()).ToList();
            foreach (var activeCollection in characterCollections)
            {
                foreach (var secondaryCollection in characterCollections)
                {
                    if (secondaryCollection != activeCollection && secondaryCollection.LooselyMatchesElements(activeCollection))
                        return false;
                }
            }

            return true;
        }
    }
}
