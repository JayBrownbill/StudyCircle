using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyCircle.API.Migrations
{
    public partial class Add_TimeStamps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLastActive",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCompleted",
                table: "StudyTopic",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStarted",
                table: "StudyTopic",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "GoalPercentage",
                table: "StudyTopic",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "LongestSession",
                table: "StudyTopic",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WhenLastActive",
                table: "StudyTopic",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateLastActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateCompleted",
                table: "StudyTopic");

            migrationBuilder.DropColumn(
                name: "DateStarted",
                table: "StudyTopic");

            migrationBuilder.DropColumn(
                name: "GoalPercentage",
                table: "StudyTopic");

            migrationBuilder.DropColumn(
                name: "LongestSession",
                table: "StudyTopic");

            migrationBuilder.DropColumn(
                name: "WhenLastActive",
                table: "StudyTopic");
        }
    }
}
