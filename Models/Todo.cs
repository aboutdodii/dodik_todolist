using System.ComponentModel.DataAnnotations;

namespace dodik_todolist.Models
{
    public class Todo
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public bool IsCompleted { get; set; } = false;

        public DateTime CreatedAt { get; set; }
    }
}
