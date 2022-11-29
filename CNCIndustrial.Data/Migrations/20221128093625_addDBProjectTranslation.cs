using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCIndustrial.Data.Migrations
{
    public partial class addDBProjectTranslation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "Investor",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "ProjectOverView",
                table: "ProjectTranslations");

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Commerce",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Technical",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "42c3c922-c50b-476a-9b20-b8418bfa9381");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0cb6b319-fdcc-4251-accd-f38392aef0a1", "AQAAAAEAACcQAAAAECEc5jQJ+d2WOSjcRSH+XkQ0C5Ltn0qpfnDwV7pjdRG9sOhdMUhBnR6KMS6N0RUyHA==" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 11, 28, 16, 36, 23, 674, DateTimeKind.Local).AddTicks(5319));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "Commerce",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "Technical",
                table: "ProjectTranslations");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "ProjectTranslations",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Investor",
                table: "ProjectTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectOverView",
                table: "ProjectTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "85a67d9e-5f5a-44ff-9781-a421a9926530");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a6892340-624a-465a-8580-17c4c67ecfcf", "AQAAAAEAACcQAAAAEMnyiOLoM9KgIM8W2mDSPjI/swpT2Hmy7hfN+gND4qqgwsWBGgvFa2GP+reW/LiCaQ==" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 11, 28, 16, 26, 17, 254, DateTimeKind.Local).AddTicks(5976));
        }
    }
}
