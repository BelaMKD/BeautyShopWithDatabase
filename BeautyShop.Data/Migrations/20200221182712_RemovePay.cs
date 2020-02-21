using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyShop.Data.Migrations
{
    public partial class RemovePay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pay",
                table: "Visits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Pay",
                table: "Visits",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
