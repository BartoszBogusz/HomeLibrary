using HomeLibrary.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeLibrary.Infrastructure
{
    public class HomeLibraryContext : IdentityDbContext
    {
        public HomeLibraryContext(DbContextOptions<HomeLibraryContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
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
