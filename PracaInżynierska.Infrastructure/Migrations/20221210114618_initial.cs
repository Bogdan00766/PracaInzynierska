using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracaInzynierska.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AutoLoginGUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutoLoginGUIDExpires = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "FinancialChange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    TransferId = table.Column<int>(type: "int", nullable: true),
                    SentFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    AssetTypeId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    ReductionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialChange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialChange_AssetType_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AssetType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinancialChange_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinancialChange_FinancialChange_ReductionId",
                        column: x => x.ReductionId,
                        principalTable: "FinancialChange",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinancialChange_Transfer_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinancialChange_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialChange_AssetTypeId",
                table: "FinancialChange",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialChange_CategoryId",
                table: "FinancialChange",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialChange_OwnerId",
                table: "FinancialChange",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialChange_ReductionId",
                table: "FinancialChange",
                column: "ReductionId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialChange_TransferId",
                table: "FinancialChange",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_UserId",
                table: "Transfer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_EMail",
                table: "User",
                column: "EMail",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialChange");

            migrationBuilder.DropTable(
                name: "AssetType");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Transfer");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
