using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    public class Solver
    {
        readonly List<int> _inputs;

        public Solver()
        {
            _inputs = GetInputs();
        }

        public (int, int) Solve1(int goalSum = 2020)
        {
            foreach (var input in _inputs)
            {
                var diff = goalSum - input;
                if (_inputs.Contains(diff))
                {
                    return (input, diff);
                }
            }

            throw new Exception("No solution found");
        }

        public (int, int, int) Solve2()
        {
            foreach (var input in _inputs)
            {
                try
                {
                    var goalSum = 2020 - input;
                    var (second, third) = Solve1(goalSum);

                    return (input, second, third);
                }
                catch
                {
                }
            }

            throw new Exception("No solution found");
        }

        static List<int> GetInputs()
        {
            var lines = File.ReadAllLines("input.txt");
            Console.WriteLine($"Read {lines.Length} inputs");

            return lines.Select(x => int.Parse(x.Trim())).ToList();
        }
    }
}