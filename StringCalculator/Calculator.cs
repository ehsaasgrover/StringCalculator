using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        
        public int Add(String input)
        {
            if (input == "") return 0;

            var inputNumbers = input.Split(new[] {"," , "\n"}, StringSplitOptions.RemoveEmptyEntries);
            
            if (inputNumbers.Length == 1) return Convert.ToInt16(input);

            if (inputNumbers.Length > 1 && !input.StartsWith("//"))
            {
                return MultipleNumericStringInputs(inputNumbers);
            }

            if (inputNumbers.Length > 1 && input.Contains("]["))
            {
                return MultipleNumericStringInputsGivenDifferentLengthDelimiters(inputNumbers);
            }
            
            if (inputNumbers.Length > 1 && input.StartsWith("//[") && !input.Contains("]["))
            {
                return MultipleNumericStringInputsGivenDelimiterOfAnyLength(inputNumbers);
            }
            
            if (inputNumbers.Length > 1 && input.StartsWith("//"))
            {
                return MultipleNumericStringInputsGivenSingleDelimiter(inputNumbers);
            }
            
            return 0;
        }
        
        private static int MultipleNumericStringInputs(string[] inputNumbers)
        {
            var sum = 0;
            var negativeNumbers = new List<string>();
            foreach (var i in inputNumbers)
            {
                var inputNumbersInt = int.Parse(i);
                if (inputNumbersInt >= 0 && inputNumbersInt < 1000)
                {
                    sum += inputNumbersInt;
                }
                else if (inputNumbersInt < 0)
                {
                    negativeNumbers.Add(i);
                }
            }

            if (negativeNumbers.Count <= 0) return sum;
            var allNegatives = string.Join(", ", negativeNumbers);
            throw new ArgumentException("Negatives not allowed: " + allNegatives);
        }
        
        private static int MultipleNumericStringInputsGivenSingleDelimiter(string[] inputNumbers)
        {
            var delimiter = inputNumbers[0].Remove(0, 2);
            var inputNumbersWithoutDelimiter = inputNumbers[1].Split(new[] {delimiter}, StringSplitOptions.RemoveEmptyEntries);
            var sum = 0;
            foreach (var i in inputNumbersWithoutDelimiter)
            {
                sum += int.Parse(i);
            }
            return sum;
        }
        
        private static int MultipleNumericStringInputsGivenDelimiterOfAnyLength(string[] inputNumbers)
        {
            var inputDelimiter = inputNumbers[0].Remove(0, 3);
            var delimiterLength = inputDelimiter.Length - 1;
            var delimiter = inputDelimiter.Substring(0, delimiterLength);
            var inputNumbersWithoutDelimiter = inputNumbers[1].Split(new[] {delimiter}, StringSplitOptions.RemoveEmptyEntries);
            var sum = 0;
            foreach (var i in inputNumbersWithoutDelimiter)
            {
                sum += int.Parse(i);
            }
            return sum;
        }

        private static int MultipleNumericStringInputsGivenDifferentLengthDelimiters(string[] inputNumbers)
        {
            var inputDelimiters = inputNumbers[0].Remove(0, 2);
            var delimiterStart = 0;
            var delimiterList = new List<string>();
            for (var i = 0; i < inputDelimiters.Length; i++)
            {
                if (inputDelimiters[i] == '[')
                {
                    delimiterStart = i;
                }
                else if (inputDelimiters[i] == ']')
                {
                    var delimiterEnd = i;
                    var delimiter = inputDelimiters.Substring(delimiterStart+1, delimiterEnd - delimiterStart - 1 );
                    delimiterList.Add(delimiter);
                }
            }
            var inputNumbersWithoutDelimiter = inputNumbers[1].Split(delimiterList.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            return inputNumbersWithoutDelimiter.Sum(number => int.Parse(number));
        }
    }
}