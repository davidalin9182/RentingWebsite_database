using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WADDATABASE.Migrations
{
    public partial class test1234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Blog",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Blog",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blog_AppUserId",
                table: "Blog",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_AspNetUsers_AppUserId",
                table: "Blog",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_AspNetUsers_AppUserId",
                table: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_Blog_AppUserId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Blog");
        }
    }
}
