
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hunter.BookStore.Books;

public class Book : FullAuditedAggregateRoot<Guid>
{
    public Guid AuthorId { get; set; }

    public string Name { get; private set; }

    public DateTime PublishDate { get; set; }

    public float Price { get; set; }

    public ICollection<BookCategory> Categories { get; private set; }

    private Book()
    {
    }

    public Book(Guid id, Guid authorId, string name, DateTime publishDate, float price)
        : base(id)
    {
        AuthorId = authorId;
        SetName(name);
        PublishDate = publishDate;
        Price = price;

        Categories = new Collection<BookCategory>();
    }

    public void SetName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), BookConsts.MaxNameLength);
    }

    public void AddCategory(Guid categoryId)
    {
        Check.NotNull(categoryId, nameof(categoryId));

        if (IsInCategory(categoryId))
        {
            return;
        }

        Categories.Add(new BookCategory(bookId: Id, categoryId));
    }

    public void RemoveCategory(Guid categoryId)
    {
        Check.NotNull(categoryId, nameof(categoryId));

        if (!IsInCategory(categoryId))
        {
            return;
        }

        Categories.RemoveAll(x => x.CategoryId == categoryId);
    }

    public void RemoveAllCategoriesExceptGivenIds(List<Guid> categoryIds)
    {
        Check.NotNullOrEmpty(categoryIds, nameof(categoryIds));

        Categories.RemoveAll(x => !categoryIds.Contains(x.CategoryId));
    }

    public void RemoveAllCategories()
    {
        Categories.RemoveAll(x => x.BookId == Id);
    }

    private bool IsInCategory(Guid categoryId)
    {
        return Categories.Any(x => x.CategoryId == categoryId);
    }
}