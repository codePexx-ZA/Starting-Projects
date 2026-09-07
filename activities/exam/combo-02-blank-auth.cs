using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public enum ShopRole
{
    Cashier,
    Supervisor,
    Admin,
    Unknown,
}

public class ShopUser
{
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public ShopRole Role { get; set; }
}

public class AuthService
{
    private List<ShopUser> _users = new List<ShopUser>();

    public string Register(string email, string password, ShopRole role)
    {
        using var hmac = new HMACSHA256();
        byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        byte[] passwordSalt = hmac.Key;
        var user = new ShopUser
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

    public string DescribeAccess(ShopRole role)
    {
        switch (role)
        {
            case ShopRole.Cashier:
                return "take payment";
            case ShopRole.Supervisor:
                return "void sale";
            case ShopRole.Admin:
                return "manage staff";
            default:
                return "unknown";
        }
        return "unknown";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var auth = new AuthService();
        Console.WriteLine(auth.Register("alex@shop.com", "Shop1!", ShopRole.Cashier));
        Console.WriteLine(auth.Login("alex@shop.com", "Shop1!"));
        Console.WriteLine(auth.Login("alex@shop.com", "Wrong"));
        Console.WriteLine(auth.Login("ghost@shop.com", "Shop1!"));
        Console.WriteLine(auth.DescribeAccess(ShopRole.Cashier));
        Console.WriteLine(auth.DescribeAccess(ShopRole.Supervisor));
        Console.WriteLine(auth.DescribeAccess(ShopRole.Admin));
        Console.WriteLine(auth.DescribeAccess(ShopRole.Unknown));
    }
}
