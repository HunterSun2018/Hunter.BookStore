using System;
using Volo.Abp.Application.Dtos;

namespace Hunter.BookStore.Categories
{
    public class CategoryDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}