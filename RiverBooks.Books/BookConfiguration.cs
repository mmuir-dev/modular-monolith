using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.Books;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
  internal static readonly Guid Book1Guid = new Guid("470F8925-1A26-4ABB-8B65-FE160090F4DF");
  internal static readonly Guid Book2Guid = new Guid("BE4ECBEB-235F-4D56-B7E1-2E3F55E95173");
  internal static readonly Guid Book3Guid = new Guid("47C9269C-3D25-4ACA-BA3C-01A8B4D07A3B");

  public void Configure(EntityTypeBuilder<Book> builder)
  {
    builder.Property(p => p.Title)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();

    builder.Property(p => p.Author)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();

    builder.HasData(GetSampleBookData());
  }


  private IEnumerable<Book> GetSampleBookData()
  {
    var tolkein = "J.R.R. Tolkien";
    yield return new Book(Book1Guid, "The Fellowship of the Ring", tolkein, 10.99m);
    yield return new Book(Book2Guid, "The Two Towers", tolkein, 11.99m);
    yield return new Book(Book2Guid, "The Return of the King", tolkein, 12.99m);
  }
}
