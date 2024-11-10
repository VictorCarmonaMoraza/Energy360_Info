using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class nuevoModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RenewableEnergyDataHistorys",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedAnnualProduction = table.Column<double>(type: "float", nullable: false),
                    EmissionsAvoided = table.Column<double>(type: "float", nullable: false),
                    ConstructionCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberOfUnits = table.Column<int>(type: "int", nullable: false),
                    CapacityFactor = table.Column<double>(type: "float", nullable: false),
                    TechnologyProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RenewableEnergyDataHistorys", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_RenewableEnergyDataHistorys_RenewableEnergyPlants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "RenewableEnergyPlants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RenewableEnergyDataHistorys_PlantId",
                table: "RenewableEnergyDataHistorys",
                column: "PlantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RenewableEnergyDataHistorys");
        }
    }
}
