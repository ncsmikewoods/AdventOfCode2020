using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    public class Solver
    {
        static List<GroupAnswers> _groups;

        public Solver()
        {
            GetInputs();
        }

        public int Solve1()
        {
            return _groups.Sum(g => g.CharCounts.Keys.Distinct().Count());
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

            _groups = new List<GroupAnswers>();
            foreach (var groupRaw in groupsRaw)
            {
                _groups.Add(ParseGroup(groupRaw));
            }
        }

        static GroupAnswers ParseGroup(string group)
        {
            var lines = group.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            var charCounts = new Dictionary<char, int>();

            foreach (var line in lines)
            {
                foreach (var letter in line)
                {
                    charCounts[letter] = charCounts.ContainsKey(letter) ? charCounts[letter] + 1 : 1;
                }
            }

            return new GroupAnswers
            {
                GroupSize = lines.Length,
                CharCounts = charCounts
            };
        }
    }
}