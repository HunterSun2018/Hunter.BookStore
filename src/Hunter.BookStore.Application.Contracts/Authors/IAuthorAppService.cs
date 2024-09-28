using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hunter.BookStore.Authors
{
    public interface IAuthorAppService : 
        ICrudAppService<AuthorDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateAuthorDto, CreateUpdateAuthorDto>
    {
    }
}