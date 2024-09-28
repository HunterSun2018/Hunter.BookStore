using System;
using System.Collections.Generic;
using System.Text;
using Hunter.BookStore.Localization;
using Volo.Abp.Application.Services;

namespace Hunter.BookStore;

/* Inherit your application services from this class.
 */
public abstract class BookStoreAppService : ApplicationService
{
    protected BookStoreAppService()
    {
        LocalizationResource = typeof(BookStoreResource);
    }
}
