using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArhamTechnosoftLoyalty.DAL.Migrations
{
    public partial class branchaddcolumncreatedon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "CompanyBranch",
                type: "timestamp without time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "CompanyBranch");
        }
    }
}
