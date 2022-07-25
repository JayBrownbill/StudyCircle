using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyCircle.API.Migrations
{
    public partial class Navigational_Properties_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudyTopic_UserId",
                table: "StudyTopic",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyTopic_Users_UserId",
                table: "StudyTopic",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyTopic_Users_UserId",
                table: "StudyTopic");

            migrationBuilder.DropIndex(
                name: "IX_StudyTopic_UserId",
                table: "StudyTopic");
        }
    }
}
