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
                var isNegative = 0;
                List<string> negativeNumbers = new List<string>();
                for (int i = 0; i < inputNumbers.Length; i++)
                {
                    if ((Int32.Parse(inputNumbers[i])) > 0)
                    {
                        sum = sum + Int32.Parse(inputNumbers[i]);
                    } else if ((Int32.Parse(inputNumbers[i])) < 0)
                    {
                        isNegative++;
                        negativeNumbers.Add(inputNumbers[i]);
                    }
                }
                if (isNegative > 0)
                {
                    var allNegatives = string.Join(", ", negativeNumbers);
                    Console.WriteLine("Negatives not allowed: "+allNegatives);
                    sum = 0;
                    // Need to return the negatives, not console write. But the 'allNegatives' is a string. . 
                }
                else if (isNegative == 0)
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