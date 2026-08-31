using System;

namespace ShapeAreaCalc;

class Program
{
    static void Main(string[] args)
    {
        string continueAnswer = "y";
        do
        {
            Console.WriteLine("Enter the shape type (circle, rectangle, triangle):");
            Console.WriteLine("Press c for circle, r for rectangle, t for triangle");
            string answer = Console.ReadLine() ?? "";

            if (answer == "c")
            {
                Console.WriteLine("Enter the radius of the circle:");
                if (double.TryParse(Console.ReadLine(), out double radius))
                {
                    double area = Math.PI * radius * radius;
                    Console.WriteLine($"The area of the circle is: {area}cm²");
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            else if (answer == "r")
            {
                Console.WriteLine("Enter the length of the rectangle:");
                if (double.TryParse(Console.ReadLine(), out double length))
                {
                    Console.WriteLine("Enter the width of the rectangle:");
                    if (double.TryParse(Console.ReadLine(), out double width))
                    {
                        double area = length * width;
                        Console.WriteLine($"The area of the rectangle is: {area}cm²");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            else if (answer == "t")
            {
                Console.WriteLine("Enter the base of the triangle:");
                if (double.TryParse(Console.ReadLine(), out double triangleBase))
                {
                    Console.WriteLine("Enter the height of the triangle:");
                    if (double.TryParse(Console.ReadLine(), out double height))
                    {
                        double area = 0.5 * triangleBase * height;
                        Console.WriteLine($"The area of the triangle is: {area}cm²");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            else
            {
                Console.WriteLine(
                    "Invalid input enter c for circle, r for rectangle, t for triangle or n to exit"
                );
            }
            Console.WriteLine("Do you want to continue? (y/n)");
            continueAnswer = Console.ReadLine() ?? "";
        } while (continueAnswer == "y");
        Console.WriteLine("Thank you for using the Shape Area Calculator");
    }
}
