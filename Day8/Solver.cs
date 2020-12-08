using System;
using System.Collections.Generic;
using System.IO;

namespace Day8
{
    public class Solver
    {
        static LineOfCode[] _inputs;

        public Solver()
        {
            GetInputs();
        }

        public int Solve1()
        {
            var executedLines = new List<int>();
            var cursorPosition = 0;
            var accumulator = 0;

            while (true)
            {
                if (executedLines.Contains(cursorPosition)) break;
                executedLines.Add(cursorPosition);

                var lineOfCode = _inputs[cursorPosition];
                switch (lineOfCode.Instruction)
                {
                    case "nop": 
                        cursorPosition++;
                        break;

                    case "acc":
                        accumulator += lineOfCode.Value;
                        cursorPosition++;
                        break;

                    case "jmp":
                        cursorPosition += lineOfCode.Value;
                        break;
                }
            }

            return accumulator;
        }

        // public int Solve2()
        // {
        //     var seatIds = Solve1();
        //     seatIds.Sort();
        //
        //     var validSeats = Enumerable.Range(seatIds[0], seatIds.Count);
        //     var missingSeats = validSeats.Except(seatIds);
        //
        //     return missingSeats.First();
        // }

        static void GetInputs()
        {
            var lines = File.ReadAllLines("input.txt");
            Console.WriteLine($"Read {lines.Length} inputs");

            _inputs = new LineOfCode[lines.Length];

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var tokens = line.Split(new[] { " ", "+" }, StringSplitOptions.RemoveEmptyEntries);

                _inputs[i] = new LineOfCode
                {
                    LineNumber = i,
                    Instruction = tokens[0],
                    Value = int.Parse(tokens[1])
                };
            }
        }
    }

    public class LineOfCode
    {
        public int LineNumber { get; set; } 
        public string Instruction { get; set; }
        public int Value { get; set; }
    }
}