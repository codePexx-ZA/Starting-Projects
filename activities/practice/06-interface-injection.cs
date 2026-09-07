using System;
using System.Collections.Generic;
using System.Linq;

public class StaffMember
{
    public int StaffId { get; set; }
    public string FullName { get; set; }
}

public interface IStaffLookup
{
    StaffMember FindById(int staffId);
}

public class StaffStore : IStaffLookup
{
    private List<StaffMember> _staff = new List<StaffMember>();

    public void Add(StaffMember member)
    {
        _staff.Add(member);
    }

    public StaffMember FindById(int staffId)
    {
        return _staff.FirstOrDefault(m => m.StaffId == staffId);
    }
}

public class StaffReporter
{
    private IStaffLookup _lookup;

    public StaffReporter(IStaffLookup lookup)
    {
        _lookup = lookup;
    }

    public void Report(int staffId)
    {
        StaffMember found = _lookup.FindById(staffId);

        if (found == null)
        {
            Console.WriteLine("Not found.");
            return;
        }

        Console.WriteLine("Found: " + found.FullName);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        StaffStore store = new StaffStore();
        store.Add(new StaffMember { StaffId = 1, FullName = "Naledi Mokoena" });
        store.Add(new StaffMember { StaffId = 2, FullName = "Thabo Ndlovu" });

        IStaffLookup lookup = store;
        StaffReporter reporter = new StaffReporter(lookup);
        reporter.Report(1);
        reporter.Report(99);
    }
}
