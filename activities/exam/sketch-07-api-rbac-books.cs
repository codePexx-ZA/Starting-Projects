using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class CreateBookRequest
{
    public string Title { get; set; }
    public string Author { get; set; }
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}

public class DeleteBookRequest
{
    public int Id { get; set; }
}

public class DeleteBookResponse
{
    public string Message { get; set; }
}

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private static List<Book> _books = new List<Book>();

    [HttpPost]
    [Authorize(Roles = "Librarian,Admin")]
    public IActionResult Create([FromBody] CreateBookRequest request)
    {
        var book = new Book { Title = request.Title, Author = request.Author };
        book.Id = _books.Count + 1;
        _books.Add(book);
        return Ok(book);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Student,Librarian,Admin")]
    public IActionResult GetById(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        _books.Remove(book);
        return Ok("deleted");
    }
}
