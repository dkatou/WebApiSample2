using Microsoft.EntityFrameworkCore.Migrations;

namespace Api1Migration.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK01_T_COMPANY_CHILD_T_COMPANY",
                table: "T_COMPANY_CHILD");

            migrationBuilder.AddForeignKey(
                name: "FK01_T_COMPANY_CHILD_T_COMPANY",
                table: "T_COMPANY_CHILD",
                column: "V_COMPANY_PARENT_ID",
                principalTable: "T_COMPANY",
                principalColumn: "V_COMPANY_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK01_T_COMPANY_CHILD_T_COMPANY",
                table: "T_COMPANY_CHILD");

            migrationBuilder.AddForeignKey(
                name: "FK01_T_COMPANY_CHILD_T_COMPANY",
                table: "T_COMPANY_CHILD",
                column: "V_COMPANY_PARENT_ID",
                principalTable: "T_COMPANY",
                principalColumn: "V_COMPANY_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
