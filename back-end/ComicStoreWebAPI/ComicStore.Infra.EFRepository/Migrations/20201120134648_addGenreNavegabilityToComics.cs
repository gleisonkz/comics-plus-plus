using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicStore.Infra.EFRepository.Migrations
{
    public partial class addGenreNavegabilityToComics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genre_Comic_ComicID",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Genre_ComicID",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "ComicID",
                table: "Genre");

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

            migrationBuilder.CreateIndex(
                name: "IX_ComicGenre_GenresGenreID",
                table: "ComicGenre",
                column: "GenresGenreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComicGenre");

            migrationBuilder.AddColumn<int>(
                name: "ComicID",
                table: "Genre",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genre_ComicID",
                table: "Genre",
                column: "ComicID");

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_Comic_ComicID",
                table: "Genre",
                column: "ComicID",
                principalTable: "Comic",
                principalColumn: "ComicID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
