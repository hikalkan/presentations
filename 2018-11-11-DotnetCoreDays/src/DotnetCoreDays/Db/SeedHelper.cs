using System.Linq;
using DotnetCoreDays.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetCoreDays.Db
{
    public class SeedHelper
    {
        public static void SeedData(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<TodoDbContext>();
                if (!dbContext.TodoItems.Any())
                {
                    dbContext.TodoItems.Add(new TodoItem {Text = "Create presentation for dotnet core days"});
                    dbContext.TodoItems.Add(new TodoItem {Text = "Prepare a sample application"});
                    dbContext.SaveChanges();
                }
            }
        }
    }
}