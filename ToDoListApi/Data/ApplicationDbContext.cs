
using Microsoft.EntityFrameworkCore;

namespace ToDoListApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var todos = new List<ToDoItem>
            {
                new ToDoItem {Id = 1, Title = "Morning exercise", Done = false },
                new ToDoItem {Id = 2, Title = "Read for 30 minutes", Done = false },
                new ToDoItem {Id = 3, Title = "Work on project tasks", Done = false },
                new ToDoItem {Id = 4, Title = "Lunch break", Done = false },
                new ToDoItem {Id = 5, Title = "Attend team meeting", Done = true },
                new ToDoItem {Id = 6, Title = "Complete work tasks", Done = true },
                new ToDoItem {Id = 7, Title = "Dinner", Done = true },
                new ToDoItem {Id = 8, Title = "Relax and unwind", Done = true },
            };
            modelBuilder.Entity<ToDoItem>().HasData(todos);
        }
    }
}
