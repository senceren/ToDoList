using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Data
{
    public class UygulamaDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems => Set<TodoItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
             new TodoItem { Id = 1, Title = "Proje teklifini tamamla", Done = false },
             new TodoItem { Id = 2, Title = "Sunum slaytlarını hazırla", Done = false },
             new TodoItem { Id = 3, Title = "Kod değişikliklerini gözden geçir", Done = true },
             new TodoItem { Id = 4, Title = "Takip e-postalarını gönder", Done = true }
         );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localDB)\MSSQLLocalDB; database=TodoDb; trusted_connection=true;");
            
        }
    }
}
