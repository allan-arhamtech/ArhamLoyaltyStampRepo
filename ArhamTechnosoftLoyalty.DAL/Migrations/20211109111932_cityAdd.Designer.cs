﻿// <auto-generated />
using System;
using ArhamTechnosoftLoyalty.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ArhamTechnosoftLoyalty.DAL.Migrations
{
    [DbContext(typeof(ArhamTechLoyaltyDbContext))]
    [Migration("20211109111932_cityAdd")]
    partial class cityAdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ArhamTechnosoftLoyalty.Models.EntityModel.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("text");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("text");

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<int>("StateId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("ArhamTechnosoftLoyalty.Models.EntityModel.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ArhamTechnosoftLoyalty.Models.EntityModel.City", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("country_code")
                        .HasColumnType("text");

                    b.Property<int>("country_id")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("state_code")
                        .HasColumnType("text");

                    b.Property<int>("state_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("ArhamTechnosoftLoyalty.Models.EntityModel.CompanyBranch", b =>
                {
                    b.Property<long>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("BranchAddressId")
                        .HasColumnType("bigint");

                    b.Property<string>("BranchName")
                        .HasColumnType("text");

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.HasKey("BranchId");

                    b.HasIndex("BranchAddressId");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyBranch");
                });

            modelBuilder.Entity("ArhamTechnosoftLoyalty.Models.EntityModel.CompanyMaster", b =>
                {
                    b.Property<long>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("CompanyAddressId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CompanyMailId")
                        .HasColumnType("bigint");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("CompanyPhoneId")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("CompanyId");

                    b.HasIndex("CompanyAddressId");

                    b.HasIndex("CompanyMailId");

                    b.HasIndex("CompanyPhoneId");

                    b.ToTable("CompanyMaster");
                });

            modelBuilder.Entity("ArhamTechnosoftLoyalty.Models.EntityModel.CompanyStore", b =>
                {
                    b.Property<long>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("StoreName")
                        .HasColumnType("text");

                    b.HasKey("StoreId");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyStore");
                });

            modelBuilder.Entity("ArhamTechnosoftLoyalty.Models.EntityModel.CompanyUser", b =>
                {
                    b.Property<long>("CompanyUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<long?>("CompanyBranchBranchId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CompanyMasterCompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("CompanyUserId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CompanyBranchBranchId");

                    b.HasIndex("CompanyMasterCompanyId");

                    b.ToTable("CompanyUser");
                });

            modelBuilder.Entity("ArhamTechnosoftLoyalty.Models.EntityModel.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("iso2")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("phone_code")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("ArhamTechnosoftLoyalty.Models.EntityModel.Email", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("ArhamTechnosoftLoyalty.Models.EntityModel.Phone", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("PhoneNo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("ArhamTechnosoftLoyalty.Models.EntityModel.State", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("country_code")
                        .HasColumnType("text");

                    b.Property<string>("country_id")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("state_code")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("State");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ArhamTechnosoftLoyalty.Models.EntityModel.CompanyBranch", b =>
                {
                    b.HasOne("ArhamTechnosoftLoyalty.Models.EntityModel.Address", "BranchAddress")
                        .WithMany()
                        .HasForeignKey("BranchAddressId");

                    b.HasOne("ArhamTechnosoftLoyalty.Models.EntityModel.CompanyMaster", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BranchAddress");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ArhamTechnosoftLoyalty.Models.EntityModel.CompanyMaster", b =>
                {
                    b.HasOne("ArhamTechnosoftLoyalty.Models.EntityModel.Address", "CompanyAddress")
                        .WithMany()
                        .HasForeignKey("CompanyAddressId");

                    b.HasOne("ArhamTechnosoftLoyalty.Models.EntityModel.Email", "CompanyMail")
                        .WithMany()
                        .HasForeignKey("CompanyMailId");

                    b.HasOne("ArhamTechnosoftLoyalty.Models.EntityModel.Phone", "CompanyPhone")
                        .WithMany()
                        .HasForeignKey("CompanyPhoneId");

                    b.Navigation("CompanyAddress");

                    b.Navigation("CompanyMail");

                    b.Navigation("CompanyPhone");
                });

            modelBuilder.Entity("ArhamTechnosoftLoyalty.Models.EntityModel.CompanyStore", b =>
                {
                    b.HasOne("ArhamTechnosoftLoyalty.Models.EntityModel.CompanyMaster", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ArhamTechnosoftLoyalty.Models.EntityModel.CompanyUser", b =>
                {
                    b.HasOne("ArhamTechnosoftLoyalty.Models.EntityModel.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("ArhamTechnosoftLoyalty.Models.EntityModel.CompanyBranch", "CompanyBranch")
                        .WithMany()
                        .HasForeignKey("CompanyBranchBranchId");

                    b.HasOne("ArhamTechnosoftLoyalty.Models.EntityModel.CompanyMaster", "CompanyMaster")
                        .WithMany()
                        .HasForeignKey("CompanyMasterCompanyId");

                    b.Navigation("ApplicationUser");

                    b.Navigation("CompanyBranch");

                    b.Navigation("CompanyMaster");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ArhamTechnosoftLoyalty.Models.EntityModel.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ArhamTechnosoftLoyalty.Models.EntityModel.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArhamTechnosoftLoyalty.Models.EntityModel.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ArhamTechnosoftLoyalty.Models.EntityModel.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
