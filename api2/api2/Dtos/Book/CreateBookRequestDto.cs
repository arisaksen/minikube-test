using api2.Models;

namespace api2.Dtos.Book;

public class CreateBookRequestDto
{
    public required string Title { get; set; }
    public required string Isbn { get; set; }
    public Genre Genre { get; set; }
    public int PublishedYear { get; set; }
}