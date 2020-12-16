using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicStore.Infra.EFRepository.Migrations
{
    public partial class DefaultEnumValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @$" INSERT INTO PaymentMethod
                VALUES 
                (1, 'Cash'),
                (2, 'CreditCard'),
                (3, 'BankSlip')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.Sql(
                @$" DELETE FROM PaymentMethod
                    WHERE PaymentMethodID IN (1,2,3)");
        }
    }
}
