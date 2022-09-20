using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracaInżynierska.Infrastructure.Migrations
{
    public partial class v03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "User",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
