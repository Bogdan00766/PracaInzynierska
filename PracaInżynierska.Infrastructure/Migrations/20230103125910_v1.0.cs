using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracaInzynierska.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialChange_Transfer_TransferId",
                table: "FinancialChange");

            migrationBuilder.DropTable(
                name: "Transfer");

            migrationBuilder.DropIndex(
                name: "IX_FinancialChange_TransferId",
                table: "FinancialChange");

            migrationBuilder.DropColumn(
                name: "TransferId",
                table: "FinancialChange");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransferId",
                table: "FinancialChange",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Transfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfer_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialChange_TransferId",
                table: "FinancialChange",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_UserId",
                table: "Transfer",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialChange_Transfer_TransferId",
                table: "FinancialChange",
                column: "TransferId",
                principalTable: "Transfer",
                principalColumn: "Id");
        }
    }
}
