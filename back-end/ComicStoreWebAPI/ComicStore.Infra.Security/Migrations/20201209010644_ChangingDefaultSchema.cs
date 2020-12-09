using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicStore.Infra.Security.Migrations
{
    public partial class ChangingDefaultSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "seg");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "seg");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "seg");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "seg");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "seg");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "seg");

            migrationBuilder.RenameTable(
                name: "IdentityRole",
                schema: "seg",
                newName: "AspNetRoles",
                newSchema: "seg");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                schema: "seg",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                schema: "seg",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalSchema: "seg",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                schema: "seg",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalSchema: "seg",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                schema: "seg",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                schema: "seg",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                schema: "seg",
                table: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "seg",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "seg",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "seg",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "seg",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "seg",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "seg",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "seg",
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
    }
}
