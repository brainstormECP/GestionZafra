using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GestionZafra.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Este Campo es requerido")]
        [DataType(DataType.Password)]
        [Remote("CheckOldPassword", "Account", ErrorMessage = "La contraseña no coincide con la actual", HttpMethod = "POST")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Este Campo es requerido")]
        [DataType(DataType.Password)]
        [StringLength(12, MinimumLength = 5, ErrorMessage = "La contraseña debe tener entre 5 y 12 caracteres")]
        public string NewPassword { get; set; }
        
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword",ErrorMessage = "No coinciden la contraseña nueva y la confirmacion")]
        public string ConfirmNewPassword { get; set; }
    }
}