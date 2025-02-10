using Data.IRepository;
using Data.IServices;
using Modelos.Entities;

namespace Data.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task SaveUser(User user)
        {
            await _userRepository.SaveUser(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        

        public Task<bool> ValidateExist(User user)
        {
            return _userRepository.ValidateExist(user);
        }

        public Task<string> CreatrToken(User user)
        {
            return _userRepository.CreatrToken(user);
        }

        public Task<bool> UsuarioExiste(string username)
        {
            return _userRepository.UsuarioExiste(username);
        }

        public Task<User> PrimeroBBDD(string username)
        {
            return _userRepository.PrimeroBBDD(username);
        }
    }
}
