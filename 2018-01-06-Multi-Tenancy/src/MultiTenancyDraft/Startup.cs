using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MultiTenancyDraft.Infrastructure;

namespace MultiTenancyDraft
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAuthentication()
                .AddCookie();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            app.UseMiddleware<MultiTenancyMiddleware>();

            app.UseMvcWithDefaultRoute();
        }
    }
}
