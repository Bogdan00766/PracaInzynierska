using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracaInżynierska.Infrastructure.Migrations
{
    public partial class v002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_EMail",
                table: "User",
                column: "EMail",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_EMail",
                table: "User");
        }
    }
}
