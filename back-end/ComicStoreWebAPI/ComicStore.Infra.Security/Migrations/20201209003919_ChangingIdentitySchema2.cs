using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicStore.Infra.Security.Migrations
{
    public partial class ChangingIdentitySchema2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.EnsureSchema(
                name: "seg");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "IdentityRole",
                newSchema: "seg");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityRole",
                schema: "seg",
                table: "IdentityRole",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalSchema: "seg",
                principalTable: "IdentityRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalSchema: "seg",
                principalTable: "IdentityRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_IdentityRole_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_IdentityRole_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityRole",
                schema: "seg",
                table: "IdentityRole");

            migrationBuilder.RenameTable(
                name: "IdentityRole",
                schema: "seg",
                newName: "AspNetRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
