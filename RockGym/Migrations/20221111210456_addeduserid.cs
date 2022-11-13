using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RockGym.Migrations
{
    public partial class addeduserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupTrainingFeedbacks_GroupTrainings_groupTrainingId",
                table: "GroupTrainingFeedbacks");

            migrationBuilder.RenameColumn(
                name: "groupTrainingId",
                table: "GroupTrainingFeedbacks",
                newName: "GroupTrainingId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupTrainingFeedbacks_groupTrainingId",
                table: "GroupTrainingFeedbacks",
                newName: "IX_GroupTrainingFeedbacks_GroupTrainingId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Subscriptions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "GroupTrainings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "GroupTrainingFeedbacks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainings_UserId",
                table: "GroupTrainings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainingFeedbacks_UserId",
                table: "GroupTrainingFeedbacks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTrainingFeedbacks_AspNetUsers_UserId",
                table: "GroupTrainingFeedbacks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTrainingFeedbacks_GroupTrainings_GroupTrainingId",
                table: "GroupTrainingFeedbacks",
                column: "GroupTrainingId",
                principalTable: "GroupTrainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTrainings_AspNetUsers_UserId",
                table: "GroupTrainings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AspNetUsers_UserId",
                table: "Subscriptions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupTrainingFeedbacks_AspNetUsers_UserId",
                table: "GroupTrainingFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupTrainingFeedbacks_GroupTrainings_GroupTrainingId",
                table: "GroupTrainingFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupTrainings_AspNetUsers_UserId",
                table: "GroupTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AspNetUsers_UserId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_GroupTrainings_UserId",
                table: "GroupTrainings");

            migrationBuilder.DropIndex(
                name: "IX_GroupTrainingFeedbacks_UserId",
                table: "GroupTrainingFeedbacks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GroupTrainings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GroupTrainingFeedbacks");

            migrationBuilder.RenameColumn(
                name: "GroupTrainingId",
                table: "GroupTrainingFeedbacks",
                newName: "groupTrainingId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupTrainingFeedbacks_GroupTrainingId",
                table: "GroupTrainingFeedbacks",
                newName: "IX_GroupTrainingFeedbacks_groupTrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTrainingFeedbacks_GroupTrainings_groupTrainingId",
                table: "GroupTrainingFeedbacks",
                column: "groupTrainingId",
                principalTable: "GroupTrainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
