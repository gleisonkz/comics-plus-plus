using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicStore.Infra.EFRepository.Migrations
{
    public partial class addImageColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorComic_Comic_ComicID",
                table: "AuthorComic");

            migrationBuilder.RenameColumn(
                name: "ComicID",
                table: "AuthorComic",
                newName: "ComicsComicID");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorComic_ComicID",
                table: "AuthorComic",
                newName: "IX_AuthorComic_ComicsComicID");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Comic",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorComic_Comic_ComicsComicID",
                table: "AuthorComic",
                column: "ComicsComicID",
                principalTable: "Comic",
                principalColumn: "ComicID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorComic_Comic_ComicsComicID",
                table: "AuthorComic");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Comic");

            migrationBuilder.RenameColumn(
                name: "ComicsComicID",
                table: "AuthorComic",
                newName: "ComicID");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorComic_ComicsComicID",
                table: "AuthorComic",
                newName: "IX_AuthorComic_ComicID");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorComic_Comic_ComicID",
                table: "AuthorComic",
                column: "ComicID",
                principalTable: "Comic",
                principalColumn: "ComicID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
