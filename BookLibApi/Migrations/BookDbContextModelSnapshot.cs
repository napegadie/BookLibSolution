﻿// <auto-generated />
using System;
using BookLibApi.DataStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookLibApi.Migrations
{
    [DbContext(typeof(BookDbContext))]
    partial class BookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookLibApi.Core.Entities.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            FirstName = "Ray",
                            LastName = "Dalio"
                        },
                        new
                        {
                            AuthorId = 2,
                            FirstName = "Rabbi Daniel",
                            LastName = "Lapin"
                        },
                        new
                        {
                            AuthorId = 3,
                            FirstName = "Bill",
                            LastName = "Gates"
                        },
                        new
                        {
                            AuthorId = 4,
                            FirstName = "Simon",
                            LastName = "Sinek"
                        },
                        new
                        {
                            AuthorId = 5,
                            FirstName = "Adam",
                            LastName = "Grant"
                        },
                        new
                        {
                            AuthorId = 6,
                            FirstName = "James",
                            LastName = "Clear"
                        },
                        new
                        {
                            AuthorId = 7,
                            FirstName = "Barack",
                            LastName = "Obama"
                        },
                        new
                        {
                            AuthorId = 8,
                            FirstName = "Dan",
                            LastName = "Heath"
                        },
                        new
                        {
                            AuthorId = 9,
                            FirstName = "Gene",
                            LastName = "Kim"
                        },
                        new
                        {
                            AuthorId = 10,
                            FirstName = "Satya",
                            LastName = "Nadella"
                        },
                        new
                        {
                            AuthorId = 11,
                            FirstName = "Jeffrey",
                            LastName = "Gitomer"
                        },
                        new
                        {
                            AuthorId = 12,
                            FirstName = "Malcolm",
                            LastName = "Gladwell"
                        },
                        new
                        {
                            AuthorId = 13,
                            FirstName = "Stephen",
                            LastName = "Meyer"
                        },
                        new
                        {
                            AuthorId = 14,
                            FirstName = "Kevin",
                            LastName = "Horsley"
                        },
                        new
                        {
                            AuthorId = 15,
                            FirstName = "Carol",
                            LastName = "Dweck"
                        },
                        new
                        {
                            AuthorId = 16,
                            FirstName = "Tony",
                            LastName = "Robbins"
                        },
                        new
                        {
                            AuthorId = 17,
                            FirstName = "David",
                            LastName = "Eagleman"
                        });
                });

            modelBuilder.Entity("BookLibApi.Core.Entities.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"), 1L, 1);

                    b.Property<string>("CoverUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DatePublished")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("GenreId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            CoverUrl = "",
                            DatePublished = new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Why Nations Succeed and Fail",
                            GenreId = 22,
                            PublisherId = 1,
                            Title = "Principles for Dealing with the Changing World Order"
                        },
                        new
                        {
                            BookId = 2,
                            CoverUrl = "",
                            DatePublished = new DateTime(2014, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Spiritual Success Strategies for Financial Abundance",
                            GenreId = 14,
                            PublisherId = 13,
                            Title = "Business Secrets from the Bible"
                        },
                        new
                        {
                            BookId = 3,
                            CoverUrl = "",
                            DatePublished = new DateTime(2021, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Solutions We Have and the Breakthroughs We Need",
                            GenreId = 18,
                            PublisherId = 14,
                            Title = "How to Avoid a Climate Disaster"
                        },
                        new
                        {
                            BookId = 4,
                            CoverUrl = "",
                            DatePublished = new DateTime(2009, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "How Great Leaders Inspire Everyone to Take Action",
                            GenreId = 22,
                            PublisherId = 15,
                            Title = "Start with Why"
                        },
                        new
                        {
                            BookId = 5,
                            CoverUrl = "",
                            DatePublished = new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Power of Knowing What You Don't Know",
                            GenreId = 22,
                            PublisherId = 16,
                            Title = "Think Again"
                        },
                        new
                        {
                            BookId = 6,
                            CoverUrl = "",
                            DatePublished = new DateTime(2018, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "An Easy & Proven Way to Build Good Habits & Break Bad Ones",
                            GenreId = 23,
                            PublisherId = 16,
                            Title = "Atomic Habits"
                        },
                        new
                        {
                            BookId = 7,
                            CoverUrl = "",
                            DatePublished = new DateTime(2020, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A Promised Land",
                            GenreId = 10,
                            PublisherId = 17,
                            Title = "A Promised Land"
                        },
                        new
                        {
                            BookId = 8,
                            CoverUrl = "",
                            DatePublished = new DateTime(2020, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Quest to Solve Problems Before They Happen",
                            GenreId = 22,
                            PublisherId = 1,
                            Title = "Upstream"
                        },
                        new
                        {
                            BookId = 9,
                            CoverUrl = "",
                            DatePublished = new DateTime(2013, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A Novel about IT, DevOps, and Helping Your Business Win",
                            GenreId = 22,
                            PublisherId = 18,
                            Title = "The Phoenix Project"
                        },
                        new
                        {
                            BookId = 10,
                            CoverUrl = "",
                            DatePublished = new DateTime(2017, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Quest to Rediscover Microsoft's Soul and Imagine a Better Future for Everyone",
                            GenreId = 10,
                            PublisherId = 19,
                            Title = "Hit Refresh"
                        },
                        new
                        {
                            BookId = 11,
                            CoverUrl = "",
                            DatePublished = new DateTime(2004, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "12.5 Principles of Sales Greatness",
                            GenreId = 22,
                            PublisherId = 20,
                            Title = "The Little Red Book of Selling"
                        },
                        new
                        {
                            BookId = 12,
                            CoverUrl = "",
                            DatePublished = new DateTime(2017, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Life and Work",
                            GenreId = 22,
                            PublisherId = 12,
                            Title = "Principles"
                        },
                        new
                        {
                            BookId = 13,
                            CoverUrl = "",
                            DatePublished = new DateTime(2009, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "DNA and the Evidence for Intelligent Design",
                            GenreId = 24,
                            PublisherId = 4,
                            Title = "Signature in the Cell"
                        },
                        new
                        {
                            BookId = 14,
                            CoverUrl = "",
                            DatePublished = new DateTime(2021, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "How to Use Advanced Learning Strategies to Learn Faster, Remember More and be More Productive",
                            GenreId = 22,
                            PublisherId = 5,
                            Title = "Unlimited Memory"
                        },
                        new
                        {
                            BookId = 15,
                            CoverUrl = "",
                            DatePublished = new DateTime(2008, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Story of Success",
                            GenreId = 22,
                            PublisherId = 6,
                            Title = "Outliers"
                        },
                        new
                        {
                            BookId = 16,
                            CoverUrl = "",
                            DatePublished = new DateTime(2013, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Underdogs, Misfits, and the Art of Battling Giants",
                            GenreId = 22,
                            PublisherId = 6,
                            Title = "David and Goliath"
                        },
                        new
                        {
                            BookId = 17,
                            CoverUrl = "",
                            DatePublished = new DateTime(2006, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The New Psychology of Success",
                            GenreId = 23,
                            PublisherId = 7,
                            Title = "Mindset"
                        },
                        new
                        {
                            BookId = 18,
                            CoverUrl = "",
                            DatePublished = new DateTime(2017, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Secret Lives of the Brain",
                            GenreId = 23,
                            PublisherId = 8,
                            Title = "Incognito"
                        },
                        new
                        {
                            BookId = 19,
                            CoverUrl = "",
                            DatePublished = new DateTime(2017, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "our Financial Freedom Playbook",
                            GenreId = 22,
                            PublisherId = 12,
                            Title = "Unshakeable"
                        },
                        new
                        {
                            BookId = 20,
                            CoverUrl = "",
                            DatePublished = new DateTime(2022, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "How New Breakthroughs in Precision Medicine Can Transform the Quality of Your Life & Those You Love",
                            GenreId = 23,
                            PublisherId = 12,
                            Title = "Life Force"
                        });
                });

            modelBuilder.Entity("BookLibApi.Core.Entities.Book_Author", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("Book_AuthorId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Book_Authors");

                    b.HasData(
                        new
                        {
                            BookId = 12,
                            AuthorId = 1,
                            Book_AuthorId = 1
                        },
                        new
                        {
                            BookId = 14,
                            AuthorId = 14,
                            Book_AuthorId = 2
                        },
                        new
                        {
                            BookId = 13,
                            AuthorId = 13,
                            Book_AuthorId = 3
                        },
                        new
                        {
                            BookId = 11,
                            AuthorId = 11,
                            Book_AuthorId = 4
                        },
                        new
                        {
                            BookId = 10,
                            AuthorId = 10,
                            Book_AuthorId = 5
                        },
                        new
                        {
                            BookId = 9,
                            AuthorId = 9,
                            Book_AuthorId = 6
                        },
                        new
                        {
                            BookId = 8,
                            AuthorId = 8,
                            Book_AuthorId = 7
                        },
                        new
                        {
                            BookId = 7,
                            AuthorId = 7,
                            Book_AuthorId = 8
                        },
                        new
                        {
                            BookId = 6,
                            AuthorId = 6,
                            Book_AuthorId = 9
                        },
                        new
                        {
                            BookId = 5,
                            AuthorId = 5,
                            Book_AuthorId = 10
                        },
                        new
                        {
                            BookId = 4,
                            AuthorId = 4,
                            Book_AuthorId = 11
                        },
                        new
                        {
                            BookId = 3,
                            AuthorId = 3,
                            Book_AuthorId = 12
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 2,
                            Book_AuthorId = 13
                        },
                        new
                        {
                            BookId = 1,
                            AuthorId = 1,
                            Book_AuthorId = 14
                        },
                        new
                        {
                            BookId = 15,
                            AuthorId = 12,
                            Book_AuthorId = 15
                        },
                        new
                        {
                            BookId = 16,
                            AuthorId = 12,
                            Book_AuthorId = 16
                        },
                        new
                        {
                            BookId = 19,
                            AuthorId = 16,
                            Book_AuthorId = 17
                        },
                        new
                        {
                            BookId = 20,
                            AuthorId = 16,
                            Book_AuthorId = 18
                        },
                        new
                        {
                            BookId = 18,
                            AuthorId = 17,
                            Book_AuthorId = 19
                        });
                });

            modelBuilder.Entity("BookLibApi.Core.Entities.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"), 1L, 1);

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            GenreName = "Fantasy"
                        },
                        new
                        {
                            GenreId = 2,
                            GenreName = "Adventure"
                        },
                        new
                        {
                            GenreId = 3,
                            GenreName = "Romance"
                        },
                        new
                        {
                            GenreId = 4,
                            GenreName = "Contemporary"
                        },
                        new
                        {
                            GenreId = 5,
                            GenreName = "Mystery"
                        },
                        new
                        {
                            GenreId = 6,
                            GenreName = "Horror"
                        },
                        new
                        {
                            GenreId = 7,
                            GenreName = "Thriller"
                        },
                        new
                        {
                            GenreId = 8,
                            GenreName = "Historical fiction"
                        },
                        new
                        {
                            GenreId = 9,
                            GenreName = "Science Fiction"
                        },
                        new
                        {
                            GenreId = 10,
                            GenreName = "Biographies & Memoirs"
                        },
                        new
                        {
                            GenreId = 11,
                            GenreName = "Children"
                        },
                        new
                        {
                            GenreId = 12,
                            GenreName = "Cooking"
                        },
                        new
                        {
                            GenreId = 13,
                            GenreName = "Art"
                        },
                        new
                        {
                            GenreId = 14,
                            GenreName = "Self-help"
                        },
                        new
                        {
                            GenreId = 15,
                            GenreName = "Development"
                        },
                        new
                        {
                            GenreId = 16,
                            GenreName = "Motivational"
                        },
                        new
                        {
                            GenreId = 17,
                            GenreName = "Health"
                        },
                        new
                        {
                            GenreId = 18,
                            GenreName = "History"
                        },
                        new
                        {
                            GenreId = 19,
                            GenreName = "Travel"
                        },
                        new
                        {
                            GenreId = 20,
                            GenreName = "Humor"
                        },
                        new
                        {
                            GenreId = 21,
                            GenreName = "Families & Relationships"
                        },
                        new
                        {
                            GenreId = 22,
                            GenreName = "Business & Money"
                        },
                        new
                        {
                            GenreId = 23,
                            GenreName = "Health, Fitness & Dieting"
                        },
                        new
                        {
                            GenreId = 24,
                            GenreName = "Christian Books & Bibles"
                        });
                });

            modelBuilder.Entity("BookLibApi.Core.Entities.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PublisherId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PublisherId");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            PublisherId = 1,
                            Name = "Avid Reader Press"
                        },
                        new
                        {
                            PublisherId = 2,
                            Name = "Pearson"
                        },
                        new
                        {
                            PublisherId = 3,
                            Name = "RELX Group"
                        },
                        new
                        {
                            PublisherId = 4,
                            Name = "HarperOne"
                        },
                        new
                        {
                            PublisherId = 5,
                            Name = "TCK Publishing"
                        },
                        new
                        {
                            PublisherId = 6,
                            Name = "Little, Brown & Co."
                        },
                        new
                        {
                            PublisherId = 7,
                            Name = "Random House"
                        },
                        new
                        {
                            PublisherId = 8,
                            Name = "Pantheon"
                        },
                        new
                        {
                            PublisherId = 9,
                            Name = "Bertelsmann"
                        },
                        new
                        {
                            PublisherId = 10,
                            Name = "Scholastic Corporation"
                        },
                        new
                        {
                            PublisherId = 11,
                            Name = "McGraw-Hill Education"
                        },
                        new
                        {
                            PublisherId = 12,
                            Name = "Simon & Schuster"
                        },
                        new
                        {
                            PublisherId = 13,
                            Name = "Wiley"
                        },
                        new
                        {
                            PublisherId = 14,
                            Name = "Knopf"
                        },
                        new
                        {
                            PublisherId = 15,
                            Name = "Portfolio"
                        },
                        new
                        {
                            PublisherId = 21,
                            Name = "Viking"
                        },
                        new
                        {
                            PublisherId = 16,
                            Name = "Avery"
                        },
                        new
                        {
                            PublisherId = 17,
                            Name = "Crown"
                        },
                        new
                        {
                            PublisherId = 18,
                            Name = "IT Revolution Press"
                        },
                        new
                        {
                            PublisherId = 19,
                            Name = "Harper Business"
                        },
                        new
                        {
                            PublisherId = 20,
                            Name = "Bard Press"
                        });
                });

            modelBuilder.Entity("BookLibApi.Core.Entities.Book", b =>
                {
                    b.HasOne("BookLibApi.Core.Entities.Genre", "BookGenre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookLibApi.Core.Entities.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookGenre");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("BookLibApi.Core.Entities.Book_Author", b =>
                {
                    b.HasOne("BookLibApi.Core.Entities.Author", "Author")
                        .WithMany("Book_Authors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookLibApi.Core.Entities.Book", "Book")
                        .WithMany("Book_Authors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookLibApi.Core.Entities.Author", b =>
                {
                    b.Navigation("Book_Authors");
                });

            modelBuilder.Entity("BookLibApi.Core.Entities.Book", b =>
                {
                    b.Navigation("Book_Authors");
                });

            modelBuilder.Entity("BookLibApi.Core.Entities.Genre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookLibApi.Core.Entities.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
