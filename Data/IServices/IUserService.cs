
using Modelos.Entities;

namespace Data.IServices
{
    public interface IUserService
    {
        Task SaveUser(User user);

        //Obtener todos los usuarios
        Task<List<User>> GetAllUsers();

        //Validar si un usuari existe en la BBDD
        Task<bool> ValidateExist(User user);

        Task<string> CreatrToken(User user);

        Task<bool> UsuarioExiste(string user);

        Task<User> PrimeroBBDD(string username);


    }
}
