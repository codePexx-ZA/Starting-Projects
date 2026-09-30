public class Patient
{
    public int Id { get; set; }
    public string FullName { get; set; }
}

public interface IPatientStore
{
    void Add(Patient patient);
    Patient FindById(int id);
}

public class PatientStore : IPatientStore
{
    private List<Patient> _patients = new();

    public void Add(Patient patient)
    {
        _patients.Add(patient);
    }

    public Patient FindById(int id)
    {
        return _patients.FirstOrDefault(p => p.Id == id);
    }
}

public class ReceptionService
{
    private IPatientStore _store;

    public ReceptionService(IPatientStore store)
    {
        _store = store;
    }

    public string Lookup(int id)
    {
        Patient patient = _store.FindById(id);
        if (patient == null)
        {
            return "missing";
        }
        return "found " + patient.FullName;
    }
}
