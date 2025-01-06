using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class modelModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RenewableEnergyDataHistorys_RenewableEnergyPlants_RenewableEnergyPlantId",
                table: "RenewableEnergyDataHistorys");

            migrationBuilder.DropForeignKey(
                name: "FK_RenewableEnergyPlants_EnergyTypes_EnergyTypeId",
                table: "RenewableEnergyPlants");

            migrationBuilder.DropIndex(
                name: "IX_RenewableEnergyPlants_EnergyTypeId",
                table: "RenewableEnergyPlants");

            migrationBuilder.DropIndex(
                name: "IX_RenewableEnergyDataHistorys_RenewableEnergyPlantId",
                table: "RenewableEnergyDataHistorys");

            migrationBuilder.DropColumn(
                name: "RenewableEnergyPlantId",
                table: "RenewableEnergyDataHistorys");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "History",
                table: "RenewableEnergyPlants");

            migrationBuilder.AddColumn<int>(
                name: "RenewableEnergyPlantId",
                table: "RenewableEnergyDataHistorys",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RenewableEnergyPlants_EnergyTypeId",
                table: "RenewableEnergyPlants",
                column: "EnergyTypeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RenewableEnergyPlants_EnergyTypes_EnergyTypeId",
                table: "RenewableEnergyPlants",
                column: "EnergyTypeId",
                principalTable: "EnergyTypes",
                principalColumn: "EnergyTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
