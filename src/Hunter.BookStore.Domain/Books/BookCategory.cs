
using System;
using Volo.Abp.Domain.Entities;

namespace Hunter.BookStore.Books;

public class BookCategory : Entity
{
    public Guid BookId { get; protected set; }

    public Guid CategoryId { get; protected set; }

    /* This constructor is for deserialization / ORM purpose */
    private BookCategory()
    {
    }

    public BookCategory(Guid bookId, Guid categoryId)
    {
        BookId = bookId;
        CategoryId = categoryId;
    }

    public override object[] GetKeys()
    {
        return new object[] { BookId, CategoryId };
    }
}