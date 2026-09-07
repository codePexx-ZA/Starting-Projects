public class Stakeholder
{
    public string Name { get; set; }

    public string Role { get; set; }

    public string Responsibilities { get; set; }
}

public class EnterpriseArchitect
{
    public List<Stakeholder> Stakeholders { get; set; } = new List<Stakeholder>();

    public void AddStakeholder(Stakeholder stakeholder)
    {
        Stakeholders.Add(stakeholder);
    }

    public void DisplayStakeholders()
    {
        foreach (var stakeholder in Stakeholders)
        {
            Console.WriteLine(
                $"Name: {stakeholder.Name}, Role: {stakeholder.Role}, Responsibilities: {stakeholder.Responsibilities}"
            );
        }
    }
}
