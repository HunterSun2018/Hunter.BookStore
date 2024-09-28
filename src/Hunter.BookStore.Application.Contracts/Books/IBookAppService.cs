using System;
using System.Threading.Tasks;
using Hunter.BookStore.Authors;
using Hunter.BookStore.Categories;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hunter.BookStore.Books
{
    public interface IBookAppService : IApplicationService
    {
        Task<PagedResultDto<BookDto>> GetListAsync(BookGetListInput input);

        Task<BookDto> GetAsync(Guid id);

        Task CreateAsync(CreateUpdateBookDto input);

        Task UpdateAsync(Guid id, CreateUpdateBookDto input);

        Task DeleteAsync(Guid id);

        Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync();

        Task<ListResultDto<CategoryLookupDto>> GetCategoryLookupAsync();
    }
}