using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RockGym.Migrations
{
    public partial class mapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainings_SubscriptionId",
                table: "GroupTrainings",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainingFeedbacks_GroupTrainingId",
                table: "GroupTrainingFeedbacks",
                column: "GroupTrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTrainingFeedbacks_GroupTrainings_GroupTrainingId",
                table: "GroupTrainingFeedbacks",
                column: "GroupTrainingId",
                principalTable: "GroupTrainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTrainings_Subscriptions_SubscriptionId",
                table: "GroupTrainings",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupTrainingFeedbacks_GroupTrainings_GroupTrainingId",
                table: "GroupTrainingFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupTrainings_Subscriptions_SubscriptionId",
                table: "GroupTrainings");

            migrationBuilder.DropIndex(
                name: "IX_GroupTrainings_SubscriptionId",
                table: "GroupTrainings");

            migrationBuilder.DropIndex(
                name: "IX_GroupTrainingFeedbacks_GroupTrainingId",
                table: "GroupTrainingFeedbacks");
        }
    }
}
