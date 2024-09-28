using Hunter.BookStore.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Hunter.BookStore.Blazor.Client;

public abstract class BookStoreComponentBase : AbpComponentBase
{
    protected BookStoreComponentBase()
    {
        LocalizationResource = typeof(BookStoreResource);
    }
}
