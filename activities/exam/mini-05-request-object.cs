using System;

public class RegisterRequest
{
    public string Email { get; set; }
    public string Password { get; set; }

}

public class Program
{

    public static void RegisterLoose(string email, string password)
    {
        Console.WriteLine("Loose email: " + email);
        Console.WriteLine("Loose password: " + password);
    }

    public static void RegisterWithRequest(RegisterRequest request)
    {

        Console.WriteLine("Request email: " + request.Email);
        Console.WriteLine("Request password: " + request.Password);
    }

    public static void Main(string[] args)
    {
        RegisterLoose("sam@clinic.com", "Care1!");


        var request = new RegisterRequest { Email = "sam@clinic.com", Password = "Care1!" };
        RegisterWithRequest(request);
    }
}
