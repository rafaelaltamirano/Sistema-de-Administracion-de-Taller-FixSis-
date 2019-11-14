using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPCCC_ALTAMIRANO.Models
{
    public class Clientes
    {
        public int Id { get; set;}
        [StringLength(50)]
        public string Nombre { get; set;}
        [StringLength(50)]
        public string Apellido { get; set;}
        [StringLength(50)]
        public string Telefono { get; set;}
        [StringLength(50)]
        public string  Direccion { get; set;}
        [StringLength(60)]
        public string Email { get; set;}
    }
}