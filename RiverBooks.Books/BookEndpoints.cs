using FastEndpoints;
using Microsoft.AspNetCore.Builder;

namespace RiverBooks.Books;

public static class  BookEndpoints
{
    public static void MapBookEndpoints(this WebApplication app)
    {
        app.MapGet("/books", (IBookService bookService) =>
        {
            return bookService.ListBooks();
        });
    }
}

public class ListBooksResponse
{
    public List<BookDto> Books { get; set; }
}

internal class ListBooksEndpoint(IBookService bookService) : EndpointWithoutRequest<ListBooksResponse>
{
    private readonly IBookService _bookService = bookService;

    public override void Configure()
    {
        Get("api/books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken = default)
    {
        var books = _bookService.ListBooks();
        await Send.OkAsync(new ListBooksResponse() { Books = books }, cancellationToken);
    }
}