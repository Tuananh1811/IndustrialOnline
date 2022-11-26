using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCIndustrial.Data.Migrations
{
    public partial class chanlamroi : Migration
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
                name: "AppConfigs",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfigs", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(maxLength: 200, nullable: false),
                    Dob = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SortOrder = table.Column<int>(nullable: false),
                    IsShowOnHome = table.Column<bool>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Newss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    DescriShort = table.Column<string>(nullable: true),
                    DescriTall = table.Column<string>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NgayCapNhat = table.Column<DateTime>(nullable: true),
                    TenDangNhap = table.Column<string>(nullable: true),
                    HinhAnhMinhHoa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(nullable: false),
                    OriginalPrice = table.Column<decimal>(nullable: false),
                    Stock = table.Column<int>(nullable: false, defaultValue: 0),
                    ViewCount = table.Column<int>(nullable: false, defaultValue: 0),
                    iframeMap = table.Column<string>(maxLength: 400, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    IsFeatured = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Url = table.Column<string>(maxLength: 200, nullable: false),
                    Image = table.Column<string>(maxLength: 200, nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 200, nullable: false),
                    Message = table.Column<string>(nullable: false),
                    Iframe = table.Column<string>(nullable: true),
                    HotlineVN = table.Column<string>(nullable: true),
                    HotlineEN = table.Column<string>(nullable: true),
                    HotlineChi = table.Column<string>(nullable: true),
                    HotlineJa = table.Column<string>(nullable: true),
                    HotlineKo = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    AppUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccessibilityTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Parameter = table.Column<string>(nullable: true),
                    LanguageId = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    ProjectId = table.Column<string>(nullable: true),
                    AccessibilityId = table.Column<int>(nullable: false),
                    street = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessibilityTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessibilityTranslation_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    SeoDescription = table.Column<string>(maxLength: 500, nullable: true),
                    SeoTitle = table.Column<string>(maxLength: 200, nullable: true),
                    LanguageId = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    SeoAlias = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryTranslations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    SeoDescription = table.Column<string>(nullable: true),
                    SeoTitle = table.Column<string>(nullable: true),
                    LanguageId = table.Column<string>(nullable: true),
                    SeoAlias = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewsTranslations_Newss_NewsId",
                        column: x => x.NewsId,
                        principalTable: "Newss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Caption = table.Column<string>(maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    FileSize = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectImages_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectInCategories",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectInCategories", x => new { x.CategoryId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectInCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectInCategories_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    SeoAlias = table.Column<string>(maxLength: 200, nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
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
                        name: "FK_AboutUsTranslations_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AboutUsTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    SeoDescription = table.Column<string>(nullable: true),
                    SeoTitle = table.Column<string>(nullable: true),
                    TotalArea = table.Column<string>(nullable: true),
                    VacantArea = table.Column<string>(nullable: true),
                    Investor = table.Column<string>(nullable: true),
                    SeoAlias = table.Column<string>(nullable: true),
                    AccessibilityTranslationId = table.Column<int>(nullable: false),
                    MainFunction1 = table.Column<string>(nullable: true),
                    MainFunction2 = table.Column<string>(nullable: true),
                    MainFunction3 = table.Column<string>(nullable: true),
                    MainFunction4 = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    ProjectOverView = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTranslations_AccessibilityTranslation_AccessibilityTranslationId",
                        column: x => x.AccessibilityTranslationId,
                        principalTable: "AccessibilityTranslation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectTranslations_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "HomeTitle", "This is home page of CNCTechIndustrial" },
                    { "HomeKeyword", "This is keyword of CNCTechIndustrial" },
                    { "HomeDescription", "This is description of CNCTechIndustrial" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7"), "a4e1d574-1fcb-48fd-989a-ee370534e803", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"), 0, "053764ea-526e-4ec8-a02f-b9bfb2efb295", new DateTime(2000, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "tanhdo18@gmail.com", true, "Tuan Anh", false, null, "tanhdo18@gmail.com", "admin", "AQAAAAEAACcQAAAAEPNQmfLSg6ihmEdlUgejnD5y87dAJygWpHNlKlgEwpc4l8VD/OR3NYviX9vVdoXdWA==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsShowOnHome", "ParentId", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 1, true, null, 1, 1 },
                    { 2, true, null, 2, 1 },
                    { 3, true, null, 3, 1 },
                    { 4, true, null, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[,]
                {
                    { "vi", true, "Tiếng Việt" },
                    { "en", false, "English" },
                    { "ko-kr", false, "Korea" },
                    { "ja-jp", false, "Japan" },
                    { "zh-cn", false, "China" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "DateCreated", "IsFeatured", "OriginalPrice", "Price", "iframeMap" },
                values: new object[] { 1, new DateTime(2022, 11, 21, 16, 12, 3, 941, DateTimeKind.Local).AddTicks(2434), null, 100000m, 200000m, "Http://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3716.8211643267987!2d105.68034141461068!3d21.318081685842323!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3134e5dadc526c53%3A0xeb6c8f677c9262da!2zS2h1IGPDtG5nIG5naGnhu4dwIGLDoSB0aGnhu4duIDE!5e0!3m2!1svi!2s!4v1668825924376!5m2!" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("e23c9b99-51d5-4f0e-a15b-9b5d6b4c9507"), new Guid("583b332a-9d8b-4b9c-b502-1f48d02b9ec7") });

            migrationBuilder.InsertData(
                table: "CategoryTranslations",
                columns: new[] { "Id", "CategoryId", "LanguageId", "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 10, 2, "zh-cn", "Bac Ninh", "Bac-Ninh", "永福工業園", "永福工業園" },
                    { 5, 1, "zh-cn", "Vinh Phuc", "永福", "永福工業園", "永福工業園" },
                    { 19, 4, "ja-jp", "ホーチミン市", "Ho-Chi-Minh-City", "ホーチミン市工業団地", "ホーチミン市工業団地" },
                    { 14, 3, "ja-jp", "Ha Nam", "Ha-Nam", "ハナム工業団地", "ハナム工業団地" },
                    { 9, 2, "ja-jp", "Bac Ninh", "Bac-Ninh", "バクニン工業団地", "バクニン工業団地" },
                    { 4, 1, "ja-jp", "Vinh Phuc", "Vinh-Phuc", "ビンフック工業団地", "ビンフック工業団地" },
                    { 18, 4, "ko-kr", "호치민시", "Ho-Chi-Minh-City", "호치민시 산업단지", "호치민시 산업단지" },
                    { 13, 3, "ko-kr", "Ha Nam", "Ha-Nam", "하남산업단지", "하남산업단지" },
                    { 15, 3, "zh-cn", "Ha Nam", "Ha-Nam", "河南工業園區", "河南工業園區" },
                    { 8, 2, "ko-kr", "Bac Ninh", "Bac-Ninh", "박닌 산업단지", "박닌 산업단지" },
                    { 17, 4, "en", "Ho Chi Minh City", "Ho-Chi-Minh-City", "Ho Chi Minh City Industrial Park", "Ho Chi Minh City Industrial Park" },
                    { 12, 3, "en", "Ha Nam", "Ha-Nam", "Ha Nam Industrial Park", "Ha Nam Industrial Park" },
                    { 7, 2, "en", "Bac Ninh", "Bac-Ninh", "Bac Ninh Industrial Park", "Bac Ninh Industrial Park" },
                    { 2, 1, "en", "Vinh Phuc", "Vinh-Phuc", "Vinh Phuc Industrial Park", "Vinh Phuc Industrial Park" },
                    { 16, 4, "vi", "TP. Hồ Chí Minh", "Tp-Ho-Chi-Minh", "Khu công nghiệp thành phố Hồ Chí Minh", "Khu công nghiệp thành phố Hồ Chí Minh" },
                    { 11, 3, "vi", "Hà Nam", "Ha-Nam", "Khu công nghiệp Hà Nam", "Khu công nghiệp Hà Nam" },
                    { 6, 2, "vi", "Bắc Ninh", "Bac-Ninh", "Khu công nghiệp Bắc Ninh", "Khu công nghiệp Bắc Ninh" },
                    { 1, 1, "vi", "Vĩnh Phúc", "Vinh-Phuc", "Khu công nghiệp Vĩnh Phúc", "Khu công nghiệp Vĩnh Phúc" },
                    { 3, 1, "ko-kr", "Vinh Phuc", "Vinh-Phuc", "빈푹산업단지", "빈푹산업단지" },
                    { 20, 4, "zh-cn", "胡志明市", "Ho-Chi-Minh-City", "胡志明市工業園區", "胡志明市工業園區" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutUsTranslations_AboutUsId",
                table: "AboutUsTranslations",
                column: "AboutUsId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutUsTranslations_EmployeeId",
                table: "AboutUsTranslations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutUsTranslations_LanguageId",
                table: "AboutUsTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessibilityTranslation_LanguageId",
                table: "AccessibilityTranslation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_CategoryId",
                table: "CategoryTranslations",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_LanguageId",
                table: "CategoryTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AppUserId",
                table: "Employee",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsTranslations_LanguageId",
                table: "NewsTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsTranslations_NewsId",
                table: "NewsTranslations",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImages_ProjectId",
                table: "ProjectImages",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectInCategories_ProjectId",
                table: "ProjectInCategories",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTranslations_AccessibilityTranslationId",
                table: "ProjectTranslations",
                column: "AccessibilityTranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTranslations_LanguageId",
                table: "ProjectTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTranslations_ProjectId",
                table: "ProjectTranslations",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUsTranslations");

            migrationBuilder.DropTable(
                name: "AppConfigs");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CategoryTranslations");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "NewsTranslations");

            migrationBuilder.DropTable(
                name: "ProjectImages");

            migrationBuilder.DropTable(
                name: "ProjectInCategories");

            migrationBuilder.DropTable(
                name: "ProjectTranslations");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "AboutUss");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Newss");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AccessibilityTranslation");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
