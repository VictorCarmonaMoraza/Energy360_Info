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
    }
}
