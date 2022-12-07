using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCIndustrial.Data.Migrations
{
    public partial class addData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Founding",
                table: "AboutUss");

            migrationBuilder.DropColumn(
                name: "Intro",
                table: "AboutUss");

            migrationBuilder.AddColumn<string>(
                name: "ImageBanner",
                table: "AboutUss",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageFly",
                table: "AboutUss",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "9c1a0bd7-4aa7-4661-a28a-266ee552a339");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4be5b37d-72c0-4243-ab44-6a020a693385", "AQAAAAEAACcQAAAAEA+N7WkZzmgBtTtjLdGGJPKRYU1/vSbCUY2hewiaIexszDC8SRGYcmu13cbpd7MUOQ==" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 12, 6, 9, 51, 13, 823, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.InsertData(
                table: "Slides",
                columns: new[] { "Id", "Description", "Image", "Name", "SortOrder", "Status", "Url" },
                values: new object[,]
                {
                    { 1, "Mô tả", "/img/banner/DJI_0766.jpg", "Image-1", 1, 1, "#" },
                    { 2, "Mô tả", "/img/banner/DJI_0774.jpg", "Image-2", 2, 1, "#" },
                    { 3, "Mô tả", "/img/banner/DJI_0777.jpg", "Image-3", 3, 1, "#" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ImageBanner",
                table: "AboutUss");

            migrationBuilder.DropColumn(
                name: "ImageFly",
                table: "AboutUss");

            migrationBuilder.AddColumn<string>(
                name: "Founding",
                table: "AboutUss",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Intro",
                table: "AboutUss",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
