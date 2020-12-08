using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    public class Solver
    {
        static List<HashSet<char>> _groups;

        public Solver()
        {
            GetInputs();
        }

        public int Solve1()
        {
            return _groups.Sum(g => g.Count);
        }

        public int Solve2()
        {
            return 1;
        }

        static void GetInputs()
        {
            var inputString = File.ReadAllText("input.txt");

            var groupsRaw = inputString.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine($"Read {groupsRaw.Length} groups");

            _groups = new List<HashSet<char>>();
            foreach (var groupRaw in groupsRaw)
            {
                _groups.Add(ParseGroup(groupRaw));
            }
        }

        static HashSet<char> ParseGroup(string group)
        {
            var lines = group.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            var letters = new HashSet<char>();

            foreach (var line in lines)
            {
                foreach (var letter in line)
                {
                    letters.Add(letter);
                }
            }

            return letters;
        }
    }
}