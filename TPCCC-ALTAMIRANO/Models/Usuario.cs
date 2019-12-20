using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPCCC_ALTAMIRANO.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Alias { get; set; }
        [Required]
        public int TipoUsuario { get; set; }
        [Required]
        public int Dni { get; set; }
        [Required]
        public string Pass { get; set; }
        [Required]
        public int IdSucursal { get; set; }
        [Required]
        public string Email { get; set; }
    }
}