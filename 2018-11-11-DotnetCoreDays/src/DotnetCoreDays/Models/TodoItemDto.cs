using System.ComponentModel.DataAnnotations;

namespace DotnetCoreDays.Models
{
    public class TodoItemDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Text { get; set; }
    }
}