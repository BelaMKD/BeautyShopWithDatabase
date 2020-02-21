using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyShop.Data.Migrations
{
    public partial class Start11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Memberships_MembershipId1",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MembershipId1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "MembershipId1",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MembershipId",
                table: "Customers",
                column: "MembershipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Memberships_MembershipId",
                table: "Customers",
                column: "MembershipId",
                principalTable: "Memberships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Memberships_MembershipId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MembershipId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Memberships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MembershipId1",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MembershipId1",
                table: "Customers",
                column: "MembershipId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Memberships_MembershipId1",
                table: "Customers",
                column: "MembershipId1",
                principalTable: "Memberships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
