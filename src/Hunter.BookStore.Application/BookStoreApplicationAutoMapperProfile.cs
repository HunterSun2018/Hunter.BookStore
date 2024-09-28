using AutoMapper;
using Hunter.BookStore.Authors;
using Hunter.BookStore.Books;
using Hunter.BookStore.Categories;
using Volo.Abp.AutoMapper;

namespace Hunter.BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Category, CategoryDto>();
        CreateMap<Category, CategoryLookupDto>();
        CreateMap<CreateUpdateCategoryDto, Category>();

        CreateMap<Author, AuthorDto>();
        CreateMap<Author, AuthorLookupDto>();
        CreateMap<CreateUpdateAuthorDto, Author>();

        CreateMap<BookWithDetails, BookDto>();
    }
}
