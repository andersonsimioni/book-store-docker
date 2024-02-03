using Microsoft.AspNetCore.Mvc;
using Server.DataLayer.Extensions.BookStore;
using Server.DataLayer.Repositories.BookStore.Models;

namespace Server.WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class BooksController : Controller
{
    private readonly ILogger<BooksController> _logger;
    private readonly BookStoreContext _bookStoreContext;
    
    public BooksController(ILogger<BooksController> logger, BookStoreContext bookStoreContext)
    {   
        _logger = logger;
        _bookStoreContext = bookStoreContext;
    }
    
    [HttpGet("GetCategories")]
    /// <summary>
    /// Gets a list of categories from the database
    /// </summary>
    /// <returns>A list of categories</returns>
    public IActionResult GetCategories(){
        try
        {
            var categories = _bookStoreContext.GetCategoriesList();
            return Ok(categories);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(new EventId(), ex, "Error on get categories!");
            return BadRequest("Internal Server Error");
        }
    }

    [HttpGet("GetAuthors")]
    /// <summary>
    /// Gets a list of authors from the database
    /// </summary>
    /// <returns>A list of authors</returns>
    public IActionResult GetAuthors(){
        try
        {
            var authors = _bookStoreContext.GetAuthorsList();
            return Ok(authors);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(new EventId(), ex, "Error on get authors!");
            return BadRequest("Internal Server Error");
        }
    }

    [HttpGet("GetById")]
    /// <summary>
    /// Gets a book from the database by its ID 
    /// </summary> 
    /// <param name="bookId">The ID of the book to be retrieved</param> 
    /// <returns>The book with the specified ID</returns> 
    public IActionResult GetById(int bookId){ 
        try 
        { 
            var book = _bookStoreContext.GetBookById(bookId); 
            if(book == null) return NotFound("Book not found!"); 
            return Ok(book); 
        } 
        catch (System.Exception ex) 
        { 
            _logger.LogError(new EventId(), ex, "Error on get book by ID!"); 
            return BadRequest("Internal Server Error"); 
        } 
    }

    [HttpGet("GetAll")]
    /// <summary>
    /// Gets all books from DB
    /// </summary>
    /// <param name="author">The author of the book</param>
    /// <param name="page">The page number of the book</param>
    /// <param name="pageCount">The page count of the book</param>
    /// <returns>An IActionResult containing the book or an error message</returns>
    public IActionResult GetAll(int page, int pageCount){
        try
        {
            var book = _bookStoreContext.GetAll(page, pageCount);
            if(book == null) return NotFound("Book not found!");
            return Ok(book);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(new EventId(), ex, "Error on get book by Author!");
            return BadRequest("Internal Server Error");
        }
    }


    [HttpGet("GetByAuthor")]
    /// <summary>
    /// Gets a book by author from the book store context
    /// </summary>
    /// <param name="author">The author of the book</param>
    /// <param name="page">The page number of the book</param>
    /// <param name="pageCount">The page count of the book</param>
    /// <returns>An IActionResult containing the book or an error message</returns>
    public IActionResult GetByAuthor(string author, int page, int pageCount){
        try
        {
            var book = _bookStoreContext.GetBookByAuthor(author, page, pageCount);
            if(book == null) return NotFound("Book not found!");
            return Ok(book);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(new EventId(), ex, "Error on get book by Author!");
            return BadRequest("Internal Server Error");
        }
    }

    [HttpGet("GetByCategory")]
    /// <summary>
    /// Gets a book by category from the book store context
    /// </summary>
    /// <param name="category">The category of the book</param>
    /// <param name="page">The page number of the book</param>
    /// <param name="pageCount">The page count of the book</param>
    /// <returns>An IActionResult containing the book or an error message</returns>
    public IActionResult GetByCategory(string category, int page, int pageCount){
        try
        {
            var book = _bookStoreContext.GetBookByCategory(category, page, pageCount);
            if(book == null) return NotFound("Book not found!");
            return Ok(book);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(new EventId(), ex, "Error on get book by Category!");
            return BadRequest("Internal Server Error");
        }
    }

    [HttpGet("GetByISBN")] 
    /// <summary> 
    /// Gets a book by ISBN from the book store context 
    /// </summary> 
    /// <param name="ISBN">The ISBN of the book</param> 
    /// <returns>An IActionResult containing the book or an error message</returns> 
    public IActionResult GetByISBN(string ISBN){ 
        try 
        { 
            var book = _bookStoreContext.GetBookByISBN(ISBN); 
            if(book == null) return NotFound("Book not found!"); 
            return Ok(book); 
        } 
        catch (System.Exception ex) 
        { 
            _logger.LogError(new EventId(), ex, "Error on get book by ISBN!"); 
            return BadRequest("Internal Server Error"); 
        } 

    }

    [HttpGet("GetByTitle")]
    /// <summary>
    /// Gets a book by its title from the database.
    /// </summary>
    /// <param name="title">The title of the book.</param>
    /// <param name="page">The page number.</param>
    /// <param name="pageCount">The number of books per page.</param>
    /// <returns>Returns the book if found, otherwise returns a NotFound result.</returns>
    public IActionResult GetByTitle(string title, int page, int pageCount){
        try
        {
            var book = _bookStoreContext.GetBookByTitle(title, page, pageCount);
            if(book == null) return NotFound("Book not found!");
            return Ok(book);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(new EventId(), ex, "Error on get book by Title!");
            return BadRequest("Internal Server Error");
        }
    }

    [HttpGet("GetByType")]
    /// <summary>
    /// Gets a book by its type from the database.
    /// </summary>
    /// <param name="type">The type of the book.</param>
    /// <param name="page">The page number.</param>
    /// <param name="pageCount">The number of books per page.</param>
    /// <returns>Returns the book if found, otherwise returns a NotFound result.</returns>
    public IActionResult GetByType(string type, int page, int pageCount){
        try
        {
            var book = _bookStoreContext.GetBookByType(type, page, pageCount);
            if(book == null) return NotFound("Book not found!");
            return Ok(book);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(new EventId(), ex, "Error on get book by Title!");
            return BadRequest("Internal Server Error");
        }
    }
}