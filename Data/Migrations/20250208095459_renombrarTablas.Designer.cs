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
    [Migration("20250208095459_renombrarTablas")]
    partial class renombrarTablas
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

            modelBuilder.Entity("Modelos.Entities.RenewableEnergyConsumption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("DailyConsumption")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("HourlyConsumption")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MonthlyConsumption")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.Property<decimal?>("YearlyConsumption")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("RenewableEnergyConsumptions");
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

                    b.Property<string>("History")
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("RenewableEnergyPlant");
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

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Modelos.Entities.RenewableEnergyDataHistory", b =>
                {
                    b.HasOne("Modelos.Entities.RenewableEnergyPlant", null)
                        .WithMany("RenewableEnergyDataHistories")
                        .HasForeignKey("RenewableEnergyPlantId");
                });

            modelBuilder.Entity("Modelos.Entities.RenewableEnergyPlant", b =>
                {
                    b.Navigation("RenewableEnergyDataHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
