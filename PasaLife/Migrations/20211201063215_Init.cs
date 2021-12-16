using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PasaLife.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Careers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Careers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FAQCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeCarousels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCarousels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IconButtons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IconButtons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InformationCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManagementCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Navbars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navbars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnlineServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDetailDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDetailDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDetailDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false),
                    IsSimple = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RuleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecondMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondMenus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Structures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Structures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "URLButtons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_URLButtons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AboutCompanyItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutCompanyItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutCompanyItems_AboutCompanies_AboutCompanyId",
                        column: x => x.AboutCompanyId,
                        principalTable: "AboutCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false),
                    InformationCenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_InformationCenters_InformationCenterId",
                        column: x => x.InformationCenterId,
                        principalTable: "InformationCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Managements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false),
                    ManagementCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managements_ManagementCategories_ManagementCategoryId",
                        column: x => x.ManagementCategoryId,
                        principalTable: "ManagementCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ITPlatforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlineServiceId = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITPlatforms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ITPlatforms_OnlineServices_OnlineServiceId",
                        column: x => x.OnlineServiceId,
                        principalTable: "OnlineServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Work = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false),
                    FAQCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    InformationCenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FAQs_FAQCategories_FAQCategoryId",
                        column: x => x.FAQCategoryId,
                        principalTable: "FAQCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FAQs_InformationCenters_InformationCenterId",
                        column: x => x.InformationCenterId,
                        principalTable: "InformationCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FAQs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partners_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCharts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCharts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCharts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetailTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzFirstSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuFirstSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnFirstSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzSecondSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuSecondSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnSecondSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzThirdSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuThirdSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnThirdSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzFourthSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuFourthSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnFourthSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetailTitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetailTitles_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInformations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductWords_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SimpleProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimpleProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimpleProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    AzName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_ReportCategories_ReportCategoryId",
                        column: x => x.ReportCategoryId,
                        principalTable: "ReportCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuleCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false),
                    InformationCenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rules_InformationCenters_InformationCenterId",
                        column: x => x.InformationCenterId,
                        principalTable: "InformationCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rules_RuleCategories_RuleCategoryId",
                        column: x => x.RuleCategoryId,
                        principalTable: "RuleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsDetails_News_NewId",
                        column: x => x.NewId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagementDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagementDetail_Managements_ManagementId",
                        column: x => x.ManagementId,
                        principalTable: "Managements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AboutCompanies",
                columns: new[] { "Id", "AzDescription", "AzTitle", "EnDescription", "EnTitle", "Image", "RuDescription", "RuTitle", "VideoLink" },
                values: new object[] { 1, "a", "PAŞA həyat", "e", "PAŞA həyat", "preview.jpg", "r", "PAŞA həyat", "https://www.youtube.com/embed/5O3XjaYWyq4" });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "AzDescription", "AzTitle", "EnDescription", "EnTitle", "IsDeactive", "RuDescription", "RuTitle" },
                values: new object[] { 1, "“PAŞA Holding” şirkətlər qrupuna daxil olan “PAŞA Həyat Sığorta” Açıq Səhmdar Cəmiyyəti 24.11.2010-cu il tarixdə Azərbaycan Respublikası Vergilər Nazirliyi tərəfindən dövlət qeydiyyatına alınaraq Azərbaycan Respublikası Maliyyə Nazirliyinin 14.02.2011-ci il tarixli lisenziyası əsasında həyat sığortası sahəsi üzrə xidmətlərin həyata keçirilməsi istiqamətində fəaliyyət göstərir.", "PAŞA Həyat", "“PASHA Life Insurance” Open Joint Stock Company, which is a part of “PASHA Holding” group of companies, was registered by the Ministry of Taxes of the Republic of Azerbaijan on 24.11.2010 and provides life insurance services on the basis of the license of the Ministry of Finance of the Republic of Azerbaijan dated 14.02.2011. acts in the direction of holding.", "PAŞA Həyat", false, "Открытое акционерное общество «PASHA Life Insurance», входящее в группу компаний «PASHA Holding», было зарегистрировано Министерством налогов Азербайджанской Республики 24.11.2010 и предоставляет услуги по страхованию жизни на основании лицензии. Министерства финансов Азербайджанской Республики от 14.02.2011 г. действует в направлении холдинга.", "PAŞA Həyat" });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "Id", "AzDescription", "AzTitle", "EnDescription", "EnTitle", "Image", "RuDescription", "RuTitle" },
                values: new object[] { 1, "“PAŞA Həyat Sığorta” ASC dinamik inkişaf edən universal həyat sığortası şirkəti olmaqla hazırda Azərbaycan Respublikasının Sığorta qanunvericiliyi ilə nəzərdə tutulmuş həyat sığortası sinfinə aid olan bütün növ məhsulları müştərilərinə təqdim edir.“PAŞA Həyat Sığorta” ASC İcbari Sığorta Bürosunun iştirakçısıdır.", "BİZƏ QOŞUL", "Being a dynamically developing universal life insurance company, PASHA Life Insurance OJSC currently offers its customers all types of life insurance products provided by the Insurance Legislation of the Republic of Azerbaijan. PASHA Life Insurance OJSC is a member of the Compulsory Insurance Bureau.", "JOIN US", null, "ОАО «PASHA Life Insurance» - динамично развивающаяся универсальная компания по страхованию жизни, в настоящее время предлагает своим клиентам все виды продуктов по страхованию жизни, предусмотренные Страховым законодательством Азербайджанской Республики. ОАО «PASHA Life Insurance» является членом Бюро по обязательному страхованию.", "ПРИСОЕДИНЯЙТЕСЬ К НАМ" });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "AzAddress", "AzDescription", "AzTitle", "ContactNumber", "EnAddress", "EnDescription", "EnTitle", "RuAddress", "RuDescription", "RuTitle" },
                values: new object[] { 1, "Bakı, Azərbaycan M.Useynov küç., 61, AZ1003", "Hər hansı bir sığorta hadisəsində sizə kömək etməkdən həmişə məmnunuq", "ƏLAQƏ", "012 942 | 994 12 525 29 42", "Baku, Azerbaijan 61 M.Useynov str., AZ1003", "We are always happy to help you in any insurance event", "CONTACT", "Баку, Азербайджан ул. М.Усейнова 61, AZ1003", "Мы всегда рады помочь вам в любом страховом случае.", "КОНТАКТ" });

            migrationBuilder.InsertData(
                table: "Footers",
                columns: new[] { "Id", "AzTitle", "EnTitle", "IsDeactive", "RuTitle", "URL" },
                values: new object[] { 1, "infobank.az", "infobank.az", false, "infobank.az", "https://infobank.az/" });

            migrationBuilder.InsertData(
                table: "HomeCenters",
                columns: new[] { "Id", "AzTitle", "EnTitle", "IsDeactive", "RuTitle", "URL" },
                values: new object[,]
                {
                    { 1, "Həyat yaşam sığortası", "Life insurance", false, "Страхование жизни", "" },
                    { 2, "Gəlirli həyat sığortası", "Profitable life insurance", false, "Выгодное страхование жизни", "" },
                    { 3, "İcbari həyat sığortası", "Compulsory life insurance", false, "Обязательное страхование жизни", "" }
                });

            migrationBuilder.InsertData(
                table: "IconButtons",
                columns: new[] { "Id", "AzName", "EnName", "Icon", "RuName", "URL" },
                values: new object[] { 1, "Şəxsi kabinet", "Personal cabinet", null, "Личный кабинет", "https://mylife.az/" });

            migrationBuilder.InsertData(
                table: "ManagementCategories",
                columns: new[] { "Id", "AzName", "EnName", "IsDeactive", "RuName" },
                values: new object[,]
                {
                    { 1, "Idarə Heyəti", "Board of Directors", false, "Совет директоров1" },
                    { 2, "Direktorlar Şurası", "Counsel of Directors", false, "Совет директоров2" }
                });

            migrationBuilder.InsertData(
                table: "Navbars",
                columns: new[] { "Id", "AzTitle", "EnTitle", "IsDeactive", "RuTitle", "URL" },
                values: new object[,]
                {
                    { 1, "Haqqımızda", "About us", false, "О нас", "" },
                    { 2, "Məhsullar", "Products", false, "Продукты", "" },
                    { 3, "Online xidmətlər", "Online services", false, "Онлайн-сервисы", "" },
                    { 4, "Məlumat mərkəzi", "Information Center", false, "Информационный центр", "" },
                    { 5, "Karyera", "Career", false, "Карьера", "" },
                    { 6, "Əlaqə", "Contact", false, "Контакт", "" }
                });

            migrationBuilder.InsertData(
                table: "ReportCategories",
                columns: new[] { "Id", "AzName", "EnName", "IsDeactive", "RuName" },
                values: new object[,]
                {
                    { 3, "İdarəetmə hesabatı", "Management report", false, "Отчет руководства" },
                    { 2, "Maliyyə hesabatı", "Financial report", false, "финансовый отчет" },
                    { 1, "Audit rəyi", "Audit opinion", false, "Аудиторское заключение" }
                });

            migrationBuilder.InsertData(
                table: "SecondMenus",
                columns: new[] { "Id", "AzTitle", "EnTitle", "IsDeactive", "RuTitle", "URL" },
                values: new object[,]
                {
                    { 1, "Şirkət haqqında", "About the company", false, "О компании", "" },
                    { 2, "Rəhbərlik", "Leadership", false, "Руководство", "" },
                    { 3, "Struktur", "Structure", false, "Структура", "" },
                    { 4, "Hesabatlar", "Reports", false, "Отчеты", "" },
                    { 5, "Mükafatlar", "Awards", false, "Награды", "" },
                    { 6, "Karyera", "Career", false, "Карьера", "" }
                });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "Id", "Image" },
                values: new object[] { 1, "structure.jpg" });

            migrationBuilder.InsertData(
                table: "URLButtons",
                columns: new[] { "Id", "Name", "URL" },
                values: new object[,]
                {
                    { 9, "Struktur", "/Structure" },
                    { 8, "Rəhbərlik", "/Management" },
                    { 7, "Şirkət haqqında", "/AboutCompany" },
                    { 6, "Əlaqə", "/Contact" },
                    { 2, "Məhsullar", "/Product" },
                    { 4, "Məlumat mərkəzi", "/InformationCenter" },
                    { 3, "Online xidmətlər", "/OnlineServices" },
                    { 10, "Hesabatlar", "/Report" },
                    { 1, "Haqqımızda", "/AboutUs" },
                    { 5, "Karyera", "/Career" },
                    { 11, "Mükafatlar", "/Award" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutCompanyItems_AboutCompanyId",
                table: "AboutCompanyItems",
                column: "AboutCompanyId");

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
                name: "IX_Customers_ProductId",
                table: "Customers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQs_FAQCategoryId",
                table: "FAQs",
                column: "FAQCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQs_InformationCenterId",
                table: "FAQs",
                column: "InformationCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQs_ProductId",
                table: "FAQs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ITPlatforms_OnlineServiceId",
                table: "ITPlatforms",
                column: "OnlineServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementDetail_ManagementId",
                table: "ManagementDetail",
                column: "ManagementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Managements_ManagementCategoryId",
                table: "Managements",
                column: "ManagementCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_News_InformationCenterId",
                table: "News",
                column: "InformationCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsDetails_NewId",
                table: "NewsDetails",
                column: "NewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partners_ProductId",
                table: "Partners",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCharts_ProductId",
                table: "ProductCharts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailTitles_ProductId",
                table: "ProductDetailTitles",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductInformations_ProductId",
                table: "ProductInformations",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductWords_ProductId",
                table: "ProductWords",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportCategoryId",
                table: "Reports",
                column: "ReportCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_InformationCenterId",
                table: "Rules",
                column: "InformationCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_RuleCategoryId",
                table: "Rules",
                column: "RuleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SimpleProducts_ProductId",
                table: "SimpleProducts",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutCompanyItems");

            migrationBuilder.DropTable(
                name: "Abouts");

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
                name: "Awards");

            migrationBuilder.DropTable(
                name: "Careers");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "Footers");

            migrationBuilder.DropTable(
                name: "HomeCarousels");

            migrationBuilder.DropTable(
                name: "HomeCenters");

            migrationBuilder.DropTable(
                name: "IconButtons");

            migrationBuilder.DropTable(
                name: "ITPlatforms");

            migrationBuilder.DropTable(
                name: "ManagementDetail");

            migrationBuilder.DropTable(
                name: "Navbars");

            migrationBuilder.DropTable(
                name: "NewsDetails");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "ProductCharts");

            migrationBuilder.DropTable(
                name: "ProductDetailTitles");

            migrationBuilder.DropTable(
                name: "ProductInformations");

            migrationBuilder.DropTable(
                name: "ProductWords");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "SecondMenus");

            migrationBuilder.DropTable(
                name: "SimpleProducts");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "Structures");

            migrationBuilder.DropTable(
                name: "URLButtons");

            migrationBuilder.DropTable(
                name: "AboutCompanies");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FAQCategories");

            migrationBuilder.DropTable(
                name: "OnlineServices");

            migrationBuilder.DropTable(
                name: "Managements");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "ReportCategories");

            migrationBuilder.DropTable(
                name: "RuleCategories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ManagementCategories");

            migrationBuilder.DropTable(
                name: "InformationCenters");
        }
    }
}
