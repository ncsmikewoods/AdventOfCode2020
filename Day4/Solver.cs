using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
    public class Solver
    {
        static List<Passport> _passports;

        public Solver()
        {
            GetInputs();
        }

        public int Solve1()
        {
            return _passports.Count(p => p.IsValidPart1());
        }

        public int Solve2()
        {
            return _passports.Count(p => p.IsValidPart2());
        }

        static void GetInputs()
        {
            var input = File.ReadAllText("input.txt");

            var passportsRaw = input.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Read {passportsRaw.Length} inputs");

            _passports = passportsRaw.Select(ParsePassport).ToList();
        }

        static Passport ParsePassport(string passportRaw)
        {
            var fields = passportRaw.Replace(Environment.NewLine, " ")
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var passport = new Passport();

            foreach (var field in fields)
            {
                var fieldTokens = field.Split(":");
                passport.Fields.Add(new PassportField(fieldTokens[0], fieldTokens[1]));
            }

            return passport;
        }
    }
}