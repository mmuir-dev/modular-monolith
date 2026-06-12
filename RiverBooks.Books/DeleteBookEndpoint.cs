using FastEndpoints;

namespace RiverBooks.Books;

internal class DeleteBookEndpoint(IBookService bookService) :
  Endpoint<DeleteBookRequest>
{
  private readonly IBookService _bookservice = bookService;

  public override void Configure()
  {
    Delete("/books/{id}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(DeleteBookRequest request, CancellationToken ct)
  {
    await _bookservice.DeleteBookAsync(request.Id);
    await Send.NoContentAsync();
  }

}
