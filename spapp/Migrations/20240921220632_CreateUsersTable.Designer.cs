﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using spapp.SpappContext;

#nullable disable

namespace spapp.Migrations
{
    [DbContext(typeof(SpappContextDb))]
    [Migration("20240921220632_CreateUsersTable")]
    partial class CreateUsersTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("spapp.Models.AddressModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<int>("NeighborhoodId")
                        .HasColumnType("int");

                    b.Property<int?>("NeighborhoodSectorId")
                        .HasColumnType("int");

                    b.Property<string>("Origin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex("NeighborhoodId");

                    b.HasIndex("NeighborhoodSectorId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("spapp.Models.AgentGroupModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AgentGroups");
                });

            modelBuilder.Entity("spapp.Models.AgentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("AgentGroupId")
                        .HasColumnType("int");

                    b.Property<int>("AgentRankId")
                        .HasColumnType("int");

                    b.Property<string>("AttestionNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BloodGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNINumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ChilddrenQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Complement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("Indication")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<string>("MatriculeNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("AgentGroupId");

                    b.HasIndex("AgentRankId");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("spapp.Models.AgentRankModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AgentRanks");
                });

            modelBuilder.Entity("spapp.Models.CityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long?>("Area")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Population")
                        .HasColumnType("bigint");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("spapp.Models.ComplainTypeCategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ComplainTypesCategories");
                });

            modelBuilder.Entity("spapp.Models.ComplainTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ComplainTypeCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PenalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ComplainTypeCategoryId");

                    b.ToTable("ComplainTypes");
                });

            modelBuilder.Entity("spapp.Models.MunicipalityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Population")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Municipalities");
                });

            modelBuilder.Entity("spapp.Models.NeighborhoodModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<float?>("Latitude")
                        .HasColumnType("real");

                    b.Property<float?>("Longitude")
                        .HasColumnType("real");

                    b.Property<int>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Population")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("MunicipalityId");

                    b.ToTable("Neighborhoods");
                });

            modelBuilder.Entity("spapp.Models.NeighborhoodSectorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRiskArea")
                        .HasColumnType("bit");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<int>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NeighborhoodId")
                        .HasColumnType("int");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex("NeighborhoodId");

                    b.ToTable("NeighborhoodSectors");
                });

            modelBuilder.Entity("spapp.Models.PatrolMemberModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("PatrolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgentId")
                        .IsUnique();

                    b.HasIndex("PatrolId");

                    b.ToTable("PatrolMembers");
                });

            modelBuilder.Entity("spapp.Models.PatrolModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DriverId")
                        .IsUnique();

                    b.HasIndex("VehicleId")
                        .IsUnique();

                    b.ToTable("Patrols");
                });

            modelBuilder.Entity("spapp.Models.PatrolMunicipalityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<int>("PatrolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex("PatrolId");

                    b.ToTable("PatrolMunicipalities");
                });

            modelBuilder.Entity("spapp.Models.PatrolNeighborhoodModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("NeighbordhoodId")
                        .HasColumnType("int");

                    b.Property<int>("PatrolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NeighbordhoodId");

                    b.HasIndex("PatrolId");

                    b.ToTable("PatrolNeighborhoods");
                });

            modelBuilder.Entity("spapp.Models.PatrolNeighborhoodSectorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("NeighbordhoodSectorId")
                        .HasColumnType("int");

                    b.Property<int>("PatrolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NeighbordhoodSectorId");

                    b.HasIndex("PatrolId");

                    b.ToTable("PatrolNeighborhoodSectors");
                });

            modelBuilder.Entity("spapp.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountActivationKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressComplement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("AtestationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNINumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAccessBlocked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActivatedAccount")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWanted")
                        .HasColumnType("bit");

                    b.Property<int>("Origem")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("spapp.Models.VehicleBrandModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleBrands");
                });

            modelBuilder.Entity("spapp.Models.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<long?>("KM")
                        .HasColumnType("bigint");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehicleBrandId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleBrandId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("spapp.Models.AddressModel", b =>
                {
                    b.HasOne("spapp.Models.CityModel", "CityModel")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("spapp.Models.MunicipalityModel", "MunicipalityModel")
                        .WithMany()
                        .HasForeignKey("MunicipalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("spapp.Models.NeighborhoodModel", "NeighborhoodModel")
                        .WithMany()
                        .HasForeignKey("NeighborhoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("spapp.Models.NeighborhoodSectorModel", "NeighborhoodSectorModel")
                        .WithMany()
                        .HasForeignKey("NeighborhoodSectorId");

                    b.Navigation("CityModel");

                    b.Navigation("MunicipalityModel");

                    b.Navigation("NeighborhoodModel");

                    b.Navigation("NeighborhoodSectorModel");
                });

            modelBuilder.Entity("spapp.Models.AgentModel", b =>
                {
                    b.HasOne("spapp.Models.AddressModel", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("spapp.Models.AgentGroupModel", "AgentGroup")
                        .WithMany()
                        .HasForeignKey("AgentGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("spapp.Models.AgentRankModel", "AgentRank")
                        .WithMany()
                        .HasForeignKey("AgentRankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("AgentGroup");

                    b.Navigation("AgentRank");
                });

            modelBuilder.Entity("spapp.Models.ComplainTypeModel", b =>
                {
                    b.HasOne("spapp.Models.ComplainTypeCategoryModel", "ComplainTypeCategory")
                        .WithMany("ComplainTypes")
                        .HasForeignKey("ComplainTypeCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComplainTypeCategory");
                });

            modelBuilder.Entity("spapp.Models.MunicipalityModel", b =>
                {
                    b.HasOne("spapp.Models.CityModel", "City")
                        .WithMany("Municipalitys")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("spapp.Models.NeighborhoodModel", b =>
                {
                    b.HasOne("spapp.Models.CityModel", "City")
                        .WithMany("Neighborhoods")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("spapp.Models.MunicipalityModel", "Municipality")
                        .WithMany("Neighborhoods")
                        .HasForeignKey("MunicipalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Municipality");
                });

            modelBuilder.Entity("spapp.Models.NeighborhoodSectorModel", b =>
                {
                    b.HasOne("spapp.Models.MunicipalityModel", "Municipality")
                        .WithMany("NeighborhoodSectors")
                        .HasForeignKey("MunicipalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("spapp.Models.NeighborhoodModel", "Neighborhood")
                        .WithMany("NeighborhoodSectors")
                        .HasForeignKey("NeighborhoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipality");

                    b.Navigation("Neighborhood");
                });

            modelBuilder.Entity("spapp.Models.PatrolMemberModel", b =>
                {
                    b.HasOne("spapp.Models.AgentModel", "Agent")
                        .WithOne()
                        .HasForeignKey("spapp.Models.PatrolMemberModel", "AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("spapp.Models.PatrolModel", "Patrol")
                        .WithMany("PatrolMembers")
                        .HasForeignKey("PatrolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Patrol");
                });

            modelBuilder.Entity("spapp.Models.PatrolModel", b =>
                {
                    b.HasOne("spapp.Models.AgentModel", "Driver")
                        .WithOne("Patrol")
                        .HasForeignKey("spapp.Models.PatrolModel", "DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("spapp.Models.VehicleModel", "Vehicle")
                        .WithOne("Patrol")
                        .HasForeignKey("spapp.Models.PatrolModel", "VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("spapp.Models.PatrolMunicipalityModel", b =>
                {
                    b.HasOne("spapp.Models.MunicipalityModel", "Municipality")
                        .WithMany("PatrolMunicipalities")
                        .HasForeignKey("MunicipalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("spapp.Models.PatrolModel", "Patrol")
                        .WithMany("PatrolMunicipalities")
                        .HasForeignKey("PatrolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipality");

                    b.Navigation("Patrol");
                });

            modelBuilder.Entity("spapp.Models.PatrolNeighborhoodModel", b =>
                {
                    b.HasOne("spapp.Models.NeighborhoodModel", "Neighborhood")
                        .WithMany("PatrolNeighborhoods")
                        .HasForeignKey("NeighbordhoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("spapp.Models.PatrolModel", "Patrol")
                        .WithMany("PatrolNeighborhoods")
                        .HasForeignKey("PatrolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Neighborhood");

                    b.Navigation("Patrol");
                });

            modelBuilder.Entity("spapp.Models.PatrolNeighborhoodSectorModel", b =>
                {
                    b.HasOne("spapp.Models.NeighborhoodSectorModel", "NeighborhoodSector")
                        .WithMany("PatrolNeighborhoods")
                        .HasForeignKey("NeighbordhoodSectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("spapp.Models.PatrolModel", "Patrol")
                        .WithMany("PatrolNeighborhoodSectors")
                        .HasForeignKey("PatrolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NeighborhoodSector");

                    b.Navigation("Patrol");
                });

            modelBuilder.Entity("spapp.Models.UserModel", b =>
                {
                    b.HasOne("spapp.Models.AddressModel", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("spapp.Models.VehicleModel", b =>
                {
                    b.HasOne("spapp.Models.VehicleBrandModel", "VehicleBrandModel")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleBrandModel");
                });

            modelBuilder.Entity("spapp.Models.AddressModel", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("spapp.Models.AgentModel", b =>
                {
                    b.Navigation("Patrol");
                });

            modelBuilder.Entity("spapp.Models.CityModel", b =>
                {
                    b.Navigation("Municipalitys");

                    b.Navigation("Neighborhoods");
                });

            modelBuilder.Entity("spapp.Models.ComplainTypeCategoryModel", b =>
                {
                    b.Navigation("ComplainTypes");
                });

            modelBuilder.Entity("spapp.Models.MunicipalityModel", b =>
                {
                    b.Navigation("NeighborhoodSectors");

                    b.Navigation("Neighborhoods");

                    b.Navigation("PatrolMunicipalities");
                });

            modelBuilder.Entity("spapp.Models.NeighborhoodModel", b =>
                {
                    b.Navigation("NeighborhoodSectors");

                    b.Navigation("PatrolNeighborhoods");
                });

            modelBuilder.Entity("spapp.Models.NeighborhoodSectorModel", b =>
                {
                    b.Navigation("PatrolNeighborhoods");
                });

            modelBuilder.Entity("spapp.Models.PatrolModel", b =>
                {
                    b.Navigation("PatrolMembers");

                    b.Navigation("PatrolMunicipalities");

                    b.Navigation("PatrolNeighborhoodSectors");

                    b.Navigation("PatrolNeighborhoods");
                });

            modelBuilder.Entity("spapp.Models.VehicleBrandModel", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("spapp.Models.VehicleModel", b =>
                {
                    b.Navigation("Patrol");
                });
#pragma warning restore 612, 618
        }
    }
}
