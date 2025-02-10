using Data.DbContext_Conection;
using Data.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Modelos.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly Microsoft.IdentityModel.Tokens.SymmetricSecurityKey _key;

        public UserRepository(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        //Guarda usuario en la BD
        public async Task SaveUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        //Obtiene todos los usuarios
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<bool> ValidateExist(User user)
        {
            return await _context.User.AnyAsync(x => x.NameUser == user.NameUser);
        }

        public async Task<string> CreatrToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.NameUser)
            };

            var credenciales = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credenciales
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return  tokenHandler.WriteToken(token);
        }

        public async Task<bool> UsuarioExiste(string username)
        {
            return await _context.User.AnyAsync(x => x.NameUser == username);
        }

        public async Task<User> PrimeroBBDD(string username)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.NameUser == username);
        }

    }
}
