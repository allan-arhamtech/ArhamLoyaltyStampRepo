using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ArhamTechnosoftLoyalty.DAL.Migrations
{
    public partial class AddCompanyAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyUser_AspNetUsers_applicationUserId",
                table: "CompanyUser");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "applicationUserId",
                table: "CompanyUser",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyUser_applicationUserId",
                table: "CompanyUser",
                newName: "IX_CompanyUser_ApplicationUserId");

            migrationBuilder.AddColumn<long>(
                name: "CompanyBranchBranchId",
                table: "CompanyUser",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyMasterCompanyId",
                table: "CompanyUser",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "CompanyUser",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "CompanyUser",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyAddressAddressId",
                table: "CompanyMaster",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BranchAddressAddressId",
                table: "CompanyBranch",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AddressLine1 = table.Column<string>(type: "text", nullable: true),
                    AddressLine2 = table.Column<string>(type: "text", nullable: true),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUser_CompanyBranchBranchId",
                table: "CompanyUser",
                column: "CompanyBranchBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUser_CompanyMasterCompanyId",
                table: "CompanyUser",
                column: "CompanyMasterCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMaster_CompanyAddressAddressId",
                table: "CompanyMaster",
                column: "CompanyAddressAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBranch_BranchAddressAddressId",
                table: "CompanyBranch",
                column: "BranchAddressAddressId");

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
                name: "FK_CompanyUser_AspNetUsers_ApplicationUserId",
                table: "CompanyUser",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyUser_CompanyBranch_CompanyBranchBranchId",
                table: "CompanyUser",
                column: "CompanyBranchBranchId",
                principalTable: "CompanyBranch",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyUser_CompanyMaster_CompanyMasterCompanyId",
                table: "CompanyUser",
                column: "CompanyMasterCompanyId",
                principalTable: "CompanyMaster",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranch_Address_BranchAddressAddressId",
                table: "CompanyBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMaster_Address_CompanyAddressAddressId",
                table: "CompanyMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyUser_AspNetUsers_ApplicationUserId",
                table: "CompanyUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyUser_CompanyBranch_CompanyBranchBranchId",
                table: "CompanyUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyUser_CompanyMaster_CompanyMasterCompanyId",
                table: "CompanyUser");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_CompanyUser_CompanyBranchBranchId",
                table: "CompanyUser");

            migrationBuilder.DropIndex(
                name: "IX_CompanyUser_CompanyMasterCompanyId",
                table: "CompanyUser");

            migrationBuilder.DropIndex(
                name: "IX_CompanyMaster_CompanyAddressAddressId",
                table: "CompanyMaster");

            migrationBuilder.DropIndex(
                name: "IX_CompanyBranch_BranchAddressAddressId",
                table: "CompanyBranch");

            migrationBuilder.DropColumn(
                name: "CompanyBranchBranchId",
                table: "CompanyUser");

            migrationBuilder.DropColumn(
                name: "CompanyMasterCompanyId",
                table: "CompanyUser");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "CompanyUser");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "CompanyUser");

            migrationBuilder.DropColumn(
                name: "CompanyAddressAddressId",
                table: "CompanyMaster");

            migrationBuilder.DropColumn(
                name: "BranchAddressAddressId",
                table: "CompanyBranch");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "CompanyUser",
                newName: "applicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyUser_ApplicationUserId",
                table: "CompanyUser",
                newName: "IX_CompanyUser_applicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyUser_AspNetUsers_applicationUserId",
                table: "CompanyUser",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
