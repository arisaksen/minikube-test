using api2.Models;

namespace api2.Dtos.Book;

public class UpdateBookRequestDto
{
    public string Title { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public Genre Genre { get; set; }
    public int PublishedYear { get; set; }
}