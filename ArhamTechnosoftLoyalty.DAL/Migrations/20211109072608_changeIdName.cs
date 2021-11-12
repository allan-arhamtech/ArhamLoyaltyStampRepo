using Microsoft.EntityFrameworkCore.Migrations;

namespace ArhamTechnosoftLoyalty.DAL.Migrations
{
    public partial class changeIdName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranch_Address_BranchAddressAddressId",
                table: "CompanyBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMaster_Address_CompanyAddressAddressId",
                table: "CompanyMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMaster_Email_CompanyMailEmailId",
                table: "CompanyMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMaster_Phone_CompanyPhonePhoneId",
                table: "CompanyMaster");

            migrationBuilder.RenameColumn(
                name: "PhoneId",
                table: "Phone",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmailId",
                table: "Email",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CompanyPhonePhoneId",
                table: "CompanyMaster",
                newName: "CompanyPhoneId");

            migrationBuilder.RenameColumn(
                name: "CompanyMailEmailId",
                table: "CompanyMaster",
                newName: "CompanyMailId");

            migrationBuilder.RenameColumn(
                name: "CompanyAddressAddressId",
                table: "CompanyMaster",
                newName: "CompanyAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyMaster_CompanyPhonePhoneId",
                table: "CompanyMaster",
                newName: "IX_CompanyMaster_CompanyPhoneId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyMaster_CompanyMailEmailId",
                table: "CompanyMaster",
                newName: "IX_CompanyMaster_CompanyMailId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyMaster_CompanyAddressAddressId",
                table: "CompanyMaster",
                newName: "IX_CompanyMaster_CompanyAddressId");

            migrationBuilder.RenameColumn(
                name: "BranchAddressAddressId",
                table: "CompanyBranch",
                newName: "BranchAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyBranch_BranchAddressAddressId",
                table: "CompanyBranch",
                newName: "IX_CompanyBranch_BranchAddressId");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Address",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranch_Address_BranchAddressId",
                table: "CompanyBranch",
                column: "BranchAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMaster_Address_CompanyAddressId",
                table: "CompanyMaster",
                column: "CompanyAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMaster_Email_CompanyMailId",
                table: "CompanyMaster",
                column: "CompanyMailId",
                principalTable: "Email",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMaster_Phone_CompanyPhoneId",
                table: "CompanyMaster",
                column: "CompanyPhoneId",
                principalTable: "Phone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranch_Address_BranchAddressId",
                table: "CompanyBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMaster_Address_CompanyAddressId",
                table: "CompanyMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMaster_Email_CompanyMailId",
                table: "CompanyMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMaster_Phone_CompanyPhoneId",
                table: "CompanyMaster");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Phone",
                newName: "PhoneId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Email",
                newName: "EmailId");

            migrationBuilder.RenameColumn(
                name: "CompanyPhoneId",
                table: "CompanyMaster",
                newName: "CompanyPhonePhoneId");

            migrationBuilder.RenameColumn(
                name: "CompanyMailId",
                table: "CompanyMaster",
                newName: "CompanyMailEmailId");

            migrationBuilder.RenameColumn(
                name: "CompanyAddressId",
                table: "CompanyMaster",
                newName: "CompanyAddressAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyMaster_CompanyPhoneId",
                table: "CompanyMaster",
                newName: "IX_CompanyMaster_CompanyPhonePhoneId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyMaster_CompanyMailId",
                table: "CompanyMaster",
                newName: "IX_CompanyMaster_CompanyMailEmailId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyMaster_CompanyAddressId",
                table: "CompanyMaster",
                newName: "IX_CompanyMaster_CompanyAddressAddressId");

            migrationBuilder.RenameColumn(
                name: "BranchAddressId",
                table: "CompanyBranch",
                newName: "BranchAddressAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyBranch_BranchAddressId",
                table: "CompanyBranch",
                newName: "IX_CompanyBranch_BranchAddressAddressId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Address",
                newName: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranch_Address_BranchAddressAddressId",
                table: "CompanyBranch",
                column: "BranchAddressAddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMaster_Address_CompanyAddressAddressId",
                table: "CompanyMaster",
                column: "CompanyAddressAddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMaster_Email_CompanyMailEmailId",
                table: "CompanyMaster",
                column: "CompanyMailEmailId",
                principalTable: "Email",
                principalColumn: "EmailId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMaster_Phone_CompanyPhonePhoneId",
                table: "CompanyMaster",
                column: "CompanyPhonePhoneId",
                principalTable: "Phone",
                principalColumn: "PhoneId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
