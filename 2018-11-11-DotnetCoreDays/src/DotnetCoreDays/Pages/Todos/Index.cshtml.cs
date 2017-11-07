using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using DotnetCoreDays.Db;
using DotnetCoreDays.Models;
using DotnetCoreDays.Models.Todos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotnetCoreDays.Pages.Todos
{
    public class IndexModel : PageModel
    {
        public IReadOnlyList<TodoItemDto> TodoItems { get; private set; }

        private readonly TodoDbContext _dbContext;

        public IndexModel(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task OnGetAsync()
        {
            var todoItems = await _dbContext.TodoItems.ToListAsync();

            TodoItems = todoItems
                .Select(t => new TodoItemDto
                {
                    Id = t.Id,
                    Text = t.Text
                })
                .ToImmutableList();
        }
    }
}