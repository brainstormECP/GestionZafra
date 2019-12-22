using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionZafra.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Este Campo es requerido")]
        [Remote("CheckLoginUser", "Account", ErrorMessage = "Usuario desconocido o no activo", HttpMethod = "POST")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Este Campo es requerido")]
        [DataType(DataType.Password)]
        [Remote("CheckLoginPassword", "Account",AdditionalFields = "Usuario", ErrorMessage = "Contraseña incorrecta",HttpMethod = "POST")]
        public string Contrasena { get; set; }
    }
}