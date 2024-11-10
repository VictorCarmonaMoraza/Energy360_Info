using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class updateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RenewableEnergyDataHistorys_RenewableEnergyPlants_PlantId",
                table: "RenewableEnergyDataHistorys");

            migrationBuilder.DropIndex(
                name: "IX_RenewableEnergyDataHistorys_PlantId",
                table: "RenewableEnergyDataHistorys");

            migrationBuilder.RenameColumn(
                name: "ConstructionCost",
                table: "RenewableEnergyDataHistorys",
                newName: "ConstructionCostAmpliacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConstructionCostAmpliacion",
                table: "RenewableEnergyDataHistorys",
                newName: "ConstructionCost");

            migrationBuilder.CreateIndex(
                name: "IX_RenewableEnergyDataHistorys_PlantId",
                table: "RenewableEnergyDataHistorys",
                column: "PlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RenewableEnergyDataHistorys_RenewableEnergyPlants_PlantId",
                table: "RenewableEnergyDataHistorys",
                column: "PlantId",
                principalTable: "RenewableEnergyPlants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
