using System.Threading.Tasks;

namespace ECommerce.Data;

public interface IECommerceDbSchemaMigrator
{
    Task MigrateAsync();
}
