using Data.IRepository;
using Data.IServices;
using Data.Repository;
using Microsoft.AspNetCore.Http;
using Modelos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class RenewableEnergyPlantService :IRenewableEnergyPlantService
    {
        private readonly IRenewableEnergyPlantRepository _renewableEnergyPlantRepository;
        public RenewableEnergyPlantService(IRenewableEnergyPlantRepository renewableEnergyPlantRepository)
        {
            _renewableEnergyPlantRepository = renewableEnergyPlantRepository;
        }

        public async Task SavePlant(RenewableEnergyPlant renewableEnergyPlant)
        {
            await _renewableEnergyPlantRepository.SavePlant(renewableEnergyPlant);
        }

        public async Task<List<RenewableEnergyPlant>> GetAllPlants()
        {
            return await _renewableEnergyPlantRepository.GetAllPlants();
        }

        public async Task<List<RenewableEnergyDataHistory>> GetHistoryPlant(int id)
        {
            return await _renewableEnergyPlantRepository.GetHistoryPlant(id);
        }

        public async Task<bool> ImportPlantFromExcel(Stream excelFile)
        {
            return await _renewableEnergyPlantRepository.ImportPlantFromExcel(excelFile);
        }

        public async Task<bool> ValidatePlantExists(RenewableEnergyPlant renewableEnergyPlant)
        {
            return await _renewableEnergyPlantRepository.ValidatePlantExists(renewableEnergyPlant);
        }
    }
}
