using System;
using System.Threading;
using System.Threading.Tasks;

public class MultiThreadedLibrarySystem
{
    public void SearchBook(string bookName)
    {

        Thread.Sleep(2000);

        Console.WriteLine($"Book '{bookName}' found!");
    }

    public void UpdateLoanStatus(string memberId)
    {

        Thread.Sleep(1000);

        Console.WriteLine($"Loan status updated for member {memberId}.");
    }

    public void ProcessRequests()
    {

        Thread searchThread = new Thread(() => SearchBook("The Great Gatsby"));

        Thread updateThread = new Thread(() => UpdateLoanStatus("M123"));

        searchThread.Start();

        updateThread.Start();

        searchThread.Join();

        updateThread.Join();
    }
}

public class ConcurrencyExample
{
    public void ManageRequests()
    {
        Task.Run(() => SearchBook("Moby Dick"));

        Task.Run(() => UpdateLoanStatus("M456"));
    }
}

public class ParallelismExample
{
    public void HandleMultipleRequests()
    {

        Parallel.Invoke(() => SearchBook("Moby Dick"), () => UpdateLoanStatus("M456"));
    }
}
