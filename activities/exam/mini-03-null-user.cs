using System;
using System.Collections.Generic;
using System.Linq;

public class BankUser
{
    public string Email { get; set; }
    public string Role { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<BankUser> users = new List<BankUser>();
        users.Add(new BankUser { Email = "liam@bank.com", Role = "User" });

        string emailFound = "liam@bank.com";
        string emailMissing = "ghost@bank.com";

        var userFound = users.FirstOrDefault(u => u.Email == emailFound);
        if (userFound == null)
        {
            Console.WriteLine("Unauthorized");
        }
        else
        {
            Console.WriteLine("Found: " + userFound.Email);
        }

        var userMissing = users.FirstOrDefault(u => u.Email == emailMissing);
        if (userMissing == null)
        {
            Console.WriteLine("Unauthorized");
        }
        else
        {
            Console.WriteLine("Found: " + userMissing.Email);
        }
    }
}
