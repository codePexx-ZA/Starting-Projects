public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
}

public interface IBookStore
{
    void Add(Book book);
    Book FindById(int id);
}

public class BookStore : IBookStore
{
    private List<Book> _books = new();

    public void Add(Book book)
    {
        _books.Add(book);
    }

    public Book FindById(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }
}

public class LoanService
{
    private IBookStore _store;

    public LoanService(IBookStore store)
    {
        _store = store;
    }

    public string Loan(int bookId)
    {
        Book book = _store.FindById(bookId);
        if (book == null)
        {
            return "missing";
        }
        return "loaned " + book.Title;
    }
}
