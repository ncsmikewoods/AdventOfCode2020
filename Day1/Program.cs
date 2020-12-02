using System;
using System.Collections.Generic;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new Solver();

            Part1(solver);
            Part2(solver);

            Console.ReadLine();
        }

        static void Part1(Solver solver)
        {
            var start = DateTime.Now;

            var (a, b) = solver.Solve1();
            var duration = DateTime.Now - start;

            Console.WriteLine($"Valid inputs: {a} and {b} and they sum up to {a + b}");
            Console.WriteLine($"Solution 1: {a * b}");
            Console.WriteLine($"Duration: {Math.Round(duration.TotalMilliseconds)}ms");
            Console.WriteLine("");
        }

        static void Part2(Solver solver)
        {
            var start = DateTime.Now;

            var (a, b, c) = solver.Solve2();
            var duration = DateTime.Now - start;

            Console.WriteLine($"Valid inputs: {a} and {b} and {c} and they sum up to {a + b + c}");
            Console.WriteLine($"Solution 2: {a * b * c}");
            Console.WriteLine($"Duration: {Math.Round(duration.TotalMilliseconds)}ms");

        }
    }
}
