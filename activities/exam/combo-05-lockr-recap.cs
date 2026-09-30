using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class GymMember
{
    public int Id { get; set; }
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

public class LockerBooking
{
    public int Id { get; set; }
    public int MemberId { get; set; }
    public string LockerNumber { get; set; }
}

public class CreateBookingRequest
{
    public string LockerNumber { get; set; }
}

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private static List<GymMember> _members = new();

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        using var hmac = new HMACSHA256();
        GymMember member = new GymMember
        {
            Id = _members.Count + 1,
            Email = request.Email,
            PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.Password)),
            PasswordSalt = hmac.Key,
            Role = "Member"
        };
        _members.Add(member);
        return Ok();
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        GymMember member = _members.FirstOrDefault(m => m.Email == request.Email);
        if (member == null)
        {
            return Unauthorized();
        }
        using var hmac = new HMACSHA256(member.PasswordSalt);
        byte[] hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.Password));
        if (!hash.SequenceEqual(member.PasswordHash))
        {
            return Unauthorized();
        }
        return Ok(new { Token = "mock-jwt-token" });
    }
}

[ApiController]
[Route("api/lockers")]
public class LockerController : ControllerBase
{
    private static List<LockerBooking> _bookings = new();
    private static int _nextId = 1;

    [Authorize(Roles = "Member,Staff")]
    [HttpPost("bookings")]
    public IActionResult CreateBooking([FromBody] CreateBookingRequest request)
    {
        LockerBooking booking = new LockerBooking
        {
            Id = _nextId,
            MemberId = 1,
            LockerNumber = request.LockerNumber
        };
        _bookings.Add(booking);
        _nextId++;
        return Ok(booking);
    }

    [Authorize]
    [HttpGet("bookings/{id}")]
    public IActionResult GetBooking(int id)
    {
        LockerBooking booking = _bookings.FirstOrDefault(b => b.Id == id);
        if (booking == null)
        {
            return NotFound();
        }
        return Ok(booking);
    }

    [HttpDelete("bookings/{id}")]
    [Authorize(Roles = "Staff")]
    public IActionResult CancelBooking(int id)
    {
        LockerBooking booking = _bookings.FirstOrDefault(b => b.Id == id);
        if (booking == null)
        {
            return NotFound();
        }
        _bookings.Remove(booking);
        return Ok();
    }
}
