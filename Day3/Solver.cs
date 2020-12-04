using System;
using System.IO;

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

        public double Solve1(int movesRight = 3, int movesDown = 1)
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

        public double Solve2()
        {
            var treesHit1 = Solve1(1, 1);
            var treesHit2 = Solve1(3, 1);
            var treesHit3 = Solve1(5, 1);
            var treesHit4 = Solve1(7, 1);
            var treesHit5 = Solve1(1, 2);
            //
            // Console.WriteLine($"Trees hit with 1, 1: {treesHit1}");
            // Console.WriteLine($"Trees hit with 3, 1: {treesHit2}");
            // Console.WriteLine($"Trees hit with 5, 1: {treesHit3}");
            // Console.WriteLine($"Trees hit with 7, 1: {treesHit4}");
            // Console.WriteLine($"Trees hit with 1, 2: {treesHit5}");

            var total = 1d;
            total *= treesHit1;
            total *= treesHit2;
            total *= treesHit3;
            total *= treesHit4;
            total *= treesHit5;

            return total;
        }

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