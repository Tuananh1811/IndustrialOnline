using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCIndustrial.Data.Migrations
{
    public partial class renameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "f71c56f7-96c0-452a-b5bb-b199300bb83b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae338552-acd4-486b-bb03-0ff80902577a", "AQAAAAEAACcQAAAAECMU6AJjQF4KcvL2aWL9lAuFhaz+kYszG7Jh9Qh+FYV/yF8z4hcCMRdET0sL/O5B+A==" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 12, 3, 13, 54, 45, 508, DateTimeKind.Local).AddTicks(7357));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "3db49f2f-2e9d-4149-942d-516d0df36efb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "02d26148-d392-450f-9a2f-462200a0ea09", "AQAAAAEAACcQAAAAEGi8sAdfsBvm7JkPQqlzmDQrCrQv2cyancHiFiZVm1OwrSPAxzlKcc2+Lt/X8xT01A==" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 12, 3, 13, 48, 4, 86, DateTimeKind.Local).AddTicks(8663));
        }
    }
}
