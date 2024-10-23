using Data.IServices;
using Energy360_Info.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Energy360_Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser([FromBody] User user)
        {
            try
            {
                var validateUserExist = await _userService.ValidateExist(user);
                if (validateUserExist)
                {
                    return BadRequest(new { message="El usaurio "+user.NameUser+" ya existe en BD"});
                }
                await _userService.SaveUser(user);
                return Ok(new {message ="Usuario creado con exito"});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        //Obtener todos los usuarios
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest("ha surgido un problema");
            }
        }
    }
}
