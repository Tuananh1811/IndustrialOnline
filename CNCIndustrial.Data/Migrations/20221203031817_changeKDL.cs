using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCIndustrial.Data.Migrations
{
    public partial class changeKDL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 11);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "9c4ae460-ddf8-4119-9a56-032228d456d2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1023fcb0-0fdc-45ac-b25f-33fb4e9492e4", "AQAAAAEAACcQAAAAEFnPEzVbrVLl4E8pKVOgwSd4QjDD+9NqTnekNNNZW0pLPGpYpbIWJE3B9dZsO9UQNg==" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 12, 3, 10, 18, 16, 752, DateTimeKind.Local).AddTicks(5613));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Employees",
                type: "int",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "166792fc-5b6b-4394-8277-c885a6ee1df7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d9a52251-8992-45a1-bee0-da5ff427cb08", "AQAAAAEAACcQAAAAEFZ7DL6vqkhmcSXgAZ/bdjARNw/+6ZgJf9dPmhHP0rnHUSvxFoCIPOKKzju2QQ21Jg==" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 12, 3, 9, 55, 36, 835, DateTimeKind.Local).AddTicks(8030));
        }
    }
}
