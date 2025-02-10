using Data.IServices;
using Microsoft.AspNetCore.Mvc;
using Modelos.DTOs;
using Modelos.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Energy360_Info.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Login de Usuario
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost("login")]  //POST: api/usuario/login
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            //var usuario = await _userService.Users.SingleOrDefaultAsync(x => x.Username == loginDto.Username);
            var usuario = await _userService.PrimeroBBDD(loginDto.Username);
            //Si el usuario no esta en la base de datos retornamos un mensaje de error
            if (usuario == null) return Unauthorized("Usuario no valido");

            using var hmac = new HMACSHA512(usuario.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            //Comparamos caracterer por caracter el hash de la contraseña
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != usuario.PasswordHash[i]) return Unauthorized("Contraseña incorrecta");
            }

            return new UserDto
            {
                Username = usuario.NameUser,
                Token = await _userService.CreatrToken(usuario)
            };
        }

        /// <summary>
        /// Registra un usuario en la base de datos
        /// </summary>
        /// <param name="registroDto"></param>
        /// <returns></returns>
        [HttpPost("registro")]
        public async Task<ActionResult<UserDto>> Registro(RegistroDto registroDto)
        {
            if (await UsuarioExiste(registroDto.Username)) return BadRequest("El usuario ya esta registrado en la base de datos");

            using var hmac = new HMACSHA512();
            var usuario = new User
            {
                NameUser = registroDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registroDto.Password)),
                PasswordSalt = hmac.Key
            };
            await _userService.SaveUser(usuario);
            
            return new UserDto
            {
                Username = usuario.NameUser,
                Token = await _userService.CreatrToken(usuario)
            };
        }

        //Obtener todos los usuarios
        [HttpGet("allUsers")]
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

        /// Valida si un usuario existe en la base de datos
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private async Task<bool> UsuarioExiste(string username)
        {
            return await _userService.UsuarioExiste(username);
                
        }
    }
}
