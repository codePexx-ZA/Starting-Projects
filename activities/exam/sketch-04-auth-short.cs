using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;

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

public class User
{
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private static List<User> _users = new List<User>();

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        using var hmac = new HMACSHA256();
        var user = new User { Email = request.Email };
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
        return Ok(new { Token = "mock-jwt-token" });
    }
}
