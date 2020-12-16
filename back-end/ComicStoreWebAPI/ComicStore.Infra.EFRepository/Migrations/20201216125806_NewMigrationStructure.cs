using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicStore.Infra.EFRepository.Migrations
{
    public partial class NewMigrationStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "Comic",
                columns: table => new
                {
                    ComicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comic", x => x.ComicID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Line1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Line2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                    table.ForeignKey(
                            name: "FK_Users_Customer_UserID",
                            column: x => x.UserID,
                            principalSchema: "seg",
                            principalTable: "Users",
                            principalColumn: "id",
                            onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Line1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Line2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "AuthorComic",
                columns: table => new
                {
                    AuthorsAuthorID = table.Column<int>(type: "int", nullable: false),
                    ComicsComicID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorComic", x => new { x.AuthorsAuthorID, x.ComicsComicID });
                    table.ForeignKey(
                        name: "FK_AuthorComic_Author_AuthorsAuthorID",
                        column: x => x.AuthorsAuthorID,
                        principalTable: "Author",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorComic_Comic_ComicsComicID",
                        column: x => x.ComicsComicID,
                        principalTable: "Comic",
                        principalColumn: "ComicID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComicImage",
                columns: table => new
                {
                    ComicID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Base64 = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicImage", x => x.ComicID);
                    table.ForeignKey(
                        name: "FK_ComicImage_Comic_ComicID",
                        column: x => x.ComicID,
                        principalTable: "Comic",
                        principalColumn: "ComicID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComicInventory",
                columns: table => new
                {
                    ComicID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicInventory", x => x.ComicID);
                    table.ForeignKey(
                        name: "FK_ComicInventory_Comic_ComicID",
                        column: x => x.ComicID,
                        principalTable: "Comic",
                        principalColumn: "ComicID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComicGenre",
                columns: table => new
                {
                    ComicsComicID = table.Column<int>(type: "int", nullable: false),
                    GenresGenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicGenre", x => new { x.ComicsComicID, x.GenresGenreID });
                    table.ForeignKey(
                        name: "FK_ComicGenre_Comic_ComicsComicID",
                        column: x => x.ComicsComicID,
                        principalTable: "Comic",
                        principalColumn: "ComicID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComicGenre_Genre_GenresGenreID",
                        column: x => x.GenresGenreID,
                        principalTable: "Genre",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComicID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemID);
                    table.ForeignKey(
                        name: "FK_OrderItem_Comic_ComicID",
                        column: x => x.ComicID,
                        principalTable: "Comic",
                        principalColumn: "ComicID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "AuthorID", "Name" },
                values: new object[,]
                {
                    { 1, "John Doe" },
                    { 2, "Jane Doe" },
                    { 3, "Jim Starlin" },
                    { 4, "Gail Simone" },
                    { 5, "Warren Ellis" },
                    { 6, "Jack Kirby" },
                    { 7, "Jonathan Hickman" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreID", "Description" },
                values: new object[,]
                {
                    { 1, "Ação" },
                    { 2, "Aventura" },
                    { 3, "Drama" },
                    { 4, "Comedia" },
                    { 5, "Terror" },
                    { 6, "Guerra" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorComic_ComicsComicID",
                table: "AuthorComic",
                column: "ComicsComicID");

            migrationBuilder.CreateIndex(
                name: "IX_ComicGenre_GenresGenreID",
                table: "ComicGenre",
                column: "GenresGenreID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ComicID",
                table: "OrderItem",
                column: "ComicID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderID",
                table: "OrderItem",
                column: "OrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorComic");

            migrationBuilder.DropTable(
                name: "ComicGenre");

            migrationBuilder.DropTable(
                name: "ComicImage");

            migrationBuilder.DropTable(
                name: "ComicInventory");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Comic");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
