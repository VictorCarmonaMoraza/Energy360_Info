using Data.DbContext_Conection;
using Data.IRepository;
using Microsoft.EntityFrameworkCore;
using Modelos.Entities;

namespace Data.Repository
{
    public class EnergyRepository: IEnergyRepository
    {
        private readonly ApplicationDbContext _context;

        public EnergyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Obtiene todos los usuarios
        public async Task<List<EnergyType>> GetAllEnergyTypes()
        {
            return await _context.EnergyTypes.ToListAsync();
        }

        public async Task<EnergyType> GetEnergyTypeById(int id)
        {
            return await _context.EnergyTypes.SingleOrDefaultAsync(x => x.EnergyTypeId == id);
        }
    }
}
