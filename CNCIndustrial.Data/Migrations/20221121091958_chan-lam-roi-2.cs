using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCIndustrial.Data.Migrations
{
    public partial class chanlamroi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessibilityTranslation_Languages_LanguageId",
                table: "AccessibilityTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTranslations_AccessibilityTranslation_AccessibilityTranslationId",
                table: "ProjectTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTranslations_Languages_LanguageId",
                table: "ProjectTranslations");

            migrationBuilder.AlterColumn<string>(
                name: "SeoAlias",
                table: "ProjectTranslations",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProjectTranslations",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LanguageId",
                table: "ProjectTranslations",
                unicode: false,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "ProjectTranslations",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccessibilityTranslationId",
                table: "ProjectTranslations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LanguageId",
                table: "AccessibilityTranslation",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "4b596748-a390-45fa-b3be-ef6c8cc9d8a9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "157f184b-ceb0-4f9d-ac79-1eabb02314d9", "AQAAAAEAACcQAAAAEA+Ga7UiZQKf6iAP4uQqUcosyKotlvqX5R74b/KVkolbdnxF0gXj4fPvKEcKNtmwHg==" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 11, 21, 16, 19, 58, 172, DateTimeKind.Local).AddTicks(5801));

            migrationBuilder.AddForeignKey(
                name: "FK_AccessibilityTranslation_Languages_LanguageId",
                table: "AccessibilityTranslation",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTranslations_AccessibilityTranslation_AccessibilityTranslationId",
                table: "ProjectTranslations",
                column: "AccessibilityTranslationId",
                principalTable: "AccessibilityTranslation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTranslations_Languages_LanguageId",
                table: "ProjectTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessibilityTranslation_Languages_LanguageId",
                table: "AccessibilityTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTranslations_AccessibilityTranslation_AccessibilityTranslationId",
                table: "ProjectTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTranslations_Languages_LanguageId",
                table: "ProjectTranslations");

            migrationBuilder.AlterColumn<string>(
                name: "SeoAlias",
                table: "ProjectTranslations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProjectTranslations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "LanguageId",
                table: "ProjectTranslations",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "ProjectTranslations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccessibilityTranslationId",
                table: "ProjectTranslations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LanguageId",
                table: "AccessibilityTranslation",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "a4e1d574-1fcb-48fd-989a-ee370534e803");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "053764ea-526e-4ec8-a02f-b9bfb2efb295", "AQAAAAEAACcQAAAAEPNQmfLSg6ihmEdlUgejnD5y87dAJygWpHNlKlgEwpc4l8VD/OR3NYviX9vVdoXdWA==" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 11, 21, 16, 12, 3, 941, DateTimeKind.Local).AddTicks(2434));

            migrationBuilder.AddForeignKey(
                name: "FK_AccessibilityTranslation_Languages_LanguageId",
                table: "AccessibilityTranslation",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTranslations_AccessibilityTranslation_AccessibilityTranslationId",
                table: "ProjectTranslations",
                column: "AccessibilityTranslationId",
                principalTable: "AccessibilityTranslation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTranslations_Languages_LanguageId",
                table: "ProjectTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
