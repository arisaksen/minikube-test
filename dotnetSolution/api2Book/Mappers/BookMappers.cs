using api2Book.Dtos.Book;
using api2Book.Models;

namespace api2Book.Mappers;

public static class BookMappers
{
    public static Book ToBookFromCreateRequest(this CreateBookRequestDto createBookRequestDto)
    {
        return new Book
        {
            Title = createBookRequestDto.Title,
            Isbn = createBookRequestDto.Isbn,
            Genre = createBookRequestDto.Genre,
            PublishedYear = createBookRequestDto.PublishedYear
        };
    }

    public static Book ToBookFromUpdateRequest(this UpdateBookRequestDto updateBookRequestDto)
    {
        return new Book
        {
            Title = updateBookRequestDto.Title,
            Isbn = updateBookRequestDto.Isbn,
            Genre = updateBookRequestDto.Genre,
            PublishedYear = updateBookRequestDto.PublishedYear
        };
    }
}