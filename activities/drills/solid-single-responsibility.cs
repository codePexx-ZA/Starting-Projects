using System;

public class LibraryCard
{









}

public class Program
{
    public static void Main(string[] args)
    {
        LibraryCard card = new LibraryCard("Liam");
        card.BorrowOneBook();
        card.BorrowOneBook();

        Console.WriteLine("Holder: " + card.GetHolderName());
        Console.WriteLine("Books out: " + card.GetBooksOut());
    }
}
