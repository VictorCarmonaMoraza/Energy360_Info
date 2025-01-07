using Microsoft.AspNetCore.Http;
using Modelos.Entities;

namespace Data.IServices
{
    public interface IRenewableEnergyPlantService
    {
        Task<List<RenewableEnergyPlant>> GetAllPlants();
        Task SavePlant(RenewableEnergyPlant renewableEnergyPlant);

        Task<List<RenewableEnergyDataHistory>> GetHistoryPlant(int id);

        Task<bool> ImportPlantFromExcel(Stream excelFile);

        Task<bool> ValidatePlantExists(RenewableEnergyPlant renewableEnergyPlant);

        Task<RenewableEnergyPlant> GetPlantById(int id);

        //Obtencion de todas las horas de consumo
        Task<List<RenewableEnergyConsumption>> GetConsumptionByDateAndHour(int id, DateTime date);



        Task<List<RenewableEnergyConsumption>>GetConsumptionByDateRange(int id, DateTime startDate, DateTime endDate);
    }
}
