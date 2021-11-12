using Microsoft.EntityFrameworkCore.Migrations;

namespace ArhamTechnosoftLoyalty.DAL.Migrations
{
    public partial class CompanyMasterPropertyRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMaster_Phone_CompanyPhoneIdPhoneId",
                table: "CompanyMaster");

            migrationBuilder.RenameColumn(
                name: "CompanyPhoneIdPhoneId",
                table: "CompanyMaster",
                newName: "CompanyPhonePhoneId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyMaster_CompanyPhoneIdPhoneId",
                table: "CompanyMaster",
                newName: "IX_CompanyMaster_CompanyPhonePhoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMaster_Phone_CompanyPhonePhoneId",
                table: "CompanyMaster",
                column: "CompanyPhonePhoneId",
                principalTable: "Phone",
                principalColumn: "PhoneId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMaster_Phone_CompanyPhonePhoneId",
                table: "CompanyMaster");

            migrationBuilder.RenameColumn(
                name: "CompanyPhonePhoneId",
                table: "CompanyMaster",
                newName: "CompanyPhoneIdPhoneId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyMaster_CompanyPhonePhoneId",
                table: "CompanyMaster",
                newName: "IX_CompanyMaster_CompanyPhoneIdPhoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMaster_Phone_CompanyPhoneIdPhoneId",
                table: "CompanyMaster",
                column: "CompanyPhoneIdPhoneId",
                principalTable: "Phone",
                principalColumn: "PhoneId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
