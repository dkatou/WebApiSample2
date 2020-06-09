using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api1Migration.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_BLOG",
                columns: table => new
                {
                    V_BLOG_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TS_STAMP = table.Column<DateTime>(nullable: false),
                    US_STAMP = table.Column<string>(nullable: true),
                    AS_STAMP = table.Column<string>(nullable: true),
                    N_URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_BLOG", x => x.V_BLOG_ID);
                });

            migrationBuilder.CreateTable(
                name: "T_COMPANY",
                columns: table => new
                {
                    V_COMPANY_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TS_STAMP = table.Column<DateTime>(nullable: false),
                    US_STAMP = table.Column<string>(nullable: true),
                    AS_STAMP = table.Column<string>(nullable: true),
                    N_COMPANY_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_COMPANY", x => x.V_COMPANY_ID);
                });

            migrationBuilder.CreateTable(
                name: "T_NOTE",
                columns: table => new
                {
                    V_NOTE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TS_STAMP = table.Column<DateTime>(nullable: false),
                    US_STAMP = table.Column<string>(nullable: true),
                    AS_STAMP = table.Column<string>(nullable: true),
                    N_CONTENT = table.Column<string>(nullable: true),
                    V_BLOG_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_NOTE", x => x.V_NOTE_ID);
                    table.ForeignKey(
                        name: "FK01_T_NOTE_T_BLOG",
                        column: x => x.V_BLOG_ID,
                        principalTable: "T_BLOG",
                        principalColumn: "V_BLOG_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_POST",
                columns: table => new
                {
                    V_POST_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TS_STAMP = table.Column<DateTime>(nullable: false),
                    US_STAMP = table.Column<string>(nullable: true),
                    AS_STAMP = table.Column<string>(nullable: true),
                    N_TITLE = table.Column<string>(nullable: true),
                    N_CONTENT = table.Column<string>(nullable: true),
                    V_BLOG_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_POST", x => x.V_POST_ID);
                    table.ForeignKey(
                        name: "FK01_T_POST_T_BLOG",
                        column: x => x.V_BLOG_ID,
                        principalTable: "T_BLOG",
                        principalColumn: "V_BLOG_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_VIEWER",
                columns: table => new
                {
                    V_VIEWER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TS_STAMP = table.Column<DateTime>(nullable: false),
                    US_STAMP = table.Column<string>(nullable: true),
                    AS_STAMP = table.Column<string>(nullable: true),
                    N_VIEWER_NAME = table.Column<string>(maxLength: 10, nullable: true),
                    V_PERSON_ID = table.Column<int>(nullable: false),
                    D_VIWE_DATETIME = table.Column<DateTime>(nullable: false),
                    V_BLOG_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_VIEWER", x => x.V_VIEWER_ID);
                    table.ForeignKey(
                        name: "FK01_T_VIEWER_T_BLOG",
                        column: x => x.V_BLOG_ID,
                        principalTable: "T_BLOG",
                        principalColumn: "V_BLOG_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_COMPANY_CHILD",
                columns: table => new
                {
                    V_COMPANY_PARENT_ID = table.Column<int>(nullable: false),
                    V_COMPANY_CHILD_ID = table.Column<int>(nullable: false),
                    TS_STAMP = table.Column<DateTime>(nullable: false),
                    US_STAMP = table.Column<string>(nullable: true),
                    AS_STAMP = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_COMPANY_CHILD", x => new { x.V_COMPANY_PARENT_ID, x.V_COMPANY_CHILD_ID });
                    table.ForeignKey(
                        name: "FK_T_COMPANY_CHILD_T_COMPANY_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "T_COMPANY",
                        principalColumn: "V_COMPANY_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK01_T_COMPANY_CHILD_T_COMPANY",
                        column: x => x.V_COMPANY_PARENT_ID,
                        principalTable: "T_COMPANY",
                        principalColumn: "V_COMPANY_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_POST_CHILD",
                columns: table => new
                {
                    V_POST_CHILD_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TS_STAMP = table.Column<DateTime>(nullable: false),
                    US_STAMP = table.Column<string>(nullable: true),
                    AS_STAMP = table.Column<string>(nullable: true),
                    N_POST_CHILD_NAME = table.Column<string>(nullable: true),
                    V_POST_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_POST_CHILD", x => x.V_POST_CHILD_ID);
                    table.ForeignKey(
                        name: "FK01_T_POST_CHILD_T_POST",
                        column: x => x.V_POST_ID,
                        principalTable: "T_POST",
                        principalColumn: "V_POST_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_COMPANY_CHILD_CompanyId",
                table: "T_COMPANY_CHILD",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_T_NOTE_V_BLOG_ID",
                table: "T_NOTE",
                column: "V_BLOG_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_POST_V_BLOG_ID",
                table: "T_POST",
                column: "V_BLOG_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_POST_CHILD_V_POST_ID",
                table: "T_POST_CHILD",
                column: "V_POST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_VIEWER_V_BLOG_ID",
                table: "T_VIEWER",
                column: "V_BLOG_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_COMPANY_CHILD");

            migrationBuilder.DropTable(
                name: "T_NOTE");

            migrationBuilder.DropTable(
                name: "T_POST_CHILD");

            migrationBuilder.DropTable(
                name: "T_VIEWER");

            migrationBuilder.DropTable(
                name: "T_COMPANY");

            migrationBuilder.DropTable(
                name: "T_POST");

            migrationBuilder.DropTable(
                name: "T_BLOG");
        }
    }
}
