using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCIndustrial.Data.Migrations
{
    public partial class addAboutUsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intro = table.Column<string>(nullable: true),
                    Founding = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AboutUsTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutUsId = table.Column<int>(nullable: false),
                    Intro = table.Column<string>(nullable: false),
                    Founding = table.Column<string>(nullable: true),
                    SeoDescription = table.Column<string>(maxLength: 500, nullable: true),
                    SeoTitle = table.Column<string>(maxLength: 200, nullable: true),
                    LanguageId = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    SeoAlias = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUsTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutUsTranslations_AboutUss_AboutUsId",
                        column: x => x.AboutUsId,
                        principalTable: "AboutUss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AboutUsTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AboutUsTranslations_AboutUsId",
                table: "AboutUsTranslations",
                column: "AboutUsId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutUsTranslations_LanguageId",
                table: "AboutUsTranslations",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectImages_AboutUss_ProjectId",
                table: "ProjectImages",
                column: "ProjectId",
                principalTable: "AboutUss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectImages_AboutUss_ProjectId",
                table: "ProjectImages");

            migrationBuilder.DropTable(
                name: "AboutUsTranslations");

            migrationBuilder.DropTable(
                name: "AboutUss");

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
    }
}
