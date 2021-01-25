using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicStore.Infra.EFRepository.Migrations
{
    public partial class ResetMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
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
                    UserID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Line1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Line2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Neighborhood = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
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
                    Neighborhood = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    PaymentMethodID = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "ComicAuthor",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    ComicID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicAuthor", x => new { x.AuthorID, x.ComicID });
                    table.ForeignKey(
                        name: "FK_ComicAuthor_Author_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Author",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComicAuthor_Comic_ComicID",
                        column: x => x.ComicID,
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
                    ComicID = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicGenre", x => new { x.ComicID, x.GenreID });
                    table.ForeignKey(
                        name: "FK_ComicGenre_Comic_ComicID",
                        column: x => x.ComicID,
                        principalTable: "Comic",
                        principalColumn: "ComicID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComicGenre_Genre_GenreID",
                        column: x => x.GenreID,
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
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitValue = table.Column<float>(type: "real", nullable: false),
                    TotalValue = table.Column<float>(type: "real", nullable: false)
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
                columns: new[] { "AuthorID", "BirthDate", "Name", "Nationality" },
                values: new object[,]
                {
                    { 1, new DateTime(2008, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", "Australian" },
                    { 2, new DateTime(1995, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Doe", "Dominican" },
                    { 3, new DateTime(2013, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JK Rowling", "English" },
                    { 4, new DateTime(2004, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gail Simone", "Mexican" },
                    { 5, new DateTime(2011, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warren Ellis", "French" },
                    { 6, new DateTime(2011, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jack Kirby", "Indonesian" },
                    { 7, new DateTime(2018, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jonathan Hickman", "Indian" }
                });

            migrationBuilder.InsertData(
                table: "Comic",
                columns: new[] { "ComicID", "Description", "Pages", "Price", "Title", "Year" },
                values: new object[,]
                {
                    { 10, "Marvel is the name of many fictional superheroes appearing in comic books published by Marvel Comics. The character was originally conceived as a female counterpart to Captain Marvel. Like Captain Marvel, most of the bearers of the Ms.", 200, 50f, "Ms. Marvel", 2012 },
                    { 9, "Black Panther is a fictional superhero appearing in American comic books published by Marvel Comics. ... Black Panther's real name is T'Challa, and he is depicted as the king and protector of the fictional African nation of Wakanda.", 258, 85f, "Black Panther", 2016 },
                    { 8, "The character, which is based on the Norse deity of the same name, is the Asgardian god of thunder who possesses the enchanted hammer, Mjolnir, which grants him the ability to fly and manipulate weather amongst his other superhuman attributes.", 158, 55.55f, "Thor", 2012 },
                    { 7, "Captain America is the alter ego of Steve Rogers, a frail young man enhanced to the peak of human perfection by an experimental serum to aid the United States government's efforts in World War II. Near the end of the war, he was trapped in ice and survived in suspended animation until he was revived in modern times.", 136, 86f, "Captain America", 1997 },
                    { 6, "Venom is a fictional character appearing in American comic books published by Marvel Comics, commonly in association with Spider-Man. The character is a sentient alien symbiote with an amorphous, liquid-like form, who survives by bonding with a host, usually human.", 135, 125f, "Venom", 2016 },
                    { 5, "Green Lantern is an ongoing American comic-book series featuring the DC Comics heroes of the same name. ... When the Silver Age Green Lantern, Hal Jordan, was introduced, the character starred in a new volume of Green Lantern starting in 1960.", 105, 77f, "Green Lantern", 2014 },
                    { 4, "Created as a female counterpart to Superman, Kara Zor-El shares his super powers and vulnerability to Kryptonite. Supergirl plays a supporting role in various DC Comics publications, including Action Comics, Superman, and several comic book series unrelated to Superman.", 85, 66f, "Super Girl", 2005 },
                    { 3, "Iron Man is a fictional superhero appearing in American comic books published by Marvel Comics. ... He uses the suit and successive versions to protect the world as Iron Man. Although at first concealing his true identity, Stark eventually publicly reveals himself to be Iron Man.", 77, 45.99f, "Iron Man", 2002 },
                    { 2, "American teenager Peter Parker, a poor sickly orphan, is bitten by a radioactive spider. As a result of the bite, he gains superhuman strength, speed, and agility along with the ability to cling to walls.", 99, 66.99f, "Spider Man", 1998 },
                    { 1, "In his comic book appearances, the character is both the Hulk, a green-skinned, hulking and muscular humanoid possessing a vast degree of physical strength, and his alter ego Dr. Robert Bruce Banner, a physically weak, socially withdrawn, and emotionally reserved physicist.", 200, 50f, "Hulk", 2012 }
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

            migrationBuilder.InsertData(
                table: "ComicAuthor",
                columns: new[] { "AuthorID", "ComicID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 10 },
                    { 7, 7 },
                    { 6, 6 },
                    { 5, 5 },
                    { 1, 8 },
                    { 4, 4 },
                    { 2, 2 },
                    { 3, 3 },
                    { 2, 9 }
                });

            migrationBuilder.InsertData(
                table: "ComicGenre",
                columns: new[] { "ComicID", "GenreID" },
                values: new object[,]
                {
                    { 8, 2 },
                    { 3, 3 },
                    { 2, 2 },
                    { 9, 3 },
                    { 7, 1 },
                    { 1, 1 },
                    { 4, 4 },
                    { 10, 4 },
                    { 6, 6 },
                    { 5, 5 }
                });

           

            migrationBuilder.InsertData(
                table: "ComicInventory",
                columns: new[] { "ComicID", "Quantity" },
                values: new object[,]
                {
                    { 9, 5 },
                    { 10, 3 },
                    { 6, 0 },
                    { 5, 9 },
                    { 4, 0 },
                    { 3, 1 },
                    { 2, 0 },
                    { 1, 1 },
                    { 8, 3 },
                    { 7, 1 }
                });
          

            migrationBuilder.CreateIndex(
                name: "IX_ComicAuthor_ComicID",
                table: "ComicAuthor",
                column: "ComicID");

            migrationBuilder.CreateIndex(
                name: "IX_ComicGenre_GenreID",
                table: "ComicGenre",
                column: "GenreID");

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
                name: "ComicAuthor");

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
