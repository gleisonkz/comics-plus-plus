using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicStore.Infra.EFRepository.Migrations
{
    public partial class addPocoConfigurationFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorComic_Author_AuthorID",
                table: "AuthorComic");

            migrationBuilder.DropForeignKey(
                name: "FK_Comic_Genre_GenreID",
                table: "Comic");

            migrationBuilder.DropIndex(
                name: "IX_Comic_GenreID",
                table: "Comic");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Comic");

            migrationBuilder.DropColumn(
                name: "GenreID",
                table: "Comic");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "AuthorComic",
                newName: "AuthorsAuthorID");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Genre",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComicID",
                table: "Genre",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Comic",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Comic",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Author",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genre_ComicID",
                table: "Genre",
                column: "ComicID");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorComic_Author_AuthorsAuthorID",
                table: "AuthorComic",
                column: "AuthorsAuthorID",
                principalTable: "Author",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_Comic_ComicID",
                table: "Genre",
                column: "ComicID",
                principalTable: "Comic",
                principalColumn: "ComicID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorComic_Author_AuthorsAuthorID",
                table: "AuthorComic");

            migrationBuilder.DropForeignKey(
                name: "FK_Genre_Comic_ComicID",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Genre_ComicID",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "ComicID",
                table: "Genre");

            migrationBuilder.RenameColumn(
                name: "AuthorsAuthorID",
                table: "AuthorComic",
                newName: "AuthorID");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Genre",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Comic",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Comic",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Comic",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenreID",
                table: "Comic",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Author",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_Comic_GenreID",
                table: "Comic",
                column: "GenreID");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorComic_Author_AuthorID",
                table: "AuthorComic",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comic_Genre_GenreID",
                table: "Comic",
                column: "GenreID",
                principalTable: "Genre",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
