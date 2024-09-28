using System.Threading.Tasks;

namespace Hunter.BookStore.Data;

public interface IBookStoreDbSchemaMigrator
{
    Task MigrateAsync();
}
