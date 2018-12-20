using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiTenancyDraft.Application;
using MultiTenancyDraft.Infrastructure;

namespace MultiTenancyDraft
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAuthentication().AddCookie();

            services.AddMultiTenantDbContext<MyDbContext>((options, connString) =>
            {
                options.UseSqlServer(connString);
            });

            services.AddTransient<ITenantStore, TenantStore>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();

            app.UseMiddleware<MultiTenancyMiddleware>();

            app.UseMvcWithDefaultRoute();
        }
    }
}
