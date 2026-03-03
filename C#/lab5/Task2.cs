using System;

namespace Task2
{
    public class Program
    {
        public static void Execute()
        {
            Console.WriteLine($"5 + 3 = {Math.Add(5, 3)}");
            Console.WriteLine($"5 - 3 = {Math.Subtract(5, 3)}");
            Console.WriteLine($"5 * 3 = {Math.Multiply(5, 3)}");
            Console.WriteLine($"5 / 3 = {Math.Divide(5, 3)}");
            try
            {
                Console.WriteLine($"5 / 0 = {Math.Divide(5, 0)}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static public class Math
    {
        static public int Add(int num1, int num2) { return num1 + num2; }
        static public int Subtract(int num1, int num2) { return num1 - num2; }
        static public int Multiply(int num1, int num2) { return num1 * num2; }
        static public int Divide(int num1, int num2) { 
            if (num2 != 0) 
                return num1 / num2; 

            throw new DivideByZeroException();
        }
    }
}