using System.Threading.Tasks;
using DotnetCoreDays.Db;
using DotnetCoreDays.Domain;
using DotnetCoreDays.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreDays.Controllers
{
    [Route("[controller]")]
    public class TodosController : Controller
    {
        private readonly TodoDbContext _dbContext;

        public TodosController(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TodoItemCreateDto input)
        {
            var todoItem = new TodoItem { Text = input.Text };

            _dbContext.TodoItems.Add(todoItem);

            await _dbContext.SaveChangesAsync();

            return PartialView("~/Pages/Todos/_TodoItemOnList.cshtml", new TodoItemDto
            {
                Id = todoItem.Id,
                Text = todoItem.Text
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task Delete(int id)
        {
            var todoItem = await _dbContext.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return;
            }

            _dbContext.TodoItems.Remove(todoItem);

            await _dbContext.SaveChangesAsync();
        }
    }
}
