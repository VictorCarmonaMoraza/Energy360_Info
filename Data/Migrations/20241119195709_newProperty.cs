using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class newProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RenewableEnergyPlantId",
                table: "RenewableEnergyDataHistorys",
                type: "int",
                nullable: true);

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

            migrationBuilder.DropIndex(
                name: "IX_RenewableEnergyDataHistorys_RenewableEnergyPlantId",
                table: "RenewableEnergyDataHistorys");

            migrationBuilder.DropColumn(
                name: "RenewableEnergyPlantId",
                table: "RenewableEnergyDataHistorys");
        }
    }
}
