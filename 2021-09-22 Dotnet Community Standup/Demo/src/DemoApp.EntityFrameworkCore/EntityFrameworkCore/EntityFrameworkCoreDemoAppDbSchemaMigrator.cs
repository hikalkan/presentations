using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DemoApp.Data;
using Volo.Abp.DependencyInjection;

namespace DemoApp.EntityFrameworkCore
{
    public class EntityFrameworkCoreDemoAppDbSchemaMigrator
        : IDemoAppDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreDemoAppDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the DemoAppDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<DemoAppDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
