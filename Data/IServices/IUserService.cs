using Energy360_Info.Domain.Models;

namespace Data.IServices
{
    public interface IUserService
    {
        Task SaveUser(User user);

        //Obtener todos los usuarios
        Task<List<User>> GetAllUsers();
    }
}
