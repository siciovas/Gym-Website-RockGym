using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RockGym.Migrations
{
    public partial class updateddto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "BoughtSubscription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BoughtSubscription_SubscriptionId",
                table: "BoughtSubscription",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoughtSubscription_Subscriptions_SubscriptionId",
                table: "BoughtSubscription",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoughtSubscription_Subscriptions_SubscriptionId",
                table: "BoughtSubscription");

            migrationBuilder.DropIndex(
                name: "IX_BoughtSubscription_SubscriptionId",
                table: "BoughtSubscription");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "BoughtSubscription");
        }
    }
}
