using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableEnergy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RenewableEnergyPlants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    EnergyType = table.Column<string>(type: "varchar(50)", nullable: false),
                    Country = table.Column<string>(type: "varchar(50)", nullable: false),
                    CityOrRegion = table.Column<string>(type: "varchar(50)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    InstalledCapacity = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Owner = table.Column<string>(type: "varchar(50)", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", nullable: false),
                    EstimatedAnnualProduction = table.Column<double>(type: "float", nullable: false),
                    EmissionsAvoided = table.Column<double>(type: "float", nullable: false),
                    ConstructionCost = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    NumberOfUnits = table.Column<int>(type: "int", nullable: false),
                    CapacityFactor = table.Column<double>(type: "float", nullable: false),
                    TechnologyProvider = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RenewableEnergyPlants", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RenewableEnergyPlants");
        }
    }
}
