using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicStore.Infra.EFRepository.Migrations
{
    public partial class ManyToManySeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2012, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2007, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2000, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2019, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2017, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AuthorComic",
                columns: new[] { "AuthorsAuthorID", "ComicsComicID" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorComic",
                keyColumns: new[] { "AuthorsAuthorID", "ComicsComicID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1999, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2001, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2003, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2002, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2012, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2016, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
