﻿// <auto-generated />
using System;
using Data.DbContext_Conection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241119195709_newProperty")]
    partial class newProperty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Modelos.Entities.EnergyType", b =>
                {
                    b.Property<int>("EnergyTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnergyTypeId"));

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EnergyTypeId");

                    b.ToTable("EnergyTypes");
                });

            modelBuilder.Entity("Modelos.Entities.RenewableEnergyDataHistory", b =>
                {
                    b.Property<int>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HistoryId"));

                    b.Property<double>("CapacityFactor")
                        .HasColumnType("float");

                    b.Property<decimal>("ConstructionCostAmpliacion")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("EmissionsAvoided")
                        .HasColumnType("float");

                    b.Property<double>("EstimatedAnnualProduction")
                        .HasColumnType("float");

                    b.Property<int>("NumberOfUnits")
                        .HasColumnType("int");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RenewableEnergyPlantId")
                        .HasColumnType("int");

                    b.Property<string>("TechnologyProvider")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HistoryId");

                    b.HasIndex("RenewableEnergyPlantId");

                    b.ToTable("RenewableEnergyDataHistorys");
                });

            modelBuilder.Entity("Modelos.Entities.RenewableEnergyPlant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("CapacityFactor")
                        .HasColumnType("float");

                    b.Property<string>("CityOrRegion")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("ConstructionCost")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<double>("EmissionsAvoided")
                        .HasColumnType("float");

                    b.Property<int>("EnergyTypeId")
                        .HasColumnType("int");

                    b.Property<double>("EstimatedAnnualProduction")
                        .HasColumnType("float");

                    b.Property<double>("InstalledCapacity")
                        .HasColumnType("float");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("NumberOfUnits")
                        .HasColumnType("int");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TechnologyProvider")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("EnergyTypeId");

                    b.ToTable("RenewableEnergyPlants");
                });

            modelBuilder.Entity("Modelos.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameUser")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Modelos.Entities.RenewableEnergyDataHistory", b =>
                {
                    b.HasOne("Modelos.Entities.RenewableEnergyPlant", null)
                        .WithMany("RenewableEnergyDataHistories")
                        .HasForeignKey("RenewableEnergyPlantId");
                });

            modelBuilder.Entity("Modelos.Entities.RenewableEnergyPlant", b =>
                {
                    b.HasOne("Modelos.Entities.EnergyType", "EnergyType")
                        .WithMany()
                        .HasForeignKey("EnergyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EnergyType");
                });

            modelBuilder.Entity("Modelos.Entities.RenewableEnergyPlant", b =>
                {
                    b.Navigation("RenewableEnergyDataHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
