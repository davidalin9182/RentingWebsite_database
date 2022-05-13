using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAD_DATABASE.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Score_ScoreId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ScoreId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ScoreId",
                table: "Games");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScoreId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_ScoreId",
                table: "Games",
                column: "ScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Score_ScoreId",
                table: "Games",
                column: "ScoreId",
                principalTable: "Score",
                principalColumn: "ScoreId");
        }
    }
}
