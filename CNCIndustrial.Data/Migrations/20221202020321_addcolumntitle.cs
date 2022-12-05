using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCIndustrial.Data.Migrations
{
    public partial class addcolumntitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriShort",
                table: "NewsPostIndustrials");

            migrationBuilder.DropColumn(
                name: "TenDangNhap",
                table: "NewsPostIndustrials");

            migrationBuilder.AddColumn<string>(
                name: "DescriShort",
                table: "NewsPostTranslations",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "b21d7850-8a39-49f9-909c-37a88279077a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5acec77c-0986-48a8-bf2e-1e5ae0bebe2e", "AQAAAAEAACcQAAAAEKA4d7DAzECT1LYAI1KS0veluMz2LjuPBtfrMwI9Xq7VUpaIedevreuAcpeAVSgTdA==" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 12, 2, 9, 3, 20, 965, DateTimeKind.Local).AddTicks(2730));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriShort",
                table: "NewsPostTranslations");

            migrationBuilder.AddColumn<string>(
                name: "DescriShort",
                table: "NewsPostIndustrials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenDangNhap",
                table: "NewsPostIndustrials",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
