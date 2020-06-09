using Microsoft.EntityFrameworkCore.Migrations;

namespace Api1Migration.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_COMPANY_CHILD_T_COMPANY_CompanyId",
                table: "T_COMPANY_CHILD");

            migrationBuilder.DropForeignKey(
                name: "FK01_T_COMPANY_CHILD_T_COMPANY",
                table: "T_COMPANY_CHILD");

            migrationBuilder.DropIndex(
                name: "IX_T_COMPANY_CHILD_CompanyId",
                table: "T_COMPANY_CHILD");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "T_COMPANY_CHILD");

            migrationBuilder.CreateIndex(
                name: "IX_T_COMPANY_CHILD_V_COMPANY_CHILD_ID",
                table: "T_COMPANY_CHILD",
                column: "V_COMPANY_CHILD_ID");

            migrationBuilder.AddForeignKey(
                name: "FK02_T_COMPANY_CHILD_T_COMPANY",
                table: "T_COMPANY_CHILD",
                column: "V_COMPANY_CHILD_ID",
                principalTable: "T_COMPANY",
                principalColumn: "V_COMPANY_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK01_T_COMPANY_CHILD_T_COMPANY",
                table: "T_COMPANY_CHILD",
                column: "V_COMPANY_PARENT_ID",
                principalTable: "T_COMPANY",
                principalColumn: "V_COMPANY_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK02_T_COMPANY_CHILD_T_COMPANY",
                table: "T_COMPANY_CHILD");

            migrationBuilder.DropForeignKey(
                name: "FK01_T_COMPANY_CHILD_T_COMPANY",
                table: "T_COMPANY_CHILD");

            migrationBuilder.DropIndex(
                name: "IX_T_COMPANY_CHILD_V_COMPANY_CHILD_ID",
                table: "T_COMPANY_CHILD");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "T_COMPANY_CHILD",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_COMPANY_CHILD_CompanyId",
                table: "T_COMPANY_CHILD",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_COMPANY_CHILD_T_COMPANY_CompanyId",
                table: "T_COMPANY_CHILD",
                column: "CompanyId",
                principalTable: "T_COMPANY",
                principalColumn: "V_COMPANY_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK01_T_COMPANY_CHILD_T_COMPANY",
                table: "T_COMPANY_CHILD",
                column: "V_COMPANY_PARENT_ID",
                principalTable: "T_COMPANY",
                principalColumn: "V_COMPANY_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
