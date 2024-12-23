using Modelos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IEnergyRepository
    {
        //Obtener todos los tipos de energia
        Task<List<EnergyType>> GetAllEnergyTypes();

        Task<EnergyType> GetEnergyTypeById(int id);
    }
}
