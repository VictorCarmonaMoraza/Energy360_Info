using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class newModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RenewableEnergyPlantId",
                table: "RenewableEnergyDataHistorys",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RenewableEnergyConsumptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HourlyConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonthlyConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    YearlyConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RenewableEnergyConsumptions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RenewableEnergyDataHistorys_RenewableEnergyPlantId",
                table: "RenewableEnergyDataHistorys",
                column: "RenewableEnergyPlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RenewableEnergyDataHistorys_RenewableEnergyPlants_RenewableEnergyPlantId",
                table: "RenewableEnergyDataHistorys",
                column: "RenewableEnergyPlantId",
                principalTable: "RenewableEnergyPlants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RenewableEnergyDataHistorys_RenewableEnergyPlants_RenewableEnergyPlantId",
                table: "RenewableEnergyDataHistorys");

            migrationBuilder.DropTable(
                name: "RenewableEnergyConsumptions");

            migrationBuilder.DropIndex(
                name: "IX_RenewableEnergyDataHistorys_RenewableEnergyPlantId",
                table: "RenewableEnergyDataHistorys");

            migrationBuilder.DropColumn(
                name: "RenewableEnergyPlantId",
                table: "RenewableEnergyDataHistorys");
        }
    }
}
