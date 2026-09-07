using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase
{
    [Authorize(Roles = "User,Administrator,Manager")]
    [HttpGet("balance")]
    public IActionResult ViewBalance()
    {
        return Ok("Balance: R1000");
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost("freeze")]
    public IActionResult FreezeAccount()
    {
        return Ok("Account frozen");
    }

    [Authorize(Roles = "Manager,Administrator")]
    [HttpPost("approve-transfer")]
    public IActionResult ApproveLargeTransfer()
    {
        return Ok("Transfer approved");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Authentication means who are you?");
        Console.WriteLine("Authorization means what may you do?");
        Console.WriteLine(
            "Banking needs both authentication and authorization to ensure that only authorized users can access the system."
        );
    }
}
