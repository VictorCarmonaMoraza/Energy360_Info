using Data.IRepository;
using Data.IServices;
using Modelos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class EnergyService : IEnergyService
    {

        private readonly IEnergyRepository _energyRepository;
        public EnergyService(IEnergyRepository energyRepository)
        {
            _energyRepository = energyRepository;
        }
        public Task<List<EnergyType>> GetAllEnergyTypes()
        {
            return _energyRepository.GetAllEnergyTypes();
        }

        public Task<EnergyType> GetEnergyTypeById(int id)
        {
            return _energyRepository.GetEnergyTypeById(id);
        }
    }
}
