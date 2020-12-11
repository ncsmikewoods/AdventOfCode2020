using System.Collections.Generic;

namespace Day10
{
    public class Group
    {
        readonly List<int> _adapters;

        public Group(List<int> adapters)
        {
            _adapters = adapters;
        }

        public int FrontGap
        {
            get
            {
                var elementBefore = _adapters[_adapters.FindIndex(x => x == Elements[0]) - 1];
                return Elements[0] - elementBefore;
            }
        }

        public int BackGap
        {
            get
            {
                var elementAfter = _adapters[_adapters.FindIndex(x => x == Elements[^1]) + 1];
                return elementAfter - Elements[^1];
            }
        }

        public List<int> Elements { get; set; }

        public int CountValidPermutations()
        {
            var permutations = PermutationHelper.CreatePermutations(Elements, FrontGap, BackGap);
            return permutations.Count;
        }
    }
}