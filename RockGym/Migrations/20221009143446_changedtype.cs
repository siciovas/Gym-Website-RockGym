using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RockGym.Migrations
{
    public partial class changedtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Subscriptions");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Subscriptions",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Subscriptions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
