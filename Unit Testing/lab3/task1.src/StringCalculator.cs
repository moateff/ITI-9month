using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp
{
    public class StringCalculator
    {
        public StringCalculator()
        { 
        }

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;
            
            var delimiters = new char[] { ',', '\n' };

            var numbersInt = numbers.Split(delimiters).Select(int.Parse).ToList();

            int sum = numbersInt.Sum();
            
            var negativesInt = numbersInt.Where(n => n < 0).ToList();
            
            if (negativesInt.Any()) {
                throw new Exception($"negatives not allowed: {string.Join(",", negativesInt)}");
            }

            return sum;
        }
    }
}