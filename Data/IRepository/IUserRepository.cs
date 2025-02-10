using Modelos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepository;

public interface IUserRepository
{
    Task SaveUser(User user);

    //Obtener todos los usuarios
    Task<List<User>> GetAllUsers();

    Task<bool> ValidateExist(User user);

    Task<string> CreatrToken(User user);

    Task<bool> UsuarioExiste(string user);

    Task<User> PrimeroBBDD(string username);
}
