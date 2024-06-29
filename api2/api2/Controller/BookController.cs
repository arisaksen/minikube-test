using api2.Data;
using api2.Dtos.Book;
using api2.Mappers;
using api2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api2.Controller;

[Route("api/book")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;

    private readonly AppDbContext _db;

    public BookController(ILogger<BookController> logger, AppDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var books = await _db.Book.ToListAsync();
        books.ForEach(book => _logger.LogInformation($"Test logging: {book.Title}"));

        return Ok(books);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetBookById(int id)
    {
        var book = _db.Book.FirstOrDefault(book => book.Id == id);
        if (book == null)
        {
            return NoContent();
        }

        return Ok(book);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateBookRequestDto createBookRequestDto)
    {
        var book = createBookRequestDto.ToBookFromCreateRequest();
        _db.Book.Add(book);
        _db.SaveChanges();

        return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateBookRequestDto updateBookRequestDto)
    {
        var stock = _db.Book.FirstOrDefault(stock => stock.Id == id);
        if (stock == null)
        {
            return NotFound();
        }

        stock.Title = updateBookRequestDto.Title;
        stock.Isbn = updateBookRequestDto.Isbn;
        stock.Genre = updateBookRequestDto.Genre;
        stock.PublishedYear = updateBookRequestDto.PublishedYear;
        _db.SaveChanges();

        return Ok(stock);
    }

    [HttpGet("genre/{genre:int}")]
    public IActionResult GetBookById(Genre genre)
    {
        var books = _db.Book.Where(book => book.Genre == genre);

        return Ok(books);
    }
}