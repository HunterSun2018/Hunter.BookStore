
using System;
using System.Linq;
using System.Threading.Tasks;
using Hunter.BookStore.Categories;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Hunter.BookStore.Books;


public class BookManager : DomainService
{
    private readonly IBookRepository _bookRepository;
    private readonly IRepository<Category, Guid> _categoryRepository;

    public BookManager(IBookRepository bookRepository, IRepository<Category, Guid> categoryRepository)
    {
        _bookRepository = bookRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<Task> CreateAsync(Guid authorId, string name, DateTime publishDate, float price, [CanBeNull] string[] categoryNames)
    {
        var book = new Book(GuidGenerator.Create(), authorId, name, publishDate, price);

        await SetCategoriesAsync(book, categoryNames);

        await _bookRepository.InsertAsync(book);

        return Task.CompletedTask;
    }

    public async Task UpdateAsync(
        Book book,
        Guid authorId,
        string name,
        DateTime publishDate,
        float price,
        [CanBeNull] string[] categoryNames
    )
    {
        book.AuthorId = authorId;
        book.SetName(name);
        book.PublishDate = publishDate;
        book.Price = price;

        await SetCategoriesAsync(book, categoryNames);

        await _bookRepository.UpdateAsync(book);
    }

    private async Task SetCategoriesAsync(Book book, [CanBeNull] string[] categoryNames)
    {
        if (categoryNames == null || !categoryNames.Any())
        {
            book.RemoveAllCategories();
            return;
        }

        var query = (await _categoryRepository.GetQueryableAsync())
            .Where(x => categoryNames.Contains(x.Name))
            .Select(x => x.Id)
            .Distinct();

        var categoryIds = await AsyncExecuter.ToListAsync(query);
        if (!categoryIds.Any())
        {
            return;
        }

        book.RemoveAllCategoriesExceptGivenIds(categoryIds);

        foreach (var categoryId in categoryIds)
        {
            book.AddCategory(categoryId);
        }
    }
}