using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    public class Solver
    {
        readonly List<InputLine> _inputs;

        public Solver()
        {
            _inputs = GetInputs();
        }

        public int Solve1()
        {

            return _inputs.Count(i => i.IsValid());
        }

        static List<InputLine> GetInputs()
        {
            var lines = File.ReadAllLines("input.txt");
            Console.WriteLine($"Read {lines.Length} inputs");

            return lines.Select(x => ParseLine(x.Trim())).ToList();
        }

        static InputLine ParseLine(string line)
        {
            var lineSplit = line.Split(": ");

            var validationSplit = lineSplit[0].Split('-', ' ');

            return new InputLine
            {
                Password = lineSplit[1],
                ValidationRule = new ValidationRule
                {
                    MinOccurrences = int.Parse(validationSplit[0]),
                    MaxOccurrences = int.Parse(validationSplit[1]),
                    Letter = Convert.ToChar(validationSplit[2]),
                }
            };
        }
    }
}