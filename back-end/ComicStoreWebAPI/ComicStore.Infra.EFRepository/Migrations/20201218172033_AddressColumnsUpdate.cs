using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicStore.Infra.EFRepository.Migrations
{
    public partial class AddressColumnsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Order",
                newName: "Neighborhood");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Customer",
                newName: "Neighborhood");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Order",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "Neighborhood",
                table: "Order",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Neighborhood",
                table: "Customer",
                newName: "Country");
        }
    }
}
