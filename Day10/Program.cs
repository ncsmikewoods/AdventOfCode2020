﻿using System;
using System.Collections;

namespace Day10
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
            Console.WriteLine("Solving Part 1...");
            var start = DateTime.Now;

            var solution = solver.Solve1();
            var duration = DateTime.Now - start;

            Console.WriteLine($"Solution 1: {solution}");
            Console.WriteLine($"Duration: {Math.Round(duration.TotalMilliseconds)}ms");
            Console.WriteLine("");
        }

        static void Part2(Solver solver)
        {
            Console.WriteLine("Solving Part 2...");
            var start = DateTime.Now;
        
            var permutations = solver.Solve2();
            var duration = DateTime.Now - start;
            
            Console.WriteLine($"Solution 2: {permutations:n0}");
            Console.WriteLine($"Duration: {Math.Round(duration.TotalMilliseconds)}ms");
            Console.WriteLine("");
        }
    }
}
