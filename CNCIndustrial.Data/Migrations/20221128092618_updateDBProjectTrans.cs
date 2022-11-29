using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCIndustrial.Data.Migrations
{
    public partial class updateDBProjectTrans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CeilingHeight",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "ElectricityCapacity",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "Juridical",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "LoadingCapacoty",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "PriceProject",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "TermOfSdd",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "Utilities",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "WastewaterTreatmentCapacity",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "WaterSupplyCapacity",
                table: "ProjectTranslations");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CeilingHeight",
                table: "ProjectTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ElectricityCapacity",
                table: "ProjectTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Juridical",
                table: "ProjectTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoadingCapacoty",
                table: "ProjectTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceProject",
                table: "ProjectTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TermOfSdd",
                table: "ProjectTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Utilities",
                table: "ProjectTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WastewaterTreatmentCapacity",
                table: "ProjectTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WaterSupplyCapacity",
                table: "ProjectTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "1e18812f-837e-4186-8a91-0928a2a4c843");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "54e54ca0-cab8-452e-bd44-c343bbceac08", "AQAAAAEAACcQAAAAEME9odY7ISeu+tJW4Aiwn8UGPOtngwAXp6zkUteqKFFm2Fae5g63YS7NdhJ33dbLeA==" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 11, 22, 13, 49, 5, 721, DateTimeKind.Local).AddTicks(8209));
        }
    }
}
