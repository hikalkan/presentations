using System.ComponentModel.DataAnnotations;

namespace DotnetCoreDays.Models
{
    public class TodoItemCreateDto
    {
        [Required]
        [StringLength(256)]
        public string Text { get; set; }
    }
}