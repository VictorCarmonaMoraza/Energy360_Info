using Modelos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepository;

public interface IUserRepository
{
    Task SaveUser(User user);

    //Obtener todos los usuarios
    Task<List<User>> GetAllUsers();

    Task<bool> ValidateExist(User user);
}
