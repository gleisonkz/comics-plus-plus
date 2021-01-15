using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicStore.Infra.EFRepository.Migrations
{
    public partial class OrderItemDecimalConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitValue",
                table: "OrderItem",
                type: "decimal(7,2)",
                precision: 7,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalValue",
                table: "OrderItem",
                type: "decimal(7,2)",
                precision: 7,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2004, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2009, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2010, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2016, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(1997, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2011, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2004, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitValue",
                table: "OrderItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)",
                oldPrecision: 7,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalValue",
                table: "OrderItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)",
                oldPrecision: 7,
                oldScale: 2);

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1998, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2007, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2000, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(1995, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2016, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2011, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
