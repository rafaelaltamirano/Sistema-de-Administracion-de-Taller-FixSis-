using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPCCC_ALTAMIRANO.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Por Favor ingrese su Nombre de usuario")]       
        [Display(Name = "Nombre de Usuario")]
        [StringLength(30)]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [StringLength(10)]
        public string PassUsuario { get; set; }
    }
}