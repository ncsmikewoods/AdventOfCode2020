using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    public static class PermutationHelper
    {
        public static List<List<int>> CreatePermutations(List<int> adapters, int frontGap, int backGap)
        {
            var permutationsToTest = Math.Pow(2, adapters.Count);

            var permutations = new List<List<int>>();
            for (var i = 0; i < permutationsToTest; i++)
            {
                var permutationKey = Convert.ToString(i, 2).PadLeft(adapters.Count, '0');

                var permutation = CreatePermutation(permutationKey, adapters);

                if (IsValid(permutation, frontGap, backGap, adapters.Count))
                {
                    permutations.Add(permutation);
                }
            }

            return permutations;
        }

        public static List<int> CreatePermutation(string permutationKey, List<int> adapters)
        {
            return adapters.Where((t, i) => permutationKey[i].Equals('1')).ToList();
        }

        static bool IsValid(List<int> adapters, int frontGap, int backGap, int groupSize)
        {
            if (adapters.Count == 0) return (frontGap + backGap + groupSize < 3);

            for (var i = 0; i < adapters.Count; i++)
            {
                var leftGap = i == 0 ? frontGap : adapters[i] - adapters[i - 1];
                var rightGap = i == adapters.Count - 1 ? backGap : adapters[i + 1] - adapters[i];

                if (leftGap + rightGap > 3) return false;
            }

            return true;
        }
    }
}