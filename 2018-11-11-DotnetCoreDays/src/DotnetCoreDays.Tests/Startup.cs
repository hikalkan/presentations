using System;
using DotnetCoreDays.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetCoreDays.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var randomDatabaseName = Guid.NewGuid().ToString();

            services.AddDbContextPool<TodoDbContext>(builder =>
            {
                builder.UseInMemoryDatabase(randomDatabaseName);
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            SeedHelper.SeedData(app);
        }
    }
}
