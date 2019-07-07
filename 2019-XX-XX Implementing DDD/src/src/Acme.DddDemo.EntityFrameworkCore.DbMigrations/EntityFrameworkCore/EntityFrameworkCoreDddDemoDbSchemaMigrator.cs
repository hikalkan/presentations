using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Acme.DddDemo.Data;
using Volo.Abp.DependencyInjection;

namespace Acme.DddDemo.EntityFrameworkCore
{
    [Dependency(ReplaceServices = true)]
    public class EntityFrameworkCoreDddDemoDbSchemaMigrator 
        : IDddDemoDbSchemaMigrator, ITransientDependency
    {
        private readonly DddDemoMigrationsDbContext _dbContext;

        public EntityFrameworkCoreDddDemoDbSchemaMigrator(DddDemoMigrationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigrateAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}