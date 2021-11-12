using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArhamTechnosoftLoyalty.DAL.Migrations
{
    public partial class companybranchupdate : Migration
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
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "BranchMailId",
                table: "CompanyBranch",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BranchPhoneId",
                table: "CompanyBranch",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "CompanyBranch",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CompanyBranch",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "CompanyBranch",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "CompanyBranch",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBranch_BranchMailId",
                table: "CompanyBranch",
                column: "BranchMailId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBranch_BranchPhoneId",
                table: "CompanyBranch",
                column: "BranchPhoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranch_CompanyMaster_CompanyId",
                table: "CompanyBranch",
                column: "CompanyId",
                principalTable: "CompanyMaster",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranch_Email_BranchMailId",
                table: "CompanyBranch",
                column: "BranchMailId",
                principalTable: "Email",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranch_Phone_BranchPhoneId",
                table: "CompanyBranch",
                column: "BranchPhoneId",
                principalTable: "Phone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranch_CompanyMaster_CompanyId",
                table: "CompanyBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranch_Email_BranchMailId",
                table: "CompanyBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranch_Phone_BranchPhoneId",
                table: "CompanyBranch");

            migrationBuilder.DropIndex(
                name: "IX_CompanyBranch_BranchMailId",
                table: "CompanyBranch");

            migrationBuilder.DropIndex(
                name: "IX_CompanyBranch_BranchPhoneId",
                table: "CompanyBranch");

            migrationBuilder.DropColumn(
                name: "BranchMailId",
                table: "CompanyBranch");

            migrationBuilder.DropColumn(
                name: "BranchPhoneId",
                table: "CompanyBranch");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CompanyBranch");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CompanyBranch");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CompanyBranch");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
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
    }
}
