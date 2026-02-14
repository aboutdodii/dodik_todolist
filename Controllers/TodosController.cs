using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dodik_todolist.Data;
using dodik_todolist.Models;

namespace dodik_todolist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TodosController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/todos
        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo(CreateTodoRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var todo = new Todo
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            };

            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, todo);
        }

        // GET: api/todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetAllTodos()
        {
            var todos = await _context.Todos
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            return Ok(todos);
        }

        // GET: api/todos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodoById(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo == null)
                return NotFound();

            return Ok(todo);
        }

        // PUT: api/todos/{id}/complete
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteTodo(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo == null)
                return NotFound();

            todo.IsCompleted = true;
            await _context.SaveChangesAsync();

            return Ok(todo);
        }

        // DELETE: api/todos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo == null)
                return NotFound();

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
