using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MultiTenancyDraft.Infrastructure
{
    public static class MultiTenantDbContextServiceCollectionExtensions
    {
        public static void AddMultiTenantDbContext<TDbContext>(
            this IServiceCollection services, 
            Action<DbContextOptionsBuilder<TDbContext>, string> optionsBuilder) 
            where TDbContext : DbContext
        {
            services.AddDbContext<TDbContext>();

            services.AddTransient(serviceProvider =>
            {
                var connString = GetConnectionString(serviceProvider);

                var builder = new DbContextOptionsBuilder<TDbContext>();
                optionsBuilder(builder, connString);
                return builder.Options;
            });
        }

        private static string GetConnectionString(IServiceProvider serviceProvider) 
        {
            if (TenantInfo.Current == null)
            {
                return GetDefaultConnectionString();
            }

            var tenantStore = serviceProvider.GetRequiredService<ITenantStore>();
            return tenantStore.FindConnectionString(TenantInfo.Current.Id) ??
                   GetDefaultConnectionString();
        }

        public static string GetDefaultConnectionString()
        {
            return "Server=localhost;Database=MultiTenancyDraft;Trusted_Connection=True;MultipleActiveResultSets=true";
        }
    }
}