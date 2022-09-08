using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracaInżynierska.Infrastructure.Migrations
{
    public partial class v01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfer_FinancialChange_FinancialChangeId",
                table: "Transfer");

            migrationBuilder.DropIndex(
                name: "IX_Transfer_FinancialChangeId",
                table: "Transfer");

            migrationBuilder.DropColumn(
                name: "FinancialChangeId",
                table: "Transfer");

            migrationBuilder.AddColumn<int>(
                name: "TransferId",
                table: "FinancialChange",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinancialChange_TransferId",
                table: "FinancialChange",
                column: "TransferId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialChange_Transfer_TransferId",
                table: "FinancialChange",
                column: "TransferId",
                principalTable: "Transfer",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialChange_Transfer_TransferId",
                table: "FinancialChange");

            migrationBuilder.DropIndex(
                name: "IX_FinancialChange_TransferId",
                table: "FinancialChange");

            migrationBuilder.DropColumn(
                name: "TransferId",
                table: "FinancialChange");

            migrationBuilder.AddColumn<int>(
                name: "FinancialChangeId",
                table: "Transfer",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_FinancialChangeId",
                table: "Transfer",
                column: "FinancialChangeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfer_FinancialChange_FinancialChangeId",
                table: "Transfer",
                column: "FinancialChangeId",
                principalTable: "FinancialChange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
