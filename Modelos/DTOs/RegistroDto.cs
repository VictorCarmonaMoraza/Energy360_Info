using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.DTOs
{
    public class RegistroDto
    {
        [Required(ErrorMessage = "Username es Requerido")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password es Requerido")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "La contraseña debe tener entre 4 y 8 caracteres")]
        public string Password { get; set; }
    }
}
