using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ECommerce.Data;

/* This is used if database provider does't define
 * IECommerceDbSchemaMigrator implementation.
 */
public class NullECommerceDbSchemaMigrator : IECommerceDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
