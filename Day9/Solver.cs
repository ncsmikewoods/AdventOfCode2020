using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day9
{
    public class Solver
    {
        const int PreambleSize = 25;
        static List<long> _data;

        public Solver()
        {
            GetInputs();
        }

        public long Solve1()
        {
            var preambleIndex = 0;

            for (var i = PreambleSize; i < _data.Count; i++)
            {
                var operands = _data.Skip(preambleIndex).Take(PreambleSize).ToList();

                var sumToCheck = _data[i];
                if (!SumExists(sumToCheck, operands)) return sumToCheck;

                preambleIndex++;
            }

            Console.WriteLine("No solution found");
            return 0;
        }

        static bool SumExists(long sum, List<long> operands)
        {
            foreach (var num in operands)
            {
                var otherNum= operands.FirstOrDefault(x => x != num && x + num == sum);
                if (otherNum != default) return true;
            }

            return false;
        }

        public double Solve2()
        {
            var sumToFind = Solve1();

            for (var i = 0; i < _data.Count; i++)
            {
                if (_data[i] == sumToFind) continue;

                long runningSetSum = 0;
                var runningSetLength = 1;
                while (runningSetSum < sumToFind && i + runningSetLength < _data.Count)
                {
                    var runningSet = _data.Skip(i).Take(runningSetLength).ToList();
                    runningSetSum = runningSet.Sum();

                    if (runningSetSum == sumToFind)
                    {
                        Console.WriteLine($"Set: {string.Join(", ", runningSet)}");

                        return GetEncryptionCode(runningSet);
                    }

                    runningSetLength++;
                }
            }

            Console.WriteLine("No solution found");
            return 0;
        }

        static double GetEncryptionCode(List<long> range)
        {
            return range.Min() + range.Max();
        }
        
        static void GetInputs()
        {
            var lines = File.ReadAllLines("input.txt");
            Console.WriteLine($"Read {lines.Length} inputs");

            _data = lines.Select(long.Parse).ToList();
        }
    }
}