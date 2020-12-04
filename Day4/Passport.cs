using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public class Passport
    {
        readonly List<string> _requiredFields = new List<string>{"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};

        public List<PassportField> Fields { get; set; } = new List<PassportField>();

        public bool IsValidPart1()
        {
            return !IsMissingRequiredFields();
        }

        public bool IsValidPart2()
        {
            if (IsMissingRequiredFields()) return false;

            return Fields.All(f => f.IsValid());
        }

        bool IsMissingRequiredFields()
        {
            var existingFields = Fields.Select(f => f.Name);
            var missingFields = _requiredFields.Except(existingFields).ToList();

            if (missingFields.Any())
            {
                Console.WriteLine($"Missing fields: {string.Join(", ", missingFields)}");
                return true;
            }

            return false;
        }
    }
}