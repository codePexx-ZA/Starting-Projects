using Microsoft.AspNetCore.Mvc;

public class CreateAppointmentRequest
{
    public string PatientName { get; set; }
    public string Reason { get; set; }
}

public class Appointment
{
    public int Id { get; set; }
    public string PatientName { get; set; }
    public string Reason { get; set; }
}

[ApiController]
[Route("api/appointments")]
public class AppointmentsController : ControllerBase
{
    private static List<Appointment> _appointments = new List<Appointment>();

    [HttpPost]
    public IActionResult Create([FromBody] CreateAppointmentRequest request)
    {
        var appointment = new Appointment
        {
            PatientName = request.PatientName,
            Reason = request.Reason,
        };
        appointment.Id = _appointments.Count + 1;
        _appointments.Add(appointment);
        return Ok(appointment);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var appointment = _appointments.FirstOrDefault(a => a.Id == id);
        if (appointment == null)
        {
            return NotFound();
        }
        return Ok(appointment);
    }
}
