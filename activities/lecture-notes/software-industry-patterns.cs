[ApiController]
[Route("api/[controller]")]
public class AppointmentService : ControllerBase
{
    [HttpGet]
    public IActionResult GetAppointments()
    {
        return Ok("List of Appointments");
    }
}

public class EventPublisher
{
    public event Action<string> OnEventOccurred;

    public void PublishEvent(string eventName)
    {
        OnEventOccurred?.Invoke(eventName);
    }
}
