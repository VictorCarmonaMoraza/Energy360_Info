﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Username es Requerido")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password es Requerido")]
        public string Password { get; set; }
    }
}
