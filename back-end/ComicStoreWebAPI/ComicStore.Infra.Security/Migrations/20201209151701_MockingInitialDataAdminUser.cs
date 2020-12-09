using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicStore.Infra.Security.Migrations
{
    public partial class MockingInitialDataAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "seg",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8ceb39d0-530b-4016-955e-fb4e713714eb", 0, "72df09dd-9a6c-4655-a700-6885eb58e37d", "admin@comicstore.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEPjNHxphxpBQUr5OiMGjilGAhA4laW0HUkbUK42CvlC9JEu1HvTZ6v6EL/n9ktnzFg==", null, false, "AHZGG2P4K6A7LOXC4YPTW2QAZKU52XON", false, "admin@comicstore.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "seg",
                table: "Users",
                keyColumn: "Id",
                keyValue: "8ceb39d0-530b-4016-955e-fb4e713714eb");
        }
    }
}
