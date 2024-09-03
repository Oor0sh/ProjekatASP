using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace aspPopravni.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UseCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseCases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PublicationYear = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolesUseCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UseCaseId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUseCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesUseCases_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolesUseCases_UseCases_UseCaseId",
                        column: x => x.UseCaseId,
                        principalTable: "UseCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BooksGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksGenres_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BooksGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LibrariesBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibrariesBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibrariesBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibrariesBooks_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Returned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UseCaseLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UseCaseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IsLoggedIn = table.Column<bool>(type: "bit", nullable: false),
                    UseCaseData = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseCaseLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UseCaseLogs_UseCases_UseCaseId",
                        column: x => x.UseCaseId,
                        principalTable: "UseCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UseCaseLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoanItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanItems_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DeletedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "J. K. Rowling" },
                    { 2, null, null, "Stephenie Meyer" },
                    { 3, null, null, "Suzanne Collins" },
                    { 4, null, null, "C. S. Lewis" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "DeletedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Drama" },
                    { 2, null, null, "Fantasy" },
                    { 3, null, null, "Action" },
                    { 4, null, null, "Romance" },
                    { 5, null, null, "Adventure" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "DeletedAt", "ModifiedAt", "Source" },
                values: new object[] { 1, null, null, "default.png" });

            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "Address", "City", "DeletedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, "13 Cornelia Street", "London", null, null, "The British Library" },
                    { 2, "12 Philimore Walk", "London", null, null, "Kensington Central Library" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DeletedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Admin" },
                    { 2, null, null, "User" }
                });

            migrationBuilder.InsertData(
                table: "UseCases",
                columns: new[] { "Id", "DeletedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Search Books" },
                    { 2, null, null, "Search Users" },
                    { 3, null, null, "Search Loans" },
                    { 4, null, null, "Search Returns" },
                    { 5, null, null, "Check Book Availability" },
                    { 6, null, null, "Register User" },
                    { 7, null, null, "Create Book" },
                    { 8, null, null, "Create Loan" },
                    { 10, null, null, "Update Book" },
                    { 11, null, null, "Delete Loan" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "DeletedAt", "Description", "ImageId", "ModifiedAt", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { 1, 1, null, "Harry Potter and the Deathly Hallows is a fantasy novel written by British author J.K. Rowling and the seventh and final novel in the Harry Potter series.", null, null, "2010", "Harry Potter and the Deathly Hallows" },
                    { 2, 2, null, "New Moon is a 2006 romantic fantasy novel by author Stephenie Meyer. The second installment in the Twilight series, the novel continues the story of Bella Swan and her relationship with vampire Edward Cullen as she enters her senior year of high school.", null, null, "2006", "Twilight: New Moon" },
                    { 3, 3, null, "Catching Fire is a 2009 dystopian young adult fiction novel by the American novelist Suzanne Collins, the second book in The Hunger Games series.", null, null, "2009", "The Hunger Games: Catching Fire" },
                    { 4, 3, null, "The Ballad of Songbirds and Snakes is a dystopian action-adventure novel written by the American author Suzanne Collins. It is the prequel to the original The Hunger Games trilogy, set 64 years before the events of the first novel.", null, null, "2020", "The Hunger Games: The Ballad of Songbirds and Snakes" },
                    { 5, 4, null, "The Last Battle is a portal fantasy novel for children by C.S. Lewis, published by The Bodley Head in 1956. It is the seventh and final novel in The Chronicles of Narnia.", null, null, "1956", "The Last Battle" },
                    { 6, 1, null, "Harry Potter and the Prisoner of Azkaban is a fantasy novel written by the British author J.K. Rowling. It is the third installment in the Harry Potter series.", null, null, "1999", "Harry Potter and the Prisoner of Azkaban" }
                });

            migrationBuilder.InsertData(
                table: "RolesUseCases",
                columns: new[] { "Id", "DeletedAt", "ModifiedAt", "RoleId", "UseCaseId" },
                values: new object[,]
                {
                    { 1, null, null, 1, 1 },
                    { 2, null, null, 1, 2 },
                    { 3, null, null, 1, 3 },
                    { 4, null, null, 1, 4 },
                    { 5, null, null, 1, 5 },
                    { 6, null, null, 1, 6 },
                    { 7, null, null, 1, 7 },
                    { 8, null, null, 1, 8 },
                    { 9, null, null, 1, 10 },
                    { 10, null, null, 1, 11 },
                    { 11, null, null, 2, 1 },
                    { 12, null, null, 2, 8 },
                    { 13, null, null, 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DeletedAt", "Email", "FirstName", "LastName", "ModifiedAt", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, null, "user@library.com", "John", "Doe", null, "$2a$10$IFPpQn5B8X7T8EhowZx8Aug/ngeKL7nhalqc1jYiguxUqWBuVDzsO", 2 },
                    { 2, null, "admin@library.com", "Jane", "Doe", null, "$2a$10$ulHXgDNfep55h43CnZfg6.hYN/OF3N2Ling1uzYmzpucYqtRUQAH2", 1 }
                });

            migrationBuilder.InsertData(
                table: "BooksGenres",
                columns: new[] { "Id", "BookId", "DeletedAt", "GenreId", "ModifiedAt" },
                values: new object[,]
                {
                    { 1, 2, null, 2, null },
                    { 2, 2, null, 4, null },
                    { 3, 5, null, 2, null },
                    { 4, 5, null, 5, null },
                    { 5, 3, null, 1, null },
                    { 6, 3, null, 2, null },
                    { 7, 3, null, 5, null },
                    { 8, 4, null, 1, null },
                    { 9, 4, null, 2, null },
                    { 10, 4, null, 5, null },
                    { 11, 6, null, 1, null },
                    { 12, 6, null, 2, null },
                    { 13, 6, null, 5, null },
                    { 14, 1, null, 5, null },
                    { 15, 1, null, 1, null }
                });

            migrationBuilder.InsertData(
                table: "LibrariesBooks",
                columns: new[] { "Id", "BookId", "DeletedAt", "LibraryId", "ModifiedAt" },
                values: new object[,]
                {
                    { 1, 1, null, 1, null },
                    { 2, 2, null, 1, null },
                    { 3, 4, null, 1, null },
                    { 4, 3, null, 1, null },
                    { 5, 1, null, 2, null },
                    { 6, 6, null, 2, null },
                    { 7, 4, null, 2, null },
                    { 8, 5, null, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "DeletedAt", "ModifiedAt", "Returned", "UserId" },
                values: new object[] { 1, null, null, null, 1 });

            migrationBuilder.InsertData(
                table: "LoanItems",
                columns: new[] { "Id", "BookId", "DeletedAt", "LoanId", "ModifiedAt" },
                values: new object[,]
                {
                    { 1, 3, null, 1, null },
                    { 2, 2, null, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Name",
                table: "Authors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ImageId",
                table: "Books",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksGenres_BookId",
                table: "BooksGenres",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksGenres_GenreId",
                table: "BooksGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LibrariesBooks_BookId",
                table: "LibrariesBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LibrariesBooks_LibraryId",
                table: "LibrariesBooks",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanItems_BookId",
                table: "LoanItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanItems_LoanId",
                table: "LoanItems",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                table: "Loans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolesUseCases_RoleId",
                table: "RolesUseCases",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesUseCases_UseCaseId",
                table: "RolesUseCases",
                column: "UseCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UseCaseLogs_UseCaseId",
                table: "UseCaseLogs",
                column: "UseCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UseCaseLogs_UserId",
                table: "UseCaseLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksGenres");

            migrationBuilder.DropTable(
                name: "LibrariesBooks");

            migrationBuilder.DropTable(
                name: "LoanItems");

            migrationBuilder.DropTable(
                name: "RolesUseCases");

            migrationBuilder.DropTable(
                name: "UseCaseLogs");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Libraries");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "UseCases");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
