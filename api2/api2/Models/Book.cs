using System.ComponentModel.DataAnnotations;

namespace api2.Models;

public class Book
{
    [Key] public int Id { get; set; }
    [Required] public string Title { get; set; }
    [Required] public string Isbn { get; set; }
    public Genre Genre { get; set; }
    public int PublishedYear { get; set; }
}

public enum Genre
{
    Fiction,
    Mystery,
    Fantasy,
    Thriller,
    Romatic,
    NonFiction,
    History,
    Other
}