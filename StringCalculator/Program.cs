using System;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();
            Console.WriteLine(calc.Add(""));
            Console.WriteLine(calc.Add("1"));
            Console.WriteLine(calc.Add("10"));
            Console.WriteLine(calc.Add("1,2"));
            Console.WriteLine(calc.Add("3,5"));
            Console.WriteLine(calc.Add("1,2,3"));
            Console.WriteLine(calc.Add("1,2,3,4"));
            Console.WriteLine(calc.Add("1,2,3,4,5"));
            Console.WriteLine(calc.Add("1,2\n3"));
            Console.WriteLine(calc.Add("3\n5\n3,9"));
            Console.WriteLine(calc.Add("//;\n1;2"));
            Console.WriteLine(calc.Add("//k\n1k2"));
            Console.WriteLine(calc.Add("-1,2,-3"));
            Console.WriteLine(calc.Add("1000,1001,2"));

        }
    }
    
}