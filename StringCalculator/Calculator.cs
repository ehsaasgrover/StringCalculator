using System;

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
            
            if (inputNumbers.Length > 1)
            {
                var sum = 0;
                for (int i = 0; i < inputNumbers.Length; i++)
                {
                    sum = sum + Int32.Parse(inputNumbers[i]);
                }

                return sum;
            }
            return 1;
        }
    }
}