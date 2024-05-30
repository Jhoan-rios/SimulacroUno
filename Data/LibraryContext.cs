using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryContext(DbContextOptions<LibraryContext> options) : DbContext(options)
    {
        
        public DbSet<Author> authors { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Edithorial> edithorials { get; set; }
    }
}