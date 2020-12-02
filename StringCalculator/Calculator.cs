using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (input == "") return 0;

            // 0. split the delimiter declaration and the numbers to calc
            // 1. get the delimiters
            // 2. split the numbers to calc by delimiters
            // 3. sum the parsed numbers

            var hasCustomDelimiter = input.StartsWith("//");
            var defaultDelimiters = new[] {",", "\n"};

            string[] delimiters;
            string numbersWithDelimiters;
            if (hasCustomDelimiter)
            {
                var gibberish = input.Split('\n');
                var delimiterDeclaration = gibberish[0];
                delimiters = ExtractCustomDelimiters(delimiterDeclaration);
                numbersWithDelimiters = gibberish[1];
            }
            else
            {
                delimiters = defaultDelimiters;
                numbersWithDelimiters = input;
            }

            var stringNumbers = numbersWithDelimiters.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var intNumbers = stringNumbers.Select(int.Parse).ToArray();

            // check if numbers are negative -> throw exception with negative numbers as message
            var negativeNumbers = intNumbers.Where(n => n < 0).ToArray();
            var hasNegativeNumbers = negativeNumbers.Any();
            if (hasNegativeNumbers)
            {
                var allNegatives = string.Join(", ", negativeNumbers);
                throw new ArgumentException("Negatives not allowed: " + allNegatives);
            }

            // check if numbers are >= 1000 -> ignore
            var intNumbersLessThan1000 = intNumbers.Where(n => n < 1000);
            return intNumbersLessThan1000.Sum();
        }

        private static string[] ExtractCustomDelimiters(string delimiterDeclaration)
        {
            var hasDelimitersOfAnyLength = delimiterDeclaration[2].Equals('[') &&
                                           delimiterDeclaration[^1].Equals(']');
            if (hasDelimitersOfAnyLength)
            {
                var inputDelimiters = delimiterDeclaration.Substring(3).TrimEnd(']');
                var delimiters = inputDelimiters.Split("][");
                return delimiters;
            }
            var delimiter = delimiterDeclaration[2];
            return new[] {delimiter.ToString()};
        }
    }
}
