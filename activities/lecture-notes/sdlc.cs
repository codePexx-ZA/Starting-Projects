[Route("api/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("search/{name}")]
    public IActionResult SearchBook(string name)
    {
        var book = _bookService.SearchBookByName(name);

        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }
}
