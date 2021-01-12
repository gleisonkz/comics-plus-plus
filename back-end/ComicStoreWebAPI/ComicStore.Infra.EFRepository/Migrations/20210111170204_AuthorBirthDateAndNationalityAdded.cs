using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ComicStore.Infra.EFRepository.Migrations
{
    public partial class AuthorBirthDateAndNationalityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Comic",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Author",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 1,
                columns: new[] { "BirthDate", "Nationality" },
                values: new object[] { new DateTime(1997, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Australian" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 2,
                columns: new[] { "BirthDate", "Nationality" },
                values: new object[] { new DateTime(2012, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominican" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 3,
                columns: new[] { "BirthDate", "Name", "Nationality" },
                values: new object[] { new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "JK Rowling", "English" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 4,
                columns: new[] { "BirthDate", "Nationality" },
                values: new object[] { new DateTime(1999, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexican" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 5,
                columns: new[] { "BirthDate", "Nationality" },
                values: new object[] { new DateTime(2019, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "French" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 6,
                columns: new[] { "BirthDate", "Nationality" },
                values: new object[] { new DateTime(2017, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indonesian" });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 7,
                columns: new[] { "BirthDate", "Nationality" },
                values: new object[] { new DateTime(1996, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indian" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Author");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Comic",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(800)",
                oldMaxLength: 800);

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 3,
                column: "Name",
                value: "Jim Starlin");
        }
    }
}
