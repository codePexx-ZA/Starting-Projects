using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Authentication means who are you?");
        Console.WriteLine("Authorization means what may you do?");
        Console.WriteLine("Why hash passwords because it is more secure than storing plain text.");
    }
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

public class BankUser
{
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string Role { get; set; }
}

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private static List<BankUser> _users = new List<BankUser>();

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        var user = new BankUser { Email = request.Email };
        using var hmac = new HMACSHA256();
        user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
        user.PasswordSalt = hmac.Key;
        _users.Add(user);
        return Ok("registered");
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var user = _users.FirstOrDefault(u => u.Email == request.Email);
        if (user == null)
        {
            return Unauthorized();
        }
        var computedHash = new HMACSHA256(user.PasswordSalt).ComputeHash(
            Encoding.UTF8.GetBytes(request.Password)
        );
        if (!computedHash.SequenceEqual(user.PasswordHash))
        {
            return Unauthorized();
        }
        return Ok(new { Token = "Mock JWT token" });
    }
}

public class DepositRequest
{
    public decimal Amount { get; set; }
}

[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase
{
    [HttpGet("balance")]
    [Authorize(Roles = "Customer,Teller,Administrator")]
    public IActionResult GetBalance()
    {
        return Ok("Balance: 1000");
    }

    [HttpPost("freeze")]
    [Authorize(Roles = "Administrator")]
    public IActionResult Freeze()
    {
        return Ok("Account frozen");
    }

    [HttpPost("deposit")]
    [Authorize(Roles = "Teller,Administrator")]
    public IActionResult Deposit([FromBody] DepositRequest request)
    {
        return Ok("Deposit amount: " + request.Amount);
    }
}
