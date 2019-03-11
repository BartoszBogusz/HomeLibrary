using HomeLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeLibrary.Infrastructure
{
    public class HomeLibraryContext : DbContext
    {
        public HomeLibraryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasKey(x => x.BookId);
            modelBuilder.Entity<Book>()
                .Property(x => x.BookId)
                .ValueGeneratedOnAdd();
        }
    }
}
