using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day4
{
    public class Passport
    {
        public List<PassportField> Fields { get; set; } = new List<PassportField>();

        public bool IsValid()
        {
            // Console.WriteLine("Testing passport...");
            var requiredFields = new List<string>{"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};

            var existingFields = Fields.Select(f => f.Name);

            var fieldsMissing = requiredFields.Except(existingFields).ToList();

            if (fieldsMissing.Any())
            {
                Console.WriteLine($"Missing fields: {string.Join(", ", fieldsMissing)}");
                return false;
            }

            return Fields.All(f => f.IsValid());
        }
    }

    public class PassportField
    {
        readonly Regex _hexTest = new Regex(@"^([a-fA-F0-9]{6})$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        readonly Regex _pidTest = new Regex(@"^([0-9]{9})$", RegexOptions.Compiled);
        readonly string[] _validEyeColors = {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};

        public PassportField(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }

        public bool IsValid()
        {
            return Name switch
            {
                "byr" => IsValidYear("Birth year", Value, 1920, 2002),
                "iyr" => IsValidYear("Issue year", Value, 2010, 2020),
                "eyr" => IsValidYear("Expiration year", Value, 2020, 2030),
                "hgt" => IsValidHeight(Value),
                "hcl" => IsValidHairColor(Value),
                "ecl" => IsValidEyeColor(Value),
                "pid" => IsValidPassportId(Value),
                "cid" => true,
                _ => false
            };
        }

        static bool IsValidYear(string fieldName, string value, int minYear, int maxYear)
        {
            if (!int.TryParse(value, out var year))
            {
                Console.WriteLine($"{fieldName} not a valid year: {value}");
                return false;
            }

            var isValidYear = year >= minYear && year <= maxYear;
            if (isValidYear) return true;

            Console.WriteLine($"{fieldName} not between {minYear} and {maxYear}: {value}");
            return false;
        }

        static bool IsValidHeight(string value)
        {
            if (value.EndsWith("cm"))
            {
                if (!int.TryParse(value.Substring(0, 3), out var height))
                {
                    Console.WriteLine($"Height not a valid number: {value}");
                    return false;
                }

                var isValidRange = height >= 150 && height <= 193;
                if (isValidRange) return true;

                Console.WriteLine($"Height not between 150cm and 193cm: {value}");
                return false;
            }

            if (value.EndsWith("in"))
            {
                if (!int.TryParse(value.Substring(0, 2), out var height))
                {
                    Console.WriteLine($"Height not a valid number: {value}");
                    return false;
                }

                var isValidRange = height >= 59 && height <= 76;
                if (isValidRange) return true;

                Console.WriteLine($"Height not between 59in and 76in: {value}");
                return false;
            }

            Console.WriteLine($"Height is not in a valid format: {value}");
            return false;
        }

        bool IsValidHairColor(string value)
        {
            if (!value.StartsWith("#") || value.Length != 7)
            {
                Console.WriteLine($"Hair color not a valid format: {value}");
                return false;
            }

            var colorCode = value.Substring(1);
            var isValidColorCode = _hexTest.IsMatch(colorCode);

            if (isValidColorCode) return true;

            Console.WriteLine($"Hair color not a valid color code: {value}");
            return false;
        }

        bool IsValidEyeColor(string value)
        {
            var isValid = _validEyeColors.Contains(value);
            if (isValid) return true;

            Console.WriteLine($"Eye color not a valid eye color: {value}");
            return false;
        }

        bool IsValidPassportId(string value)
        {
            var isValid = _pidTest.IsMatch(value);
            if (isValid) return true;

            Console.WriteLine($"Passport Id not a valid format: {value}");
            return false;
        }
    }
}