using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public enum ClinicRole
{
    Nurse,
    Doctor,
    Admin,
}

public class ClinicUser
{
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public ClinicRole Role { get; set; }
}

public class AuthService
{
    private List<ClinicUser> _users = new List<ClinicUser>();

    public string Register(string email, string password, ClinicRole role)
    {
        using var hmac = new HMACSHA256();
        byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        byte[] passwordSalt = hmac.Key;
        var user = _users.FirstOrDefault(u => u.Email == email);
        if (user != null)
        {
            return "email taken";
        }
        var newUser = new ClinicUser
        {
            Email = email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Role = role,
        };
        _users.Add(newUser);
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

    public string DescribeAccess(ClinicRole role)
    {
        switch (role)
        {
            case ClinicRole.Nurse:
                return "record vitals";
            case ClinicRole.Doctor:
                return "write prescription";
            case ClinicRole.Admin:
                return "manage roster";
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
        Console.WriteLine(auth.Register("sam@clinic.com", "Care1!", ClinicRole.Nurse));
        Console.WriteLine(auth.Register("sam@clinic.com", "Other1!", ClinicRole.Doctor));
        Console.WriteLine(auth.Login("sam@clinic.com", "Care1!"));
        Console.WriteLine(auth.Login("sam@clinic.com", "Wrong"));
        Console.WriteLine(auth.Login("ghost@clinic.com", "Care1!"));
        Console.WriteLine(auth.DescribeAccess(ClinicRole.Nurse));
        Console.WriteLine(auth.DescribeAccess(ClinicRole.Doctor));
        Console.WriteLine(auth.DescribeAccess(ClinicRole.Admin));
    }
}
