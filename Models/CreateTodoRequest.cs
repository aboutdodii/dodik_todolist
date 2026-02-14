using System.ComponentModel.DataAnnotations;

namespace dodik_todolist.Models
{
    public class CreateTodoRequest
    {
        [Required]
        public string Title { get; set; } = string.Empty;
    }
}
