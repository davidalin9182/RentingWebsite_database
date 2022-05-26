using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WADDATABASE.Migrations
{
    public partial class finaltest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Announcement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Announcement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Announcement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyType",
                table: "Announcement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Surface",
                table: "Announcement",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Announcement");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Announcement");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Announcement");

            migrationBuilder.DropColumn(
                name: "PropertyType",
                table: "Announcement");

            migrationBuilder.DropColumn(
                name: "Surface",
                table: "Announcement");
        }
    }
}
