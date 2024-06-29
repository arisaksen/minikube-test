using api2.Models;
using Microsoft.EntityFrameworkCore;

namespace api2.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Book { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>().HasData(new Book
        {
            Id = 1,
            Title = "The Hobbit",
            Isbn = "ISBN-123-456",
            Genre = Genre.Fantasy,
            PublishedYear = 1937
        });
        modelBuilder.Entity<Book>().HasData(new Book
        {
            Id = 2,
            Title = "The Da Vinci Code",
            Isbn = "ISBN-321-456",
            Genre = Genre.Thriller,
            PublishedYear = 2003
        });
        modelBuilder.Entity<Book>().HasData(new Book
        {
            Id = 3,
            Title = "Harry Potter and the Philosopher's Stone",
            Isbn = "ISBN-456-123",
            Genre = Genre.Fantasy,
            PublishedYear = 1997
        });
    }
}