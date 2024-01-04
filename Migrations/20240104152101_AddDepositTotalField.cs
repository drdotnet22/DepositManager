using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DepositManager.Migrations
{
    /// <inheritdoc />
    public partial class AddDepositTotalField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<decimal>(
                name: "DepositTotal",
                table: "Deposit",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "BankName" },
                values: new object[,]
                {
                    { new Guid("46b0df0c-969b-4bb9-aa8f-4008a5f24abc"), "FNB" },
                    { new Guid("ae53ad57-be68-4e3f-849e-abcff2cc24bc"), "ERIE" },
                    { new Guid("c5866871-1b1e-4954-a99f-38277d50c0fa"), "Unassigned" }
                });

            migrationBuilder.InsertData(
                table: "Check",
                columns: new[] { "CheckId", "Amount", "CustomerName", "DepositId", "ReferenceNum" },
                values: new object[,]
                {
                    { new Guid("0b148340-2caf-415b-9f06-1afc28fc3466"), 2560.3m, "Humes", null, 125.0 },
                    { new Guid("86b07ccd-7ea0-4a85-bbe6-1699df0d6a69"), 15.25m, "Free To Choose", null, 1562.0 }
                });

            migrationBuilder.InsertData(
                table: "EmailSettings",
                columns: new[] { "EmailSettingsId", "Hostname", "Password", "Port", "Recipient", "Username" },
                values: new object[] { new Guid("9e093be1-64c5-4920-b673-3d84e8961f0b"), "mail.example.com", "password", 587, "guy@example.com", "user@example.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: new Guid("46b0df0c-969b-4bb9-aa8f-4008a5f24abc"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: new Guid("ae53ad57-be68-4e3f-849e-abcff2cc24bc"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: new Guid("c5866871-1b1e-4954-a99f-38277d50c0fa"));

            migrationBuilder.DeleteData(
                table: "Check",
                keyColumn: "CheckId",
                keyValue: new Guid("0b148340-2caf-415b-9f06-1afc28fc3466"));

            migrationBuilder.DeleteData(
                table: "Check",
                keyColumn: "CheckId",
                keyValue: new Guid("86b07ccd-7ea0-4a85-bbe6-1699df0d6a69"));

            migrationBuilder.DeleteData(
                table: "EmailSettings",
                keyColumn: "EmailSettingsId",
                keyValue: new Guid("9e093be1-64c5-4920-b673-3d84e8961f0b"));

            migrationBuilder.DropColumn(
                name: "DepositTotal",
                table: "Deposit");

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
    }
}
