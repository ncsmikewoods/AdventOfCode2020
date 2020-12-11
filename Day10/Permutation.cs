using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    public class Permutation
    {
        public List<int> AdapterChain { get; set; }

        public bool IsValid()
        {
            if (AdapterChain.First() > 3) return false;

            for (var i = 0; i < AdapterChain.Count - 1; i++)
            {
                var diff = AdapterChain[i + 1] - AdapterChain[i];
                if (diff > 3) return false;
            }

            return true;
        }
    }
}