using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicStore.Infra.EFRepository.Migrations
{
    public partial class ConfigurationM2MComicAuthorGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComicGenre_Comic_ComicsComicID",
                table: "ComicGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_ComicGenre_Genre_GenresGenreID",
                table: "ComicGenre");

            migrationBuilder.DropTable(
                name: "AuthorComic");

            migrationBuilder.RenameColumn(
                name: "GenresGenreID",
                table: "ComicGenre",
                newName: "GenreID");

            migrationBuilder.RenameColumn(
                name: "ComicsComicID",
                table: "ComicGenre",
                newName: "ComicID");

            migrationBuilder.RenameIndex(
                name: "IX_ComicGenre_GenresGenreID",
                table: "ComicGenre",
                newName: "IX_ComicGenre_GenreID");

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

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2015, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2020, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2003, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2011, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2015, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2012, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "ComicAuthor",
                columns: new[] { "AuthorID", "ComicID" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ComicAuthor_ComicID",
                table: "ComicAuthor",
                column: "ComicID");

            migrationBuilder.AddForeignKey(
                name: "FK_ComicGenre_Comic_ComicID",
                table: "ComicGenre",
                column: "ComicID",
                principalTable: "Comic",
                principalColumn: "ComicID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComicGenre_Genre_GenreID",
                table: "ComicGenre",
                column: "GenreID",
                principalTable: "Genre",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComicGenre_Comic_ComicID",
                table: "ComicGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_ComicGenre_Genre_GenreID",
                table: "ComicGenre");

            migrationBuilder.DropTable(
                name: "ComicAuthor");

            migrationBuilder.RenameColumn(
                name: "GenreID",
                table: "ComicGenre",
                newName: "GenresGenreID");

            migrationBuilder.RenameColumn(
                name: "ComicID",
                table: "ComicGenre",
                newName: "ComicsComicID");

            migrationBuilder.RenameIndex(
                name: "IX_ComicGenre_GenreID",
                table: "ComicGenre",
                newName: "IX_ComicGenre_GenresGenreID");

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

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2000, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2003, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2005, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2014, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2004, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2015, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2012, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AuthorComic",
                columns: new[] { "AuthorsAuthorID", "ComicsComicID" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorComic_ComicsComicID",
                table: "AuthorComic",
                column: "ComicsComicID");

            migrationBuilder.AddForeignKey(
                name: "FK_ComicGenre_Comic_ComicsComicID",
                table: "ComicGenre",
                column: "ComicsComicID",
                principalTable: "Comic",
                principalColumn: "ComicID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComicGenre_Genre_GenresGenreID",
                table: "ComicGenre",
                column: "GenresGenreID",
                principalTable: "Genre",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
