using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCIndustrial.Data.Migrations
{
    public partial class adddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTranslations_AccessibilityTranslation_AccessibilityTranslationId",
                table: "ProjectTranslations");

            migrationBuilder.DropTable(
                name: "AccessibilityTranslation");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTranslations_AccessibilityTranslationId",
                table: "ProjectTranslations");

            migrationBuilder.DropColumn(
                name: "AccessibilityTranslationId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessibilityTranslationId",
                table: "ProjectTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccessibilityTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessibilityId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<string>(type: "varchar(10)", nullable: true),
                    Parameter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    street = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessibilityTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessibilityTranslation_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTranslations_AccessibilityTranslationId",
                table: "ProjectTranslations",
                column: "AccessibilityTranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessibilityTranslation_LanguageId",
                table: "AccessibilityTranslation",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTranslations_AccessibilityTranslation_AccessibilityTranslationId",
                table: "ProjectTranslations",
                column: "AccessibilityTranslationId",
                principalTable: "AccessibilityTranslation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
