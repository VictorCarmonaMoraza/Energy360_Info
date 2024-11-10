using Modelos.Entities;

namespace Data.IRepository;

public interface IRenewableEnergyPlantRepository
{
    Task<List<RenewableEnergyPlant>> GetAllPlants();
    Task SavePlant(RenewableEnergyPlant plant);

    Task<List<RenewableEnergyDataHistory>> GetHistoryPlant(int id);

    Task<bool> ImportPlantFromExcel(Stream excelFile);

    Task<bool> ValidateNamePlantExists(RenewableEnergyPlant renewableEnergyPlante);
}
