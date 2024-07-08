using api2Book.Models;

namespace api2Book.Dtos.Book;

public class CreateBookRequestDto
{
    public required string Title { get; set; }
    public required string Isbn { get; set; }
    public Genre Genre { get; set; }
    public int PublishedYear { get; set; }
}