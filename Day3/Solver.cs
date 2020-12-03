using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3
{
    public class Solver
    {
        static bool[,] _map;
        static int _rows;
        static int _columns;

        public Solver()
        {
            BuildMap();
        }

        public int Solve1(int movesRight = 3, int movesDown = 1)
        {
            var rowIndex = 0;
            var colIndex = 0;

            var treesHit = 0;

            // Console.WriteLine($"Position: ({rowIndex}, {colIndex})");

            while (rowIndex <= _rows)
            {
                colIndex = (colIndex + movesRight) % _columns; // for wrapping
                rowIndex += movesDown;

                // Console.WriteLine($"Position: ({rowIndex}, {colIndex})");

                if (rowIndex >= _rows) break;

                if (_map[rowIndex, colIndex])
                {
                    // Console.WriteLine($"Tree hit at position ({rowIndex}, {colIndex})");
                    treesHit++;
                }
            }

            return treesHit;
        }

        // public (int, int, int) Solve2()
        // {
        //     foreach (var input in _inputs)
        //     {
        //         var goalSum = 2020 - input;
        //         var (second, third) = Solve1(goalSum);
        //
        //         if (second == 0 && third == 0) continue;
        //
        //         return (input, second, third);
        //     }
        //
        //     throw new Exception("No solution found");
        // }

        static void BuildMap()
        {
            var lines = File.ReadAllLines("input.txt");
            Console.WriteLine($"Read {lines.Length} inputs");

            _rows = lines.Length;
            _columns = lines[0].Length;

            _map = new bool[_rows, _columns];

            for (var rowIndex = 0; rowIndex < _rows; rowIndex++)
            {
                for (var colIndex = 0; colIndex < _columns; colIndex++)
                {
                    _map[rowIndex, colIndex] = lines[rowIndex][colIndex] == '#';
                }
            }

            Console.WriteLine($"Built map with {_rows} rows and {_columns} columns.");
        }
    }
}