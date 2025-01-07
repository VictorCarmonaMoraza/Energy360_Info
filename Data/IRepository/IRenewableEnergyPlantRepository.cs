using Modelos.Entities;

namespace Data.IRepository;

public interface IRenewableEnergyPlantRepository
{
    Task<List<RenewableEnergyPlant>> GetAllPlants();
    Task SavePlant(RenewableEnergyPlant plant);

    Task<List<RenewableEnergyDataHistory>> GetHistoryPlant(int id);

    Task<bool> ImportPlantFromExcel(Stream excelFile);

    Task<bool> ValidatePlantExists(RenewableEnergyPlant renewableEnergyPlante);

    Task<RenewableEnergyPlant> GetPlantById(int id);

    Task<List<RenewableEnergyConsumption>> GetConsumptionByDateAndHour(int id, DateTime date);

    Task<List<RenewableEnergyConsumption>> GetConsumptionByDateRange(int id, DateTime startDate, DateTime endDate);
}
