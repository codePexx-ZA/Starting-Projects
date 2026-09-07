using System;
using System.Security.Cryptography;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        string password = "Secret1";

        using var hmac = new HMACSHA256();
        byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        byte[] salt = hmac.Key;

        Console.WriteLine("Hash length: " + hash.Length);
        Console.WriteLine("Salt length: " + salt.Length);
    }
}
