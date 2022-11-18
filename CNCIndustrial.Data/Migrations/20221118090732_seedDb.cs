using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCIndustrial.Data.Migrations
{
    public partial class seedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "4ec64dde-c89f-4c92-90ac-96275e1a3ced");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f7f872f6-d236-42aa-9a60-02b6e0385bb7", "AQAAAAEAACcQAAAAEF85EDX9LqYdYtM/2Zj6KndO07aNRomN2csDclAEZMEkhAgoaHHWQr8S30DyfVkwFw==" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsShowOnHome", "ParentId", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 3, true, null, 3, 1 },
                    { 4, true, null, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "CategoryTranslations",
                columns: new[] { "Id", "CategoryId", "LanguageId", "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 11, 3, "vi", "Hà Nam", "Ha-Nam", "Khu công nghiệp Hà Nam", "Khu công nghiệp Hà Nam" },
                    { 12, 3, "en", "Ha Nam", "Ha-Nam", "Ha Nam Industrial Park", "Ha Nam Industrial Park" },
                    { 13, 3, "ko-kr", "Ha Nam", "Ha-Nam", "하남산업단지", "하남산업단지" },
                    { 14, 3, "ja-jp", "Ha Nam", "Ha-Nam", "ハナム工業団地", "ハナム工業団地" },
                    { 15, 3, "zh-cn", "Ha Nam", "Ha-Nam", "河南工業園區", "河南工業園區" },
                    { 16, 4, "vi", "TP. Hồ Chí Minh", "Tp-Ho-Chi-Minh", "Khu công nghiệp thành phố Hồ Chí Minh", "Khu công nghiệp thành phố Hồ Chí Minh" },
                    { 17, 4, "en", "Ho Chi Minh City", "Ho-Chi-Minh-City", "Ho Chi Minh City Industrial Park", "Ho Chi Minh City Industrial Park" },
                    { 18, 4, "ko-kr", "호치민시", "Ho-Chi-Minh-City", "호치민시 산업단지", "호치민시 산업단지" },
                    { 19, 4, "ja-jp", "ホーチミン市", "Ho-Chi-Minh-City", "ホーチミン市工業団地", "ホーチミン市工業団地" },
                    { 20, 4, "zh-cn", "胡志明市", "Ho-Chi-Minh-City", "胡志明市工業園區", "胡志明市工業園區" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"),
                column: "ConcurrencyStamp",
                value: "9f970781-e809-4205-901c-c403211eb704");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bdd5ad67-0a11-430c-be82-9db5107323ff", "AQAAAAEAACcQAAAAEFskCz23FgFcw7TxIPqj3J/BAUoEnwqZl0+4R0ew65O+t9Ed7GK/QCHn3hZPsyDk6w==" });
        }
    }
}
