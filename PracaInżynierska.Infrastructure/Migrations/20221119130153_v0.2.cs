using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracaInżynierska.Infrastructure.Migrations
{
    public partial class v02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AssetType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AssetType",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
