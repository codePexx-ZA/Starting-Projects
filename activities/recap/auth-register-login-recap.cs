using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public class RegisterRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class BankUser
{
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}

public class AuthService
{
    private List<BankUser> _users = new List<BankUser>();

    public string Register(RegisterRequest request)
    {
        using var hmac = new HMACSHA256();
        byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
        _users.Add(
            new BankUser
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = hmac.Key,
            }
        );
        return "registered";
    }

    public string Login(LoginRequest request)
    {
        var user = _users.FirstOrDefault(u => u.Email == request.Email);
        if (user == null)
        {
            return "Unauthorized";
        }
        using var hmac = new HMACSHA256(user.PasswordSalt);
        byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
        if (!passwordHash.SequenceEqual(user.PasswordHash))
        {
            return "Unauthorized";
        }
        return "mock-jwt-token";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var auth = new AuthService();
        Console.WriteLine(
            auth.Register(new RegisterRequest { Email = "liam@bank.com", Password = "Secret1" })
        );
        Console.WriteLine(
            auth.Login(new LoginRequest { Email = "liam@bank.com", Password = "Secret1" })
        );
        Console.WriteLine(
            auth.Login(new LoginRequest { Email = "liam@bank.com", Password = "Secret2" })
        );
        Console.WriteLine(
            auth.Login(new LoginRequest { Email = "ghost@bank.com", Password = "Ghost1" })
        );
    }
}
