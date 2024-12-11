using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionTablaRenovablesPlanta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnergyType",
                table: "RenewableEnergyPlants");

            migrationBuilder.AddColumn<int>(
                name: "EnergyTypeId",
                table: "RenewableEnergyPlants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RenewableEnergyPlants_EnergyTypeId",
                table: "RenewableEnergyPlants",
                column: "EnergyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RenewableEnergyPlants_EnergyTypes_EnergyTypeId",
                table: "RenewableEnergyPlants",
                column: "EnergyTypeId",
                principalTable: "EnergyTypes",
                principalColumn: "EnergyTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RenewableEnergyPlants_EnergyTypes_EnergyTypeId",
                table: "RenewableEnergyPlants");

            migrationBuilder.DropIndex(
                name: "IX_RenewableEnergyPlants_EnergyTypeId",
                table: "RenewableEnergyPlants");

            migrationBuilder.DropColumn(
                name: "EnergyTypeId",
                table: "RenewableEnergyPlants");

            migrationBuilder.AddColumn<string>(
                name: "EnergyType",
                table: "RenewableEnergyPlants",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
