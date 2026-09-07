using System;

public class Program
{
    public static void Main(string[] args)
    {
        bool passwordMatched = true;
        bool passwordFailed = false;

        if (passwordMatched)
        {
            Console.WriteLine("mock-jwt-token");
        }
        else
        {
            Console.WriteLine("Unauthorized");
        }

        if (passwordFailed)
        {
            Console.WriteLine("Unauthorized");
        }
        else
        {
            Console.WriteLine("mock-jwt-token");
        }
    }
}
