using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    public class Solver
    {
        static List<int> _adapters;

        public Solver()
        {
            GetInputs();
        }

        public int Solve1()
        {
            var distribution = new Dictionary<int, int>{{1, 0}, {2, 0 }, {3, 0}};

            // The first and last adapter gaps are fairly fixed
            distribution[_adapters[1]]++;
            distribution[3]++;

            for (var i = 0; i < _adapters.Count - 1; i++)
            {
                var diff = _adapters[i + 1] - _adapters[i];
                distribution[diff]++;
            }

            return distribution[1] * distribution[3];
        }

        public long Solve2()
        {
            var potentialRemovables = CalculatePotentialRemovables(_adapters);

            var (permutationsSoFar, refinedRemovables) = CalculateWithIsolatedRemovables(potentialRemovables);
            var groups = BuildGroups(_adapters, refinedRemovables);

            foreach (var group in groups)
            {
                permutationsSoFar *= group.CountValidPermutations();
            }

            return permutationsSoFar;
        }

        static List<int> CalculatePotentialRemovables(List<int> adapters)
        {
            var potentialRemovables = new List<int>();
            for (var i = 1; i < adapters.Count - 1; i++)
            {
                // an element is a candidate for removal if the sum of the gap to its left and right is less than 3
                var leftGap = adapters[i] - adapters[i-1];
                var rightGap = adapters[i+1] - adapters[i];

                if (leftGap + rightGap >= 3) continue;
                potentialRemovables.Add(adapters[i]);
            }

            return potentialRemovables;
        }

        static (long, List<int>) CalculateWithIsolatedRemovables(List<int> potentialRemovables)
        {
            var permutationCount = 1L;

            var removablesInAGroup = new List<int>();

            foreach (var index in potentialRemovables)
            {
                var isPartOfGroup = potentialRemovables.Any(x => x == index - 1 || x == index + 1);
                if (isPartOfGroup)
                {
                    removablesInAGroup.Add(index); // needs to be simulated 
                }
                else
                {
                    permutationCount *= 2; //we know it can be removed
                }
            }

            Console.WriteLine($"The refinement process removed {potentialRemovables.Count - removablesInAGroup.Count} elements, and the current permutation count is {permutationCount}");

            return (permutationCount, removablesInAGroup);
        }

        static List<Group> BuildGroups(List<int> adapters, List<int> removables)
        {
            var groups = new List<Group>();
            foreach (var currentElement in removables)
            {
                var element = currentElement;
                var groupWithContiguousElements =
                    groups.FirstOrDefault(g => g.Elements.Any(e => e == element - 1 || e == element + 1));

                if (groupWithContiguousElements != null)
                {
                    groupWithContiguousElements.Elements.Add(currentElement);
                }
                else
                {
                    groups.Add(new Group(adapters) {Elements = new List<int>{currentElement}});
                }
            }

            return groups;
        }

        static long CountPermutations(List<int> adapters, List<int> potentialRemovables, long permutationsSoFar)
        {
            var permutationsToTest = Math.Pow(2, potentialRemovables.Count);

            Console.WriteLine($"There are {permutationsToTest:n0} permutations to test.");

            for (var i = 0L; i < permutationsToTest; i++)
            {
                if (i % 10000 == 0)
                {
                    Console.WriteLine($"On permutation {i} - {(i/permutationsToTest) * 100:P}");
                }

                var permutationKey = Convert.ToString(i, 2).PadLeft(potentialRemovables.Count, '0');

                var permutation = GeneratePermutation(permutationKey, adapters, potentialRemovables);
                if (permutation.IsValid()) permutationsSoFar++;
            }

            return permutationsSoFar;
        }

        static Permutation GeneratePermutation(string permutationKey, List<int> adapters, List<int> potentialRemovables)
        {
            // use permutation key to build a list of element indexes to remove from adapters
            var elementsToRemove = new List<int>();
            for (var i = 0; i < potentialRemovables.Count; i++)
            {
                if (permutationKey[i] == '1')
                {
                    elementsToRemove.Add(potentialRemovables[i]);
                }
            }

            var permutation = new Permutation
            {
                AdapterChain = adapters.Where((t, i) => !elementsToRemove.Contains(i)).ToList()
            };
            return permutation;
        }

        static void GetInputs()
        {
            var lines = File.ReadAllLines("input.txt");
            Console.WriteLine($"Read {lines.Length} inputs");

            _adapters = lines.Select(int.Parse).ToList();
            _adapters.Add(0);
            _adapters.Add(_adapters.Max() + 3);
            _adapters.Sort();
        }
    }
}