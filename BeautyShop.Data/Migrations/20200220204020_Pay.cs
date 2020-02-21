using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyShop.Data.Migrations
{
    public partial class Pay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Pay",
                table: "Visits",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pay",
                table: "Visits");
        }
    }
}
