using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hunter.BookStore.Categories
{
    public interface ICategoryAppService : 
        ICrudAppService<CategoryDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCategoryDto, CreateUpdateCategoryDto>
    {
    }
}