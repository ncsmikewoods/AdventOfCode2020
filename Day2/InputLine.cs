using System;
using System.Linq;

namespace Day2
{
    public class InputLine
    {
        public ValidationRule ValidationRule { get; set; }
        public string Password { get; set; }

        public bool IsValid()
        {
            var letterOccurrences = Password.Count(c => c == ValidationRule.Letter);

            var isValid = letterOccurrences >= ValidationRule.MinOccurrences
                   && letterOccurrences <= ValidationRule.MaxOccurrences;

            if (isValid)
            {
                // Console.WriteLine($"For password {Password} the letter {ValidationRule.Letter} appears between {ValidationRule.MinOccurrences} and {ValidationRule.MaxOccurrences} times.");
                // Console.WriteLine($"Occurrences: {letterOccurrences}");
                // Console.WriteLine("");
            }

            return isValid;
        }
    }
}