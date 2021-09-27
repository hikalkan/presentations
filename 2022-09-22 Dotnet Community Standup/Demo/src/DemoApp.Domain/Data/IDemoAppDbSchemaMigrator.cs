using System.Threading.Tasks;

namespace DemoApp.Data
{
    public interface IDemoAppDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
