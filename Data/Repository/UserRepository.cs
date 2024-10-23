using Data.DbContext_Conection;
using Data.IRepository;
using Microsoft.EntityFrameworkCore;
using Modelos.Entities;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Guarda usuario en la BD
        public async Task SaveUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        //Obtiene todos los usuarios
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> ValidateExist(User user)
        {
            return await _context.Users.AnyAsync(x => x.NameUser == user.NameUser);
        }
    }
}
