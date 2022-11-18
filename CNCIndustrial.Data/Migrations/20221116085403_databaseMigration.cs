using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCIndustrial.Data.Migrations
{
    public partial class databaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "iframeMap",
                table: "Projects",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "9e514f20-10b6-4026-886f-13691f714237");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7f1d1f1a-e598-48d6-afc0-5f1e053e34f4", "AQAAAAEAACcQAAAAEAgp+wdlXNSucJJJT0LL8EJy4uo96I1lyB14tugbKeJerOqxiLzFebq7uDN+dATr2Q==" });
        }
        /*
         *
       
         */
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "iframeMap",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "6f7a8e9a-8343-458a-aebb-0fc81521393a");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f257bf29-8905-4b76-970f-4085e7e4e5c3", "AQAAAAEAACcQAAAAEKmhIOBmswwrCoJrgxsxpZSLt/mkhXXjy2rvOCqXellzUo3NgIUJIfB3k4FWfvv8kw==" });
        }
    }
}
