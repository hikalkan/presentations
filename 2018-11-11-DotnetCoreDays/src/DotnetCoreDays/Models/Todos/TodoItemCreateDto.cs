using System.ComponentModel.DataAnnotations;

namespace DotnetCoreDays.Models.Todos
{
    public class TodoItemCreateDto
    {
        [Required]
        [StringLength(256)]
        public string Text { get; set; }
    }
}