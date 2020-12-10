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
            var distribution = new Dictionary<int, int>{{1, 0}, { 2, 0 } , { 3, 0 }};

            distribution[_adapters[0]]++;

            for (var i = 0; i < _adapters.Count - 1; i++)
            {
                var diff = _adapters[i + 1] - _adapters[i];
                distribution[diff]++;
            }

            distribution[3]++;

            return distribution[1] * distribution[3];
        }

        // public double Solve2()
        // {
        //     
        // }

        static void GetInputs()
        {
            var lines = File.ReadAllLines("input.txt");
            Console.WriteLine($"Read {lines.Length} inputs");

            _adapters = lines.Select(int.Parse).ToList();
            _adapters.Sort();
        }
    }
}