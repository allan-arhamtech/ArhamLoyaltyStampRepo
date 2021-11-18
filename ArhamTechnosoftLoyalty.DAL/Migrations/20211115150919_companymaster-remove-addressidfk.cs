using Microsoft.EntityFrameworkCore.Migrations;

namespace ArhamTechnosoftLoyalty.DAL.Migrations
{
    public partial class companymasterremoveaddressidfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMaster_Address_CompanyAddressId",
                table: "CompanyMaster");

            migrationBuilder.AlterColumn<long>(
                name: "CompanyAddressId",
                table: "CompanyMaster",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMaster_Address_CompanyAddressId",
                table: "CompanyMaster",
                column: "CompanyAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMaster_Address_CompanyAddressId",
                table: "CompanyMaster");

            migrationBuilder.AlterColumn<long>(
                name: "CompanyAddressId",
                table: "CompanyMaster",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMaster_Address_CompanyAddressId",
                table: "CompanyMaster",
                column: "CompanyAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
