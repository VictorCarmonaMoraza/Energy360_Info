using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class renombrarTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RenewableEnergyDataHistorys_RenewableEnergyPlants_RenewableEnergyPlantId",
                table: "RenewableEnergyDataHistorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RenewableEnergyPlants",
                table: "RenewableEnergyPlants");

            migrationBuilder.RenameTable(
                name: "RenewableEnergyPlants",
                newName: "RenewableEnergyPlant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RenewableEnergyPlant",
                table: "RenewableEnergyPlant",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RenewableEnergyDataHistorys_RenewableEnergyPlant_RenewableEnergyPlantId",
                table: "RenewableEnergyDataHistorys",
                column: "RenewableEnergyPlantId",
                principalTable: "RenewableEnergyPlant",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RenewableEnergyDataHistorys_RenewableEnergyPlant_RenewableEnergyPlantId",
                table: "RenewableEnergyDataHistorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RenewableEnergyPlant",
                table: "RenewableEnergyPlant");

            migrationBuilder.RenameTable(
                name: "RenewableEnergyPlant",
                newName: "RenewableEnergyPlants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RenewableEnergyPlants",
                table: "RenewableEnergyPlants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RenewableEnergyDataHistorys_RenewableEnergyPlants_RenewableEnergyPlantId",
                table: "RenewableEnergyDataHistorys",
                column: "RenewableEnergyPlantId",
                principalTable: "RenewableEnergyPlants",
                principalColumn: "Id");
        }
    }
}
