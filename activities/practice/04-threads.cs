using System;
using System.Threading;

public class Officer
{
    private string _name;

    public Officer(string name)
    {
        _name = name;
    }

    public void ProcessClaim()
    {

        Thread.Sleep(500);
        Console.WriteLine(_name + " processed a claim.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Officer officerA = new Officer("Officer A");
        Officer officerB = new Officer("Officer B");







        Thread threadA = new Thread(() => officerA.ProcessClaim());
        Thread threadB = new Thread(() => officerB.ProcessClaim());



        threadA.Start();
        threadB.Start();



        threadA.Join();
        threadB.Join();


        Console.WriteLine("All done.");
    }
}
