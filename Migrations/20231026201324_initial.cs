using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DepositManager.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                name: "EmailSettings",
                columns: table => new
                {
                    EmailSettingsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Hostname = table.Column<string>(type: "TEXT", nullable: false),
                    Port = table.Column<double>(type: "REAL", nullable: false),
                    Recipient = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailSettings", x => x.EmailSettingsId);
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
                    { new Guid("58906590-74fb-425a-a85a-cdd47b729db7"), "FNB" },
                    { new Guid("ae01dc8e-309a-4bc2-bfad-c9422b0c90ff"), "Unassigned" },
                    { new Guid("e8bd5276-91e0-42aa-bc2d-9518b7fa5adb"), "ERIE" }
                });

            migrationBuilder.InsertData(
                table: "Check",
                columns: new[] { "CheckId", "Amount", "CustomerName", "DepositId", "ReferenceNum" },
                values: new object[,]
                {
                    { new Guid("b794d70a-6ede-40a8-94cb-178e2296827f"), 15.25m, "Free To Choose", null, 1562.0 },
                    { new Guid("f3b86203-412f-401b-91b4-7089de5820f3"), 2560.3m, "Humes", null, 125.0 }
                });

            migrationBuilder.InsertData(
                table: "EmailSettings",
                columns: new[] { "EmailSettingsId", "Hostname", "Password", "Port", "Recipient", "Username" },
                values: new object[] { new Guid("05d14ecc-164c-4e15-8564-fbd46011251c"), "mail.example.com", "password", 587.0, "guy@example.com", "user@example.com" });

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
                name: "EmailSettings");

            migrationBuilder.DropTable(
                name: "Deposit");

            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
