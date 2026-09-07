using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        string storedPassword = "Secret1";
        string attemptCorrect = "Secret1";
        string attemptWrong = "Wrong";

        using var registerHmac = new HMACSHA256();
        byte[] storedHash = registerHmac.ComputeHash(Encoding.UTF8.GetBytes(storedPassword));
        byte[] storedSalt = registerHmac.Key;

        using var loginHmac = new HMACSHA256(storedSalt);
        byte[] attemptHash = loginHmac.ComputeHash(Encoding.UTF8.GetBytes(attemptCorrect));
        if (attemptHash.SequenceEqual(storedHash))
        {
            Console.WriteLine("Login OK");
        }
        else
        {
            Console.WriteLine("Unauthorized");
        }

        using var loginHmacWrong = new HMACSHA256(storedSalt);
        byte[] attemptWrongHash = loginHmacWrong.ComputeHash(Encoding.UTF8.GetBytes(attemptWrong));
        if (attemptWrongHash.SequenceEqual(storedHash))
        {
            Console.WriteLine("Login OK");
        }
        else
        {
            Console.WriteLine("Unauthorized");
        }
    }
}
