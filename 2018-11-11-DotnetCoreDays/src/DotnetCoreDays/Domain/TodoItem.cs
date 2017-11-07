using System.ComponentModel.DataAnnotations;

namespace DotnetCoreDays.Domain
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Text { get; set; }
    }
}