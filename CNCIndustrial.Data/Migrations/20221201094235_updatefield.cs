using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCIndustrial.Data.Migrations
{
    public partial class updatefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "a2b5d691-e85c-4df0-8384-e55f9e556fb1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "182b3b95-ca7b-43d9-87e4-aa4f5ba2c990", "AQAAAAEAACcQAAAAEMCDBl+OdF/i2xKpkBVXtUSEG2pcgI6DjoeU39ibmatmrjOzkQQRZ++E2TlmSwxCfA==" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 12, 1, 16, 42, 34, 506, DateTimeKind.Local).AddTicks(2700));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "376205b6-093a-4f39-86bd-3ec121ff49e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "594c184b-428a-4d3a-9b54-aa7c561d7905", "AQAAAAEAACcQAAAAEEOGmUC6xdEVJSg2OSRBjpOaR8IBwnsLrdZ2Q0Hf+4VLxqkShS+ez/HDBttMcZzDkw==" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 12, 1, 15, 45, 53, 970, DateTimeKind.Local).AddTicks(4187));
        }
    }
}
