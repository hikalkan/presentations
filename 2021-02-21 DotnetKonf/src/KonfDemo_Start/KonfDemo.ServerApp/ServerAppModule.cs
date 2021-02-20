using KonfDemo.ServerApp.EfCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace KonfDemo.ServerApp
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpAutofacModule)
        )]
    public class ServerAppModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DemoDbContext>(options =>
            {
                options.AddDefaultRepositories();
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            context.Services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                });

            Configure<AbpAntiForgeryOptions>(options =>
            {
                options.AutoValidate = false;
            });

            context.Services.AddCors(options =>
            {
                options.AddPolicy("DefaultCors", builder =>
                {
                    builder
                        .WithOrigins("https://localhost:44304")
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("DefaultCors");
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo API");
            });
            app.UseConfiguredEndpoints();
        }
    }
}
