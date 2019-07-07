using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Acme.DddDemo.Data
{
    /* This is used if database provider does't define
     * IDddDemoDbSchemaMigrator implementation.
     */
    public class NullDddDemoDbSchemaMigrator : IDddDemoDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}