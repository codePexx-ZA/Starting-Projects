using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public enum BankRole
{
    User,
    Manager,
    Administrator,
}

public class BankUser
{
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public BankRole Role { get; set; }
}

public class AuthService
{
    private List<BankUser> _users = new List<BankUser>();

    public string Register(string email, string password, BankRole role)
    {
        using var hmac = new HMACSHA256();
        byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        byte[] passwordSalt = hmac.Key;
        var user = new BankUser
        {
            Email = email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Role = role,
        };
        _users.Add(user);
        return "registered";
    }

    public string Login(string email, string password)
    {
        var user = _users.FirstOrDefault(u => u.Email == email);
        if (user == null)
        {
            return "Unauthorized";
        }

        using var hmac = new HMACSHA256(user.PasswordSalt);
        byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        if (!passwordHash.SequenceEqual(user.PasswordHash))
        {
            return "Unauthorized";
        }

        return "mock-jwt-token";
    }

    public string DescribeAccess(BankRole role)
    {
        switch (role)
        {
            case BankRole.User:
                return "view balance";
            case BankRole.Manager:
                return "approve transfers";
            case BankRole.Administrator:
                return "freeze accounts";
            default:
                return "unknown";
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var auth = new AuthService();

        Console.WriteLine(auth.Register("liam@bank.com", "Secret1", BankRole.User));
        Console.WriteLine(auth.Login("liam@bank.com", "Secret1"));
        Console.WriteLine(auth.Login("liam@bank.com", "Wrong"));
        Console.WriteLine(auth.Login("ghost@bank.com", "Secret1"));
        Console.WriteLine(auth.DescribeAccess(BankRole.User));
        Console.WriteLine(auth.DescribeAccess(BankRole.Manager));
        Console.WriteLine(auth.DescribeAccess(BankRole.Administrator));
    }
}
