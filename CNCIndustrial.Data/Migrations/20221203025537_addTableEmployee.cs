using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCIndustrial.Data.Migrations
{
    public partial class addTableEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTranslation_Employee_EmployeeId",
                table: "EmployeeTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTranslation_Languages_LanguageId",
                table: "EmployeeTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTranslation",
                table: "EmployeeTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "EmployeeTranslation",
                newName: "EmployeeTranslations");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTranslation_LanguageId",
                table: "EmployeeTranslations",
                newName: "IX_EmployeeTranslations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTranslation_EmployeeId",
                table: "EmployeeTranslations",
                newName: "IX_EmployeeTranslations_EmployeeId");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "EmployeeTranslations",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EmployeeTranslations",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LanguageId",
                table: "EmployeeTranslations",
                unicode: false,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTranslations",
                table: "EmployeeTranslations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTranslations_Employees_EmployeeId",
                table: "EmployeeTranslations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTranslations_Languages_LanguageId",
                table: "EmployeeTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTranslations_Employees_EmployeeId",
                table: "EmployeeTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTranslations_Languages_LanguageId",
                table: "EmployeeTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTranslations",
                table: "EmployeeTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "EmployeeTranslations",
                newName: "EmployeeTranslation");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTranslations_LanguageId",
                table: "EmployeeTranslation",
                newName: "IX_EmployeeTranslation_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTranslations_EmployeeId",
                table: "EmployeeTranslation",
                newName: "IX_EmployeeTranslation_EmployeeId");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "EmployeeTranslation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EmployeeTranslation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "LanguageId",
                table: "EmployeeTranslation",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTranslation",
                table: "EmployeeTranslation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "17f20d37-a6d9-4583-ab00-2c6d67b40fe2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5f64aad5-a444-4d85-8545-ea673420060a", "AQAAAAEAACcQAAAAENjppmYXbUvzdfR+dS7RCzcvdE4K09NwovRpuXRimKz7Dc0b06//2VczoA9u9xbGEQ==" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 12, 3, 9, 17, 30, 987, DateTimeKind.Local).AddTicks(6900));

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTranslation_Employee_EmployeeId",
                table: "EmployeeTranslation",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTranslation_Languages_LanguageId",
                table: "EmployeeTranslation",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
