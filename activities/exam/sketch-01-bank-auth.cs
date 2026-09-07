using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public class BankUser
{
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string Role { get; set; }
}

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

public class AuthControllerSketch
{
    private List<BankUser> _users = new List<BankUser>();

    public string Register(RegisterRequest request)
    {
        using var hmac = new HMACSHA256();
        var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

        var user = new BankUser
        {
            Email = request.Email,
            PasswordHash = passwordHash,
            PasswordSalt = hmac.Key,
            Role = "User",
        };

        _users.Add(user);
        return "User registered successfully";
    }

    public string Login(LoginRequest request)
    {
        var user = _users.FirstOrDefault(u => u.Email == request.Email);
        if (user == null)
        {
            return "Unauthorized";
        }

        using var hmac = new HMACSHA256(user.PasswordSalt);
        var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

        if (!passwordHash.SequenceEqual(user.PasswordHash))
        {
            return "Unauthorized";
        }

        return "mock-jwt-token";
    }

    public string Logout()
    {
        return "Token discarded / session cleared";
    }
}

public class AccountControllerSketch
{
    public string ViewBalance()
    {
        return "Balance: R1000";
    }

    public string FreezeAccount()
    {
        return "Account frozen";
    }

    public string ApproveLargeTransfer()
    {
        return "Transfer approved";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var auth = new AuthControllerSketch();
        auth.Register(new RegisterRequest { Email = "liam@bank.com", Password = "Secret1" });
        Console.WriteLine(
            auth.Login(new LoginRequest { Email = "liam@bank.com", Password = "Secret1" })
        );
        Console.WriteLine(
            auth.Login(new LoginRequest { Email = "liam@bank.com", Password = "Wrong" })
        );
    }
}
