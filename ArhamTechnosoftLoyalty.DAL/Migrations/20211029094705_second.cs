using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ArhamTechnosoftLoyalty.DAL.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranch_AspNetUsers_ApplicationUserId",
                table: "CompanyBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranch_CompanyMaster_CompanyId",
                table: "CompanyBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMaster_AspNetUsers_ApplicationUserId",
                table: "CompanyMaster");

            migrationBuilder.DropIndex(
                name: "IX_CompanyMaster_ApplicationUserId",
                table: "CompanyMaster");

            migrationBuilder.DropIndex(
                name: "IX_CompanyBranch_ApplicationUserId",
                table: "CompanyBranch");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "CompanyMaster");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
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

            migrationBuilder.CreateTable(
                name: "CompanyStore",
                columns: table => new
                {
                    StoreId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StoreName = table.Column<string>(type: "text", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyStore", x => x.StoreId);
                    table.ForeignKey(
                        name: "FK_CompanyStore_CompanyMaster_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyMaster",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyStore_CompanyId",
                table: "CompanyStore",
                column: "CompanyId");

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

            migrationBuilder.DropTable(
                name: "CompanyStore");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "CompanyMaster",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                table: "CompanyBranch",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "CompanyBranch",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMaster_ApplicationUserId",
                table: "CompanyMaster",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBranch_ApplicationUserId",
                table: "CompanyBranch",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranch_AspNetUsers_ApplicationUserId",
                table: "CompanyBranch",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranch_CompanyMaster_CompanyId",
                table: "CompanyBranch",
                column: "CompanyId",
                principalTable: "CompanyMaster",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMaster_AspNetUsers_ApplicationUserId",
                table: "CompanyMaster",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
