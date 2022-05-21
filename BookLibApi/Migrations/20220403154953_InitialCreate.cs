using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CoverUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book_Authors",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Book_AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Authors", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_Book_Authors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Authors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Ray", "Dalio" },
                    { 2, "Rabbi Daniel", "Lapin" },
                    { 3, "Bill", "Gates" },
                    { 4, "Simon", "Sinek" },
                    { 5, "Adam", "Grant" },
                    { 6, "James", "Clear" },
                    { 7, "Barack", "Obama" },
                    { 8, "Dan", "Heath" },
                    { 9, "Gene", "Kim" },
                    { 10, "Satya", "Nadella" },
                    { 11, "Jeffrey", "Gitomer" },
                    { 12, "Malcolm", "Gladwell" },
                    { 13, "Stephen", "Meyer" },
                    { 14, "Kevin", "Horsley" },
                    { 15, "Carol", "Dweck" },
                    { 16, "Tony", "Robbins" },
                    { 17, "David", "Eagleman" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "GenreName" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "Adventure" },
                    { 3, "Romance" },
                    { 4, "Contemporary" },
                    { 5, "Mystery" },
                    { 6, "Horror" },
                    { 7, "Thriller" },
                    { 8, "Historical fiction" },
                    { 9, "Science Fiction" },
                    { 10, "Biographies & Memoirs" },
                    { 11, "Children" },
                    { 12, "Cooking" },
                    { 13, "Art" },
                    { 14, "Self-help" },
                    { 15, "Development" },
                    { 16, "Motivational" },
                    { 17, "Health" },
                    { 18, "History" },
                    { 19, "Travel" },
                    { 20, "Humor" },
                    { 21, "Families & Relationships" },
                    { 22, "Business & Money" },
                    { 23, "Health, Fitness & Dieting" },
                    { 24, "Christian Books & Bibles" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "Name" },
                values: new object[] { 1, "Avid Reader Press" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "Name" },
                values: new object[,]
                {
                    { 2, "Pearson" },
                    { 3, "RELX Group" },
                    { 4, "HarperOne" },
                    { 5, "TCK Publishing" },
                    { 6, "Little, Brown & Co." },
                    { 7, "Random House" },
                    { 8, "Pantheon" },
                    { 9, "Bertelsmann" },
                    { 10, "Scholastic Corporation" },
                    { 11, "McGraw-Hill Education" },
                    { 12, "Simon & Schuster" },
                    { 13, "Wiley" },
                    { 14, "Knopf" },
                    { 15, "Portfolio" },
                    { 16, "Avery" },
                    { 17, "Crown" },
                    { 18, "IT Revolution Press" },
                    { 19, "Harper Business" },
                    { 20, "Bard Press" },
                    { 21, "Viking" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverUrl", "DatePublished", "Description", "GenreId", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Why Nations Succeed and Fail", 22, 1, "Principles for Dealing with the Changing World Order" },
                    { 2, "", new DateTime(2014, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spiritual Success Strategies for Financial Abundance", 14, 13, "Business Secrets from the Bible" },
                    { 3, "", new DateTime(2021, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Solutions We Have and the Breakthroughs We Need", 18, 14, "How to Avoid a Climate Disaster" },
                    { 4, "", new DateTime(2009, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "How Great Leaders Inspire Everyone to Take Action", 22, 15, "Start with Why" },
                    { 5, "", new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Power of Knowing What You Don't Know", 22, 16, "Think Again" },
                    { 6, "", new DateTime(2018, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "An Easy & Proven Way to Build Good Habits & Break Bad Ones", 23, 16, "Atomic Habits" },
                    { 7, "", new DateTime(2020, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Promised Land", 10, 17, "A Promised Land" },
                    { 8, "", new DateTime(2020, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Quest to Solve Problems Before They Happen", 22, 1, "Upstream" },
                    { 9, "", new DateTime(2013, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Novel about IT, DevOps, and Helping Your Business Win", 22, 18, "The Phoenix Project" },
                    { 10, "", new DateTime(2017, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Quest to Rediscover Microsoft's Soul and Imagine a Better Future for Everyone", 10, 19, "Hit Refresh" },
                    { 11, "", new DateTime(2004, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "12.5 Principles of Sales Greatness", 22, 20, "The Little Red Book of Selling" },
                    { 12, "", new DateTime(2017, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Life and Work", 22, 12, "Principles" },
                    { 13, "", new DateTime(2009, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "DNA and the Evidence for Intelligent Design", 24, 4, "Signature in the Cell" },
                    { 14, "", new DateTime(2021, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "How to Use Advanced Learning Strategies to Learn Faster, Remember More and be More Productive", 22, 5, "Unlimited Memory" },
                    { 15, "", new DateTime(2008, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Story of Success", 22, 6, "Outliers" },
                    { 16, "", new DateTime(2013, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Underdogs, Misfits, and the Art of Battling Giants", 22, 6, "David and Goliath" },
                    { 17, "", new DateTime(2006, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "The New Psychology of Success", 23, 7, "Mindset" },
                    { 18, "", new DateTime(2017, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Secret Lives of the Brain", 23, 8, "Incognito" },
                    { 19, "", new DateTime(2017, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "our Financial Freedom Playbook", 22, 12, "Unshakeable" },
                    { 20, "", new DateTime(2022, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "How New Breakthroughs in Precision Medicine Can Transform the Quality of Your Life & Those You Love", 23, 12, "Life Force" }
                });

            migrationBuilder.InsertData(
                table: "Book_Authors",
                columns: new[] { "AuthorId", "BookId", "Book_AuthorId" },
                values: new object[,]
                {
                    { 1, 1, 14 },
                    { 2, 2, 13 },
                    { 3, 3, 12 },
                    { 4, 4, 11 },
                    { 5, 5, 10 },
                    { 6, 6, 9 },
                    { 7, 7, 8 },
                    { 8, 8, 7 },
                    { 9, 9, 6 },
                    { 10, 10, 5 },
                    { 11, 11, 4 },
                    { 1, 12, 1 },
                    { 13, 13, 3 },
                    { 14, 14, 2 },
                    { 12, 15, 15 },
                    { 12, 16, 16 },
                    { 17, 18, 19 },
                    { 16, 19, 17 },
                    { 16, 20, 18 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_Authors_AuthorId",
                table: "Book_Authors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book_Authors");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
