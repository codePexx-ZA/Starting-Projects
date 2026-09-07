using System;
using System.Collections.Generic;



public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsAvailable { get; set; }
}

public class Member
{
    public int Id { get; set; }
    public string FullName { get; set; }
}





public interface IBookStore
{
    Book FindById(int bookId);
    void Update(Book book);
}



public class BookStore : IBookStore
{
    private List<Book> _books = new List<Book>();

    public Book FindById(int bookId)
    {

        throw new NotImplementedException();
    }

    public void Update(Book book)
    {

        throw new NotImplementedException();
    }

    public void Add(Book book)
    {

        throw new NotImplementedException();
    }
}





public class LoanService
{
    private IBookStore _bookStore;

    public LoanService(IBookStore bookStore)
    {
        _bookStore = bookStore;
    }

    public void Borrow(int bookId, int memberId)
    {



        throw new NotImplementedException();
    }
}
