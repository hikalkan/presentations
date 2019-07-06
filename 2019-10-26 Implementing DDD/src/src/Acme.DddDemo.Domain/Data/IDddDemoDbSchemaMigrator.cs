using System.Threading.Tasks;

namespace Acme.DddDemo.Data
{
    public interface IDddDemoDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
