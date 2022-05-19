using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WADDATABASE.Migrations
{
    public partial class Test15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppUser",
                table: "Announcement");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Announcement",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Announcement");

            migrationBuilder.AddColumn<string>(
                name: "AppUser",
                table: "Announcement",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
