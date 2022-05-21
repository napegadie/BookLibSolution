using BookLibApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLibApi.DataStore
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Genre>().HasData(
                new Genre() { GenreId = 1, GenreName = "Fantasy" },
                new Genre() { GenreId = 2, GenreName = "Adventure" },
                new Genre() { GenreId = 3, GenreName = "Romance" },
                new Genre() { GenreId = 4, GenreName = "Contemporary" },
                new Genre() { GenreId = 5, GenreName = "Mystery" },
                new Genre() { GenreId = 6, GenreName = "Horror" },
                new Genre() { GenreId = 7, GenreName = "Thriller" },
                new Genre() { GenreId = 8, GenreName = "Historical fiction" },
                new Genre() { GenreId = 9, GenreName = "Science Fiction" },
                new Genre() { GenreId = 10, GenreName = "Biographies & Memoirs" },
                new Genre() { GenreId = 11, GenreName = "Children" },
                new Genre() { GenreId = 12, GenreName = "Cooking" },
                new Genre() { GenreId = 13, GenreName = "Art" },
                new Genre() { GenreId = 14, GenreName = "Self-help" },
                new Genre() { GenreId = 15, GenreName = "Development" },
                new Genre() { GenreId = 16, GenreName = "Motivational" },
                new Genre() { GenreId = 17, GenreName = "Health" },
                new Genre() { GenreId = 18, GenreName = "History" },
                new Genre() { GenreId = 19, GenreName = "Travel" },
                new Genre() { GenreId = 20, GenreName = "Humor" },
                new Genre() { GenreId = 21, GenreName = "Families & Relationships" },
                new Genre() { GenreId = 22, GenreName = "Business & Money" },
                new Genre() { GenreId = 23, GenreName = "Health, Fitness & Dieting" },
                new Genre() { GenreId = 24, GenreName = "Christian Books & Bibles" }
                );


            builder.Entity<Publisher>().HasData(
                new Publisher() { PublisherId = 1, Name = "Avid Reader Press" },
                new Publisher() { PublisherId = 2, Name = "Pearson" },
                new Publisher() { PublisherId = 3, Name = "RELX Group" },
                new Publisher() { PublisherId = 4, Name = "HarperOne" },
                new Publisher() { PublisherId = 5, Name = "TCK Publishing" },
                new Publisher() { PublisherId = 6, Name = "Little, Brown & Co." },
                new Publisher() { PublisherId = 7, Name = "Random House" },
                new Publisher() { PublisherId = 8, Name = "Pantheon" },
                new Publisher() { PublisherId = 9, Name = "Bertelsmann" },
                new Publisher() { PublisherId = 10, Name = "Scholastic Corporation" },
                new Publisher() { PublisherId = 11, Name = "McGraw-Hill Education" },
                new Publisher() { PublisherId = 12, Name = "Simon & Schuster" },
                new Publisher() { PublisherId = 13, Name = "Wiley" },
                new Publisher() { PublisherId = 14, Name = "Knopf" },
                new Publisher() { PublisherId = 15, Name = "Portfolio" },
                new Publisher() { PublisherId = 21, Name = "Viking" },
                new Publisher() { PublisherId = 16, Name = "Avery" },
                new Publisher() { PublisherId = 17, Name = "Crown" },
                new Publisher() { PublisherId = 18, Name = "IT Revolution Press" },
                new Publisher() { PublisherId = 19, Name = "Harper Business" },
                new Publisher() { PublisherId = 20, Name = "Bard Press" }
                );

            builder.Entity<Author>().HasData(
                new Author() { AuthorId = 1, FirstName = "Ray", LastName = "Dalio" },
                new Author() { AuthorId = 2, FirstName = "Rabbi Daniel", LastName = "Lapin" },
                new Author() { AuthorId = 3, FirstName = "Bill", LastName = "Gates" },
                new Author() { AuthorId = 4, FirstName = "Simon", LastName = "Sinek" },
                new Author() { AuthorId = 5, FirstName = "Adam", LastName = "Grant" },
                new Author() { AuthorId = 6, FirstName = "James", LastName = "Clear" },
                new Author() { AuthorId = 7, FirstName = "Barack", LastName = "Obama" },
                new Author() { AuthorId = 8, FirstName = "Dan", LastName = "Heath" },
                new Author() { AuthorId = 9, FirstName = "Gene", LastName = "Kim" },
                new Author() { AuthorId = 10, FirstName = "Satya", LastName = "Nadella" },
                new Author() { AuthorId = 11, FirstName = "Jeffrey", LastName = "Gitomer" },
                new Author() { AuthorId = 12, FirstName = "Malcolm", LastName = "Gladwell" },
                new Author() { AuthorId = 13, FirstName = "Stephen", LastName = "Meyer" },
                new Author() { AuthorId = 14, FirstName = "Kevin", LastName = "Horsley" },
                new Author() { AuthorId = 15, FirstName = "Carol", LastName = "Dweck" },
                new Author() { AuthorId = 16, FirstName = "Tony", LastName = "Robbins" },
                new Author() { AuthorId = 17, FirstName = "David", LastName = "Eagleman" }
                );


            builder.Entity<Book>().HasData(
                new Book() { BookId = 1, Title = "Principles for Dealing with the Changing World Order", Description = "Why Nations Succeed and Fail", DatePublished = new DateTime(2021, 11, 30), PublisherId = 1, GenreId = 22 },
                new Book() { BookId = 2, Title = "Business Secrets from the Bible", Description = "Spiritual Success Strategies for Financial Abundance", DatePublished = new DateTime(2014, 3, 3), PublisherId = 13, GenreId = 14 },
                new Book() { BookId = 3, Title = "How to Avoid a Climate Disaster", Description = "The Solutions We Have and the Breakthroughs We Need", DatePublished = new DateTime(2021, 2, 16), PublisherId = 14, GenreId = 18 },
                new Book() { BookId = 4, Title = "Start with Why", Description = "How Great Leaders Inspire Everyone to Take Action", DatePublished = new DateTime(2009, 10, 29), PublisherId = 15, GenreId = 22 },
                new Book() { BookId = 5, Title = "Think Again", Description = "The Power of Knowing What You Don't Know", DatePublished = new DateTime(2021, 2, 2), PublisherId = 16, GenreId = 22 },
                new Book() { BookId = 6, Title = "Atomic Habits", Description = "An Easy & Proven Way to Build Good Habits & Break Bad Ones", DatePublished = new DateTime(2018, 10, 16), PublisherId = 16, GenreId = 23 },
                new Book() { BookId = 7, Title = "A Promised Land", Description = "A Promised Land", DatePublished = new DateTime(2020, 11, 17), PublisherId = 17, GenreId = 10 },
                new Book() { BookId = 8, Title = "Upstream", Description = "The Quest to Solve Problems Before They Happen", DatePublished = new DateTime(2020, 11, 17), PublisherId = 1, GenreId = 22 },
                new Book() { BookId = 9, Title = "The Phoenix Project", Description = "A Novel about IT, DevOps, and Helping Your Business Win", DatePublished = new DateTime(2013, 1, 10), PublisherId = 18, GenreId = 22 },
                new Book() { BookId = 10, Title = "Hit Refresh", Description = "The Quest to Rediscover Microsoft's Soul and Imagine a Better Future for Everyone", DatePublished = new DateTime(2017, 9, 26), PublisherId = 19, GenreId = 10 },
                new Book() { BookId = 11, Title = "The Little Red Book of Selling", Description = "12.5 Principles of Sales Greatness", DatePublished = new DateTime(2004, 9, 25), PublisherId = 20, GenreId = 22 },
                new Book() { BookId = 12, Title = "Principles", Description = "Life and Work", DatePublished = new DateTime(2017, 9, 19), PublisherId = 12, GenreId = 22 },
                new Book() { BookId = 13, Title = "Signature in the Cell", Description = "DNA and the Evidence for Intelligent Design", DatePublished = new DateTime(2009, 6, 23), PublisherId = 4, GenreId = 24 },
                new Book() { BookId = 14, Title = "Unlimited Memory", Description = "How to Use Advanced Learning Strategies to Learn Faster, Remember More and be More Productive", DatePublished = new DateTime(2021, 8, 13), PublisherId = 5, GenreId = 22 },
                new Book() { BookId = 15, Title = "Outliers", Description = "The Story of Success", DatePublished = new DateTime(2008, 11, 18), PublisherId = 6, GenreId = 22 },
                new Book() { BookId = 16, Title = "David and Goliath", Description = "Underdogs, Misfits, and the Art of Battling Giants", DatePublished = new DateTime(2013, 10, 15), PublisherId = 6, GenreId = 22 },
                new Book() { BookId = 17, Title = "Mindset", Description = "The New Psychology of Success", DatePublished = new DateTime(2006, 2, 28), PublisherId = 7, GenreId = 23 },
                new Book() { BookId = 18, Title = "Incognito", Description = "The Secret Lives of the Brain", DatePublished = new DateTime(2017, 9, 19), PublisherId = 8, GenreId = 23 },
                new Book() { BookId = 19, Title = "Unshakeable", Description = "our Financial Freedom Playbook", DatePublished = new DateTime(2017, 2, 28), PublisherId = 12, GenreId = 22 },
                new Book() { BookId = 20, Title = "Life Force", Description = "How New Breakthroughs in Precision Medicine Can Transform the Quality of Your Life & Those You Love", DatePublished = new DateTime(2022, 2, 8), PublisherId = 12, GenreId = 23 }
                );


            builder.Entity<Book_Author>().HasData(
                new Book_Author() { Book_AuthorId = 1, BookId = 12, AuthorId = 1 },
                new Book_Author() { Book_AuthorId = 2, BookId = 14, AuthorId = 14 },
                new Book_Author() { Book_AuthorId = 3, BookId = 13, AuthorId = 13 },
                new Book_Author() { Book_AuthorId = 4, BookId = 11, AuthorId = 11 },
                new Book_Author() { Book_AuthorId = 5, BookId = 10, AuthorId = 10 },
                new Book_Author() { Book_AuthorId = 6, BookId = 9, AuthorId = 9 },
                new Book_Author() { Book_AuthorId = 7, BookId = 8, AuthorId = 8 },
                new Book_Author() { Book_AuthorId = 8, BookId = 7, AuthorId = 7 },
                new Book_Author() { Book_AuthorId = 9, BookId = 6, AuthorId = 6 },
                new Book_Author() { Book_AuthorId = 10, BookId = 5, AuthorId = 5 },
                new Book_Author() { Book_AuthorId = 11, BookId = 4, AuthorId = 4 },
                new Book_Author() { Book_AuthorId = 12, BookId = 3, AuthorId = 3 },
                new Book_Author() { Book_AuthorId = 13, BookId = 2, AuthorId = 2 },
                new Book_Author() { Book_AuthorId = 14, BookId = 1, AuthorId = 1 },
                new Book_Author() { Book_AuthorId = 15, BookId = 15, AuthorId = 12 },
                new Book_Author() { Book_AuthorId = 16, BookId = 16, AuthorId = 12 },
                new Book_Author() { Book_AuthorId = 17, BookId = 19, AuthorId = 16 },
                new Book_Author() { Book_AuthorId = 18, BookId = 20, AuthorId = 16 },
                new Book_Author() { Book_AuthorId = 19, BookId = 18, AuthorId = 17 }
                );
        }
        
    }
}
