using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPCCC_ALTAMIRANO.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public long Cuit { get; set; }
        [Required]
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
      
    }
}