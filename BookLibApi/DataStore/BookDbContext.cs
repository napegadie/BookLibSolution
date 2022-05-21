using BookLibApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLibApi.DataStore
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> opt) : base(opt)
        {

        }

        public DbSet<Author>? Authors { get; set; } = null!;
        public DbSet<Book>? Books { get; set; } = null!;
        public DbSet<Genre>? Genres { get; set; } = null!;
        public DbSet<Publisher>? Publishers { get; set; } = null!;
        public DbSet<Book_Author>? Book_Authors { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            ManyToManyRelationship(builder);
            OneToManyRelationship(builder);

            base.OnModelCreating(builder);
            builder.Seed();
        }

        private void OneToManyRelationship(ModelBuilder builder)
        {

            // Relashionship between Genre and Book

            builder.Entity<Genre>()
                .HasMany(g => g.Books)
                .WithOne(b => b.BookGenre);
                

            builder.Entity<Book>()
                .HasOne(b => b.BookGenre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId);


            // Relashionship between Publisher and Book

            builder.Entity<Publisher>()
                .HasMany(p => p.Books)
                .WithOne(b => b.Publisher);
                

            builder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId);
        }

        private void ManyToManyRelationship(ModelBuilder builder)
        {
            // Relashionship between Book, Author and Book_Author

            builder.Entity<Book_Author>()
        .HasKey(ba => new { ba.BookId, ba.AuthorId });

            builder.Entity<Book_Author>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.Book_Authors)
                .HasForeignKey(ba => ba.BookId);

            builder.Entity<Book_Author>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.Book_Authors)
                .HasForeignKey(ba => ba.AuthorId);
        }
    }
}
