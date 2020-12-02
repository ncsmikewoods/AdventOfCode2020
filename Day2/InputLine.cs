using System.Linq;

namespace Day2
{
    public class InputLine
    {
        public ValidationRule ValidationRule { get; set; }
        public string Password { get; set; }

        public bool IsValidForPart1()
        {
            var letterOccurrences = Password.Count(c => c == ValidationRule.Letter);

            var isValid = letterOccurrences >= ValidationRule.Parameter1
                   && letterOccurrences <= ValidationRule.Parameter2;

            if (isValid)
            {
                // Console.WriteLine($"For password {Password} the letter {ValidationRule.Letter} appears between {ValidationRule.Parameter1} and {ValidationRule.Parameter2} times.");
                // Console.WriteLine($"Occurrences: {letterOccurrences}");
                // Console.WriteLine("");
            }

            return isValid;
        }

        public bool IsValidForPart2()
        {
            var letterAtLocation1 = Password[ValidationRule.Parameter1 - 1];
            var letterAtLocation2 = Password[ValidationRule.Parameter2 - 1];

            var location1Match = ValidationRule.Letter.Equals(letterAtLocation1);
            var location2Match = ValidationRule.Letter.Equals(letterAtLocation2);

            var isValid = location1Match ^ location2Match;

            if (isValid)
            {
                // Console.WriteLine($"For password {Password} the letter {ValidationRule.Letter} appears at either location {ValidationRule.Parameter1} OR {ValidationRule.Parameter2}.");
                // Console.WriteLine($"Letter at location 1: {letterAtLocation1}");
                // Console.WriteLine($"Letter at location 2: {letterAtLocation2}");
                // Console.WriteLine("");
            }

            return isValid;
        }
    }
}