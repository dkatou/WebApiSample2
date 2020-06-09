using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api1Migration.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_PERSON",
                columns: table => new
                {
                    V_PERSON_ID = table.Column<int>(nullable: false),
                    N_PERSON_FIRST_NAME = table.Column<string>(nullable: false),
                    N_PERSON_LAST_NAME = table.Column<string>(nullable: false),
                    TS_STAMP = table.Column<DateTime>(nullable: false),
                    US_STAMP = table.Column<string>(nullable: true),
                    AS_STAMP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PERSON", x => new { x.V_PERSON_ID, x.N_PERSON_FIRST_NAME, x.N_PERSON_LAST_NAME });
                    table.UniqueConstraint("AK_T_PERSON_V_PERSON_ID", x => x.V_PERSON_ID);
                });

            migrationBuilder.CreateTable(
                name: "T_PERSON_TASK",
                columns: table => new
                {
                    V_PERSON_CHARGE_ID = table.Column<int>(nullable: false),
                    V_TASK_ID = table.Column<string>(nullable: false),
                    TS_STAMP = table.Column<DateTime>(nullable: false),
                    US_STAMP = table.Column<string>(nullable: true),
                    AS_STAMP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PERSON_TASK", x => new { x.V_PERSON_CHARGE_ID, x.V_TASK_ID });
                    table.ForeignKey(
                        name: "FK01_T_PERSON_TASK_T_PERSON",
                        column: x => x.V_PERSON_CHARGE_ID,
                        principalTable: "T_PERSON",
                        principalColumn: "V_PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_PERSON_TASK");

            migrationBuilder.DropTable(
                name: "T_PERSON");
        }
    }
}
