using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ArhamTechnosoftLoyalty.DAL.Migrations
{
    public partial class updateCompanyMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CompanyMaster",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "CompanyMaster",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "CompanyMaster",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyMailEmailId",
                table: "CompanyMaster",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyPhoneIdPhoneId",
                table: "CompanyMaster",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    EmailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmailAddress = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.EmailId);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    PhoneId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhoneNo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.PhoneId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMaster_CompanyMailEmailId",
                table: "CompanyMaster",
                column: "CompanyMailEmailId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMaster_CompanyPhoneIdPhoneId",
                table: "CompanyMaster",
                column: "CompanyPhoneIdPhoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMaster_Email_CompanyMailEmailId",
                table: "CompanyMaster",
                column: "CompanyMailEmailId",
                principalTable: "Email",
                principalColumn: "EmailId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMaster_Phone_CompanyPhoneIdPhoneId",
                table: "CompanyMaster",
                column: "CompanyPhoneIdPhoneId",
                principalTable: "Phone",
                principalColumn: "PhoneId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMaster_Email_CompanyMailEmailId",
                table: "CompanyMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMaster_Phone_CompanyPhoneIdPhoneId",
                table: "CompanyMaster");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropIndex(
                name: "IX_CompanyMaster_CompanyMailEmailId",
                table: "CompanyMaster");

            migrationBuilder.DropIndex(
                name: "IX_CompanyMaster_CompanyPhoneIdPhoneId",
                table: "CompanyMaster");

            migrationBuilder.DropColumn(
                name: "CompanyMailEmailId",
                table: "CompanyMaster");

            migrationBuilder.DropColumn(
                name: "CompanyPhoneIdPhoneId",
                table: "CompanyMaster");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CompanyMaster",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "CompanyMaster",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "CompanyMaster",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
