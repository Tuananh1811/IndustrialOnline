using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCIndustrial.Data.Migrations
{
    public partial class addColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessibilityAirport",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccessibilityCenter",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccessibilityExpressway",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccessibilityPort",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CeilingHeight",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ElectricityCapacity",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Juridical",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoadingCapacoty",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceProject",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TermOfSdd",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Utilities",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WastewaterTreatmentCapacity",
                table: "ProjectTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WaterSupplyCapacity",
                table: "ProjectTranslations",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessibilityAirport",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "AccessibilityCenter",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "AccessibilityExpressway",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "AccessibilityPort",
                table: "ProjectTranslations");

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
                value: "8af8685f-8652-4187-9e65-89623e025f9b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9bbce732-efc8-46e0-ada4-ae2fc6e62cc2", "AQAAAAEAACcQAAAAEKFnqHskH0cJWoeuXjaFZz/Tc2fWAC08GFF7q4YbByX7EQ0KuaPWptN+7KeQNi84kA==" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 11, 21, 16, 22, 37, 87, DateTimeKind.Local).AddTicks(7962));
        }
    }
}
