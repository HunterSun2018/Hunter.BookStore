using System;
using Volo.Abp.Application.Dtos;

namespace Hunter.BookStore.Categories
{
    public class CategoryLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}