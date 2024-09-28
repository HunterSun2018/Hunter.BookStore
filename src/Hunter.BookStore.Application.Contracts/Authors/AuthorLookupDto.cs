using System;
using Volo.Abp.Application.Dtos;

namespace Hunter.BookStore.Authors
{
    public class AuthorLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}