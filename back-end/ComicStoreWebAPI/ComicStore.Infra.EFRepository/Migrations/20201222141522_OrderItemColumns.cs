using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicStore.Infra.EFRepository.Migrations
{
    public partial class OrderItemColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "TotalValue",
                table: "OrderItem",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "UnitValue",
                table: "OrderItem",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "UnitValue",
                table: "OrderItem");
        }
    }
}
