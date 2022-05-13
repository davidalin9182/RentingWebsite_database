using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAD_DATABASE.Migrations
{
    public partial class test14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnnouncementId",
                table: "Announcement",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Announcement",
                newName: "AnnouncementId");
        }
    }
}
