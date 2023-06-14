using Microsoft.EntityFrameworkCore;
using my_books.Models;

namespace my_books.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }
        public  DbSet<Book> Books { get; set; }
        public DbSet <Publisher>Publishers { get; set; }
        public DbSet <Author>Authors { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
               .HasKey(ba => new { ba.BookId, ba.AuthorId });


            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(b => b.BookId);


            modelBuilder.Entity<Book_Author>()
                .HasOne(a => a.Author)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(a => a.AuthorId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
