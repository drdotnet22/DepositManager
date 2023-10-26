using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DepositManager.Migrations
{
    /// <inheritdoc />
    public partial class changeporttoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: new Guid("58906590-74fb-425a-a85a-cdd47b729db7"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: new Guid("ae01dc8e-309a-4bc2-bfad-c9422b0c90ff"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: new Guid("e8bd5276-91e0-42aa-bc2d-9518b7fa5adb"));

            migrationBuilder.DeleteData(
                table: "Check",
                keyColumn: "CheckId",
                keyValue: new Guid("b794d70a-6ede-40a8-94cb-178e2296827f"));

            migrationBuilder.DeleteData(
                table: "Check",
                keyColumn: "CheckId",
                keyValue: new Guid("f3b86203-412f-401b-91b4-7089de5820f3"));

            migrationBuilder.DeleteData(
                table: "EmailSettings",
                keyColumn: "EmailSettingsId",
                keyValue: new Guid("05d14ecc-164c-4e15-8564-fbd46011251c"));

            migrationBuilder.AlterColumn<int>(
                name: "Port",
                table: "EmailSettings",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "BankName" },
                values: new object[,]
                {
                    { new Guid("02fe1f8a-5112-4952-a8d0-4c2de82d3190"), "FNB" },
                    { new Guid("1ef2121d-d4d6-441b-bb46-28ac48167291"), "ERIE" },
                    { new Guid("43c731df-f40e-4344-9519-1cbb4b2bdac6"), "Unassigned" }
                });

            migrationBuilder.InsertData(
                table: "Check",
                columns: new[] { "CheckId", "Amount", "CustomerName", "DepositId", "ReferenceNum" },
                values: new object[,]
                {
                    { new Guid("3ac9e85b-60b6-417d-98c4-ad0fa78d52c3"), 15.25m, "Free To Choose", null, 1562.0 },
                    { new Guid("dbd6e966-977f-440f-bb77-57ebfef547f2"), 2560.3m, "Humes", null, 125.0 }
                });

            migrationBuilder.InsertData(
                table: "EmailSettings",
                columns: new[] { "EmailSettingsId", "Hostname", "Password", "Port", "Recipient", "Username" },
                values: new object[] { new Guid("f01c869b-9079-416f-9361-830ef1c32f80"), "mail.example.com", "password", 587, "guy@example.com", "user@example.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: new Guid("02fe1f8a-5112-4952-a8d0-4c2de82d3190"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: new Guid("1ef2121d-d4d6-441b-bb46-28ac48167291"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: new Guid("43c731df-f40e-4344-9519-1cbb4b2bdac6"));

            migrationBuilder.DeleteData(
                table: "Check",
                keyColumn: "CheckId",
                keyValue: new Guid("3ac9e85b-60b6-417d-98c4-ad0fa78d52c3"));

            migrationBuilder.DeleteData(
                table: "Check",
                keyColumn: "CheckId",
                keyValue: new Guid("dbd6e966-977f-440f-bb77-57ebfef547f2"));

            migrationBuilder.DeleteData(
                table: "EmailSettings",
                keyColumn: "EmailSettingsId",
                keyValue: new Guid("f01c869b-9079-416f-9361-830ef1c32f80"));

            migrationBuilder.AlterColumn<double>(
                name: "Port",
                table: "EmailSettings",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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
        }
    }
}
