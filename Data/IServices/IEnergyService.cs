using Modelos.Entities;

namespace Data.IServices
{
    public interface IEnergyService
    {
        //Obtener todos los tipos de energia
        Task<List<EnergyType>> GetAllEnergyTypes();

        Task <EnergyType>GetEnergyTypeById(int id);
    }
}
