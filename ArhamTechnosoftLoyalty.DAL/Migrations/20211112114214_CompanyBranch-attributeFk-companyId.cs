using Microsoft.EntityFrameworkCore.Migrations;

namespace ArhamTechnosoftLoyalty.DAL.Migrations
{
    public partial class CompanyBranchattributeFkcompanyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranch_CompanyMaster_CompanyId",
                table: "CompanyBranch");

            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                table: "CompanyBranch",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranch_CompanyMaster_CompanyId",
                table: "CompanyBranch",
                column: "CompanyId",
                principalTable: "CompanyMaster",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranch_CompanyMaster_CompanyId",
                table: "CompanyBranch");

            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                table: "CompanyBranch",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranch_CompanyMaster_CompanyId",
                table: "CompanyBranch",
                column: "CompanyId",
                principalTable: "CompanyMaster",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
