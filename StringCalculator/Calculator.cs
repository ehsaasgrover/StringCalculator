using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        
        public int Add(String input)
        {
            if (input == "")
            {
                return 0;
            }
            
            var inputNumbers = input.Split(new[] {"," , "\n"}, StringSplitOptions.RemoveEmptyEntries);
            if (inputNumbers.Length == 1)
            {
                return Convert.ToInt16(input);
            }
            
            if (inputNumbers.Length > 1 && !input.StartsWith("//"))
            {
                var sum = 0; 
                var negativeNumbers = new List<string>();
                for (int i = 0; i < inputNumbers.Length; i++)
                {
                    var inputNumbersInt = Int32.Parse(inputNumbers[i]);
                    if (inputNumbersInt >= 0 && inputNumbersInt < 1000)
                    {
                        sum = sum + inputNumbersInt;
                    } else if (inputNumbersInt < 0)
                    {
                        negativeNumbers.Add(inputNumbers[i]);
                    } else if (inputNumbersInt >= 1000)
                    {
                        sum = 0;
                    }
                }
                if (negativeNumbers.Count > 0)
                {
                    var allNegatives = string.Join(", ", negativeNumbers);
                    Console.WriteLine("Negatives not allowed: "+allNegatives);
                    sum = 0;
                    // Need to return the negatives, not console write. But the 'allNegatives' is a string. . 
                }
                else
                {
                    return sum;
                }
            }

            if (inputNumbers.Length > 1 && input.StartsWith("//"))
            {
                var delimiter = inputNumbers[0].Remove(0, 2);
                var newNumbers = inputNumbers[1].Split(new [] {delimiter}, StringSplitOptions.RemoveEmptyEntries);
                var sum = 0;
                for (int i = 0; i < newNumbers.Length; i++)
                {
                    sum = sum + Int32.Parse(newNumbers[i]);
                }
                return sum;
            }
            
                
            return 0;
        }

        
        
        
    }
}