using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DepositManager.Migrations
{
    /// <inheritdoc />
    public partial class MakeDepositTotalMandatory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<decimal>(
                name: "DepositTotal",
                table: "Deposit",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "BankName" },
                values: new object[,]
                {
                    { new Guid("758fda5f-15be-4ef5-96af-ba287773ab6a"), "FNB" },
                    { new Guid("e40f6c07-4910-4921-a0f3-fb1ae0f982f6"), "Unassigned" },
                    { new Guid("efc17b25-3e7c-45a9-a548-e636ddfc47e5"), "ERIE" }
                });

            migrationBuilder.InsertData(
                table: "Check",
                columns: new[] { "CheckId", "Amount", "CustomerName", "DepositId", "ReferenceNum" },
                values: new object[,]
                {
                    { new Guid("042a42fd-746c-44c3-9687-29fca0917afc"), 2560.3m, "Humes", null, 125.0 },
                    { new Guid("9ff05ae3-290c-408d-a146-3391b06b3eb1"), 15.25m, "Free To Choose", null, 1562.0 }
                });

            migrationBuilder.InsertData(
                table: "EmailSettings",
                columns: new[] { "EmailSettingsId", "Hostname", "Password", "Port", "Recipient", "Username" },
                values: new object[] { new Guid("07d567f2-5994-4dee-985e-aec7a1b5f0c0"), "mail.example.com", "password", 587, "guy@example.com", "user@example.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: new Guid("758fda5f-15be-4ef5-96af-ba287773ab6a"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: new Guid("e40f6c07-4910-4921-a0f3-fb1ae0f982f6"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: new Guid("efc17b25-3e7c-45a9-a548-e636ddfc47e5"));

            migrationBuilder.DeleteData(
                table: "Check",
                keyColumn: "CheckId",
                keyValue: new Guid("042a42fd-746c-44c3-9687-29fca0917afc"));

            migrationBuilder.DeleteData(
                table: "Check",
                keyColumn: "CheckId",
                keyValue: new Guid("9ff05ae3-290c-408d-a146-3391b06b3eb1"));

            migrationBuilder.DeleteData(
                table: "EmailSettings",
                keyColumn: "EmailSettingsId",
                keyValue: new Guid("07d567f2-5994-4dee-985e-aec7a1b5f0c0"));

            migrationBuilder.AlterColumn<decimal>(
                name: "DepositTotal",
                table: "Deposit",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

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
    }
}
