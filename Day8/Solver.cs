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
            var (isSuccessful, accumulator) = ExecuteProgram(_inputs);

            if (isSuccessful) Console.WriteLine("Program contains no infinite loops");
            return accumulator;
        }

        public int Solve2()
        {
            for (var i = _inputs.Length - 1; i >= 0; i--)
            {
                var lineOfCode = _inputs[i];

                if (lineOfCode.Instruction.Equals("acc")) continue;

                var copy = CopyProgram(_inputs);
                copy[i] = SwapInstruction(copy[i]);
                var (isSuccessful, accumulator) = ExecuteProgram(copy);

                if (isSuccessful) return accumulator;
            }

            Console.WriteLine("There is no way to fix this code.");
            return 1;
        }

        static (bool, int) ExecuteProgram(LineOfCode[] code)
        {
            var executedLines = new List<int>();
            var cursorPosition = 0;
            var accumulator = 0;

            while (cursorPosition < code.Length)
            {
                if (executedLines.Contains(cursorPosition))
                {
                    return (false, accumulator);
                }

                executedLines.Add(cursorPosition);

                var lineOfCode = code[cursorPosition];
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

            return (true, accumulator);
        }

        static LineOfCode SwapInstruction(LineOfCode lineOfCode)
        {
            return new LineOfCode
            {
                LineNumber = lineOfCode.LineNumber,
                Value = lineOfCode.Value,
                Instruction = lineOfCode.Instruction.Equals("nop") ? "jmp" : "nop"
            };
        }

        static LineOfCode[] CopyProgram(LineOfCode[] code)
        {
            var copy = new LineOfCode[code.Length];
            Array.Copy(code, copy, code.Length);

            return copy;
        }

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
}