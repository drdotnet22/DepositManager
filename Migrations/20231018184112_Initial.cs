using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DepositManager.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BankName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "Deposit",
                columns: table => new
                {
                    DepositId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    BankId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DepositStatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    Cash = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposit", x => x.DepositId);
                    table.ForeignKey(
                        name: "FK_Deposit_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Check",
                columns: table => new
                {
                    CheckId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReferenceNum = table.Column<double>(type: "REAL", nullable: false),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    DepositId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Check", x => x.CheckId);
                    table.ForeignKey(
                        name: "FK_Check_Deposit_DepositId",
                        column: x => x.DepositId,
                        principalTable: "Deposit",
                        principalColumn: "DepositId");
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "BankName" },
                values: new object[,]
                {
                    { new Guid("5f33f20c-70d5-4f97-9345-317990a8ac49"), "Unassigned" },
                    { new Guid("8fbe2ff0-510a-432e-8d65-003287ab1062"), "ERIE" },
                    { new Guid("ca7d0348-051c-4c7d-8ad0-8e24d7e8b185"), "FNB" }
                });

            migrationBuilder.InsertData(
                table: "Check",
                columns: new[] { "CheckId", "Amount", "CustomerName", "DepositId", "ReferenceNum" },
                values: new object[,]
                {
                    { new Guid("0b9d3461-5a98-4f05-a1ae-faefaaff5b31"), 15.25m, "Free To Choose", null, 1562.0 },
                    { new Guid("4e381693-780a-4ff7-87c6-35841e79391c"), 2560.3m, "Humes", null, 125.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Check_DepositId",
                table: "Check",
                column: "DepositId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposit_BankId",
                table: "Deposit",
                column: "BankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Check");

            migrationBuilder.DropTable(
                name: "Deposit");

            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
