using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    public class GroupAnswers
    {
        public int GroupSize { get; set; }
        public Dictionary<char, int> CharCounts { get; set; }

        public int GetCommonCharacters()
        {
            return CharCounts.Count(kvp => kvp.Value == GroupSize);
        }
    }
}