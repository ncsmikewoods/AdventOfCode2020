using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5
{
    public class Solver
    {
        static List<string> _inputs;

        public Solver()
        {
            GetInputs();
        }

        public List<int> Solve1()
        {
            var seatIds = new List<int>();

            foreach (var input in _inputs)
            {
                var rows = input.Substring(0, 7);
                var columns = input.Substring(7, 3);

                var rowNumber = CalculatePosition('F', rows, 0, 127);
                var columnNumber = CalculatePosition('L', columns, 0, 7);

                var seatId = (rowNumber * 8) + columnNumber;
                seatIds.Add(seatId);
            }

            return seatIds;
        }

        int CalculatePosition(char lowerMoveChar, string instructions, int rangeMin, int rangeMax)
        {
            var rangeSize = rangeMax - rangeMin + 1;
            if (rangeSize == 1) return rangeMin;

            var head = instructions.First();
            var tail = instructions.Substring(1);

            if (head.Equals(lowerMoveChar))
            {
                return CalculatePosition(lowerMoveChar, tail, rangeMin, rangeMax - (rangeSize / 2));
            }

            return CalculatePosition(lowerMoveChar, tail, rangeMin + (rangeSize / 2), rangeMax);
        }

        public int Solve2()
        {
            var seatIds = Solve1();
            seatIds.Sort();

            var validSeats = Enumerable.Range(seatIds[0], seatIds.Count);
            var missingSeats = validSeats.Except(seatIds);

            return missingSeats.First();
        }

        static void GetInputs()
        {
            var lines = File.ReadAllLines("input.txt");
            Console.WriteLine($"Read {lines.Length} inputs");

            _inputs = lines.ToList();
        }
    }
}