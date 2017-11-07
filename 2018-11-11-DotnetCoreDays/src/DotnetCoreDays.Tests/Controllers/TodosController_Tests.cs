using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Parser.Html;
using DotnetCoreDays.Db;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace DotnetCoreDays.Tests.Controllers
{
    public class TodosController_Tests : TestBase
    {
        public TodosController_Tests()
        {
            
        }

        [Fact]
        public async Task Create()
        {
            //Act

            var response = await Client.PostAsync("/Todos", new StringContent("{ \"text\": \"MyTestTodo\"}", Encoding.UTF8, "application/json"));

            //Assert

            response.IsSuccessStatusCode.ShouldBeTrue();
            
            //Check returning HTML

            var result = await response.Content.ReadAsStringAsync();
            var htmlParser = new HtmlParser();
            var html = await htmlParser.ParseAsync(result);

            var li = html.QuerySelector("li");
            li.ShouldNotBeNull();

            var newTodoItemId = Convert.ToInt32(li.Attributes.GetNamedItem("data-id").Value);
            newTodoItemId.ShouldBeGreaterThan(0);

            li.QuerySelector(".todo-item-text").InnerHtml.Trim().ShouldBe("MyTestTodo");

            //Check data source

            UsingDbContext(context =>
            {
                var newItem = context.TodoItems.Find(newTodoItemId);
                newItem.Text.ShouldBe("MyTestTodo");
            });
        }

        [Fact]
        public async Task Delete()
        {
            //Act

            var response = await Client.DeleteAsync("/Todos/2");

            //Assert

            response.IsSuccessStatusCode.ShouldBeTrue();

            UsingDbContext(context =>
            {
                context.TodoItems.Find(2).ShouldBeNull();
            });
        }

        private void UsingDbContext(Action<TodoDbContext> action)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<TodoDbContext>();
                action(context);
                context.SaveChanges();
            }
        }
    }
}
