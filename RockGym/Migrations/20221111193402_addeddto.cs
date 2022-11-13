using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RockGym.Migrations
{
    public partial class addeddto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupTrainingFeedbacks_GroupTrainings_GroupTrainingId",
                table: "GroupTrainingFeedbacks");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "GroupTrainings");

            migrationBuilder.RenameColumn(
                name: "GroupTrainingId",
                table: "GroupTrainingFeedbacks",
                newName: "groupTrainingId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupTrainingFeedbacks_GroupTrainingId",
                table: "GroupTrainingFeedbacks",
                newName: "IX_GroupTrainingFeedbacks_groupTrainingId");

            migrationBuilder.AddColumn<string>(
                name: "Starts",
                table: "GroupTrainings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTrainingFeedbacks_GroupTrainings_groupTrainingId",
                table: "GroupTrainingFeedbacks",
                column: "groupTrainingId",
                principalTable: "GroupTrainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupTrainingFeedbacks_GroupTrainings_groupTrainingId",
                table: "GroupTrainingFeedbacks");

            migrationBuilder.DropColumn(
                name: "Starts",
                table: "GroupTrainings");

            migrationBuilder.RenameColumn(
                name: "groupTrainingId",
                table: "GroupTrainingFeedbacks",
                newName: "GroupTrainingId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupTrainingFeedbacks_groupTrainingId",
                table: "GroupTrainingFeedbacks",
                newName: "IX_GroupTrainingFeedbacks_GroupTrainingId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "GroupTrainings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTrainingFeedbacks_GroupTrainings_GroupTrainingId",
                table: "GroupTrainingFeedbacks",
                column: "GroupTrainingId",
                principalTable: "GroupTrainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
