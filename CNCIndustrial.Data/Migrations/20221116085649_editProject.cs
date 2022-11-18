using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCIndustrial.Data.Migrations
{
    public partial class editProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "iframeMap",
                table: "Projects",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "d9fd65b2-609f-4a81-83d4-cb2de8caa53f");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "43cd05e6-dba8-407b-b083-0cb94177d14e", "AQAAAAEAACcQAAAAEFPreFr1lidODR72uvbwXwXRApiZnxo/Fgm+5F6VD0wdWihXBepHQfjrvo/2r5qZ9A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "iframeMap",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 400);

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
    }
}
