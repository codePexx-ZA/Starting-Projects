using System;

namespace CalculatorProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                double num1 = 0;
                double num2 = 0;
                double result = 0;

                Console.WriteLine("Welcome to the Calculator Program");
                Console.WriteLine("-----------------------------------");

                Console.WriteLine("Enter the first number: ");
                num1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the second number: ");
                num2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Select the operation: ");
                Console.WriteLine("+ for addition");
                Console.WriteLine("- for subtraction");
                Console.WriteLine("* for multiplication");
                Console.WriteLine("/ for division");
                Console.Write("Enter the operation: ");
                switch (Console.ReadLine())
                {
                    case "+":
                        result = num1 + num2;
                        Console.WriteLine($"The result is: {num1} + {num2} = {result}");
                        break;
                    case "-":
                        result = num1 - num2;
                        Console.WriteLine($"The result is: {num1} - {num2} = {result}");
                        break;
                    case "*":
                        result = num1 * num2;
                        Console.WriteLine($"The result is: {num1} * {num2} = {result}");
                        break;
                    case "/":
                        result = num1 / num2;
                        Console.WriteLine($"The result is: {num1} / {num2} = {result}");
                        break;
                    default:
                        Console.WriteLine("Invalid operation");
                        break;
                }
                Console.Write("Do you want to continue? (y/n): ");
            } while (Console.ReadLine()?.ToLower() == "y");

            Console.WriteLine("Cheers Boss");
            Console.ReadKey();
        }
    }
}
