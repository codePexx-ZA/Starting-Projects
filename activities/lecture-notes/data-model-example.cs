public class PatientRecord
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string MedicalHistory { get; set; }
}

public class LMSIntegration
{
    public void IntegrateWithGradingTool(string toolName)
    {
        Console.WriteLine($"Integrating with {toolName}...");
    }
}
