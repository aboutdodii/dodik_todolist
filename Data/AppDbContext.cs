using Microsoft.EntityFrameworkCore;
using dodik_todolist.Models;

namespace dodik_todolist.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
