using System;
using System.Threading;

public class Claim
{
    private bool _isProcessed;



    private object _lock = new object();

    public void Process(string officerName)
    {







        lock (_lock)
        {
            if (_isProcessed)
            {
                Console.WriteLine(officerName + ": already processed.");
                return;
            }
            else
            {
                _isProcessed = true;
                Console.WriteLine(officerName + " processed the claim.");
                return;
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Claim claim = new Claim();






        Thread threadA = new Thread(() => claim.Process("Officer A"));
        Thread threadB = new Thread(() => claim.Process("Officer B"));

        threadA.Start();
        threadB.Start();

        threadA.Join();
        threadB.Join();


        Console.WriteLine("All done.");
    }
}
