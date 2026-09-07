using System;
using System.Threading;

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
