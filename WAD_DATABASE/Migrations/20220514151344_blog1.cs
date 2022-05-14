using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAD_DATABASE.Migrations
{
    public partial class blog1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Readmore",
                table: "Blog",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Info",
                table: "Blog",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "Blog",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "BlogName",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogName",
                table: "Blog");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Blog",
                newName: "Readmore");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Blog",
                newName: "Info");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Blog",
                newName: "BlogId");
        }
    }
}
