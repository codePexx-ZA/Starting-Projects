using System;
using System.Collections.Generic;

public class Patient
{
    public int Id { get; set; }
    public string FullName { get; set; }
}

public class Appointment
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; }
}

public interface IAppointmentStore
{
    Appointment FindById(int appointmentId);
    void Cancel(int appointmentId);
}

public class AppointmentStore : IAppointmentStore
{
    private List<Appointment> _appointments = new List<Appointment>();

    public Appointment FindById(int appointmentId)
    {

        throw new NotImplementedException();
    }

    public void Add(Appointment appointment)
    {

        throw new NotImplementedException();
    }

    public void Update(Appointment appointment)
    {

        throw new NotImplementedException();
    }

    public void Remove(Appointment appointment)
    {

        throw new NotImplementedException();
    }
}
