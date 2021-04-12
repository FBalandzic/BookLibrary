using Microsoft.EntityFrameworkCore;
using BookWebApp.Model;

namespace BookWebApp
{
    public class DBContext: DbContext
    {
        public DBContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./booksDB.db");
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }

    
}
