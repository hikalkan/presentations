using DotnetCoreDays.Db;
using DotnetCoreDays.Filters;
using DotnetCoreDays.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetCoreDays
{
    public class Startup
    {
        private readonly IConfigurationRoot _configuration;

        public Startup(IHostingEnvironment env)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<TodoDbContext>(builder =>
            {
                builder.UseSqlServer(_configuration.GetConnectionString("Default"));
            });

            services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer();

            services.AddMvc(options =>
            {
                options.Filters.Add<AuditFilter>();
            })
            .AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeFolder("/Admin");
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseMiddleware<AuditMiddleware>();

            app.UseStaticFiles();
            app.UseRequestLocalization();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();

            SeedHelper.SeedData(app);
        }
    }
}
